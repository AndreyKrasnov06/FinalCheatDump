using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace System
{
	// Token: 0x02000018 RID: 24
	public partial class FormNews : Form
	{
		// Token: 0x060000C3 RID: 195 RVA: 0x00012288 File Offset: 0x00010488
		public FormNews()
		{
			this.InitializeComponent();
			base.Padding = new Padding(30, 0, 4, 0);
			this.webBrowser1.ScrollBarsEnabled = false;
			this.webBrowser1.WebBrowserShortcutsEnabled = false;
			this.webBrowser1.ScriptErrorsSuppressed = true;
			this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
			FormNews.SetSilent(this.webBrowser1, true);
			this.webBrowser1.DocumentCompleted += this.WebBrowser_Main_DocumentCompleted;
			base.SizeChanged += delegate(object sender, EventArgs e)
			{
				if (this._mode == FormNews.Mode.ShowingCustom)
				{
					this.SyncMetrics();
				}
			};
			Control control = this.webBrowser1.Parent ?? this;
			control.Controls.Remove(this.webBrowser1);
			this._layout = new TableLayoutPanel
			{
				Dock = DockStyle.Fill,
				ColumnCount = 2,
				RowCount = 1,
				Margin = Padding.Empty,
				Padding = Padding.Empty,
				CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
				GrowStyle = TableLayoutPanelGrowStyle.FixedSize
			};
			this._layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this._layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this._layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0f));
			control.Controls.Add(this._layout);
			this._layout.BringToFront();
			this.webBrowser1.Dock = DockStyle.Fill;
			this._layout.Controls.Add(this.webBrowser1, 0, 0);
			this._rightHost = new Panel
			{
				Dock = DockStyle.Fill,
				Visible = false,
				Margin = Padding.Empty,
				Padding = Padding.Empty,
				BackColor = control.BackColor
			};
			this._barGap = new Panel
			{
				Dock = DockStyle.Left,
				Width = 0,
				BackColor = control.BackColor
			};
			this._barRightPad = new Panel
			{
				Dock = DockStyle.Right,
				Width = -6,
				BackColor = control.BackColor
			};
			this._bar = new global::System.ScrollBar
			{
				Dock = DockStyle.Fill,
				Visible = true
			};
			this._bar.ValueChanged += this.Bar_ValueChanged;
			this._rightHost.Controls.Add(this._bar);
			this._rightHost.Controls.Add(this._barRightPad);
			this._rightHost.Controls.Add(this._barGap);
			this._layout.Controls.Add(this._rightHost, 1, 0);
			this._fetchBrowser = new WebBrowser
			{
				ScriptErrorsSuppressed = true,
				ScrollBarsEnabled = false,
				WebBrowserShortcutsEnabled = false,
				Visible = true,
				Location = new Point(-5000, -5000),
				Size = new Size(1200, 800)
			};
			FormNews.SetSilent(this._fetchBrowser, true);
			this._fetchBrowser.DocumentCompleted += this.WebBrowser_Fetch_DocumentCompleted;
			control.Controls.Add(this._fetchBrowser);
			this._wheelFilter = new FormNews.WheelMessageFilter(this, this.webBrowser1);
			Application.AddMessageFilter(this._wheelFilter);
			this._mode = FormNews.Mode.LoadingSource;
			this.TriggerRefresh();
			this.StartRefreshTimer();
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000323D File Offset: 0x0000143D
		private void StartRefreshTimer()
		{
			this._refreshTimer = new Timer
			{
				Interval = 10000
			};
			this._refreshTimer.Tick += delegate(object sender, EventArgs e)
			{
				this.TriggerRefresh();
			};
			this._refreshTimer.Start();
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x000125E0 File Offset: 0x000107E0
		private void TriggerRefresh()
		{
			if (this._refreshInProgress)
			{
				return;
			}
			this._refreshInProgress = true;
			this._captureTimerFetch = FormNews.StopTimer(this._captureTimerFetch);
			this._refreshWatchdog = FormNews.StopTimer(this._refreshWatchdog);
			this._refreshWatchdog = new Timer
			{
				Interval = 25000
			};
			this._refreshWatchdog.Tick += delegate(object sender, EventArgs e)
			{
				this._refreshWatchdog = FormNews.StopTimer(this._refreshWatchdog);
				if (this._refreshInProgress)
				{
					this._captureTimerFetch = FormNews.StopTimer(this._captureTimerFetch);
					this._refreshInProgress = false;
				}
			};
			this._refreshWatchdog.Start();
			try
			{
				try
				{
					this._fetchBrowser.Stop();
				}
				catch
				{
				}
				this._fetchBrowser.Navigate(FormNews.GetFreshUrl());
			}
			catch
			{
				this._refreshWatchdog = FormNews.StopTimer(this._refreshWatchdog);
				this._refreshInProgress = false;
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x000126B0 File Offset: 0x000108B0
		private static string GetFreshUrl()
		{
			string text = ("https://antia-bot.ru/majestic/news".Contains("?") ? "&" : "?");
			return "https://antia-bot.ru/majestic/news" + text + "_ts=" + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00012700 File Offset: 0x00010900
		private void WebBrowser_Fetch_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			if (e.Url != this._fetchBrowser.Url)
			{
				return;
			}
			HtmlDocument document = this._fetchBrowser.Document;
			if (!(document == null) && !(document.Body == null) && !(document.Window == null))
			{
				this.StartAutoScrollCapture(this._fetchBrowser, delegate(string cleaned)
				{
					try
					{
						if (cleaned == null)
						{
							cleaned = "";
						}
						bool flag;
						if (!(flag = this._mode == FormNews.Mode.LoadingSource))
						{
							if (string.IsNullOrWhiteSpace(cleaned))
							{
								return;
							}
							if (cleaned == this._lastCleanedText)
							{
								return;
							}
						}
						this._lastCleanedText = cleaned;
						this._mode = FormNews.Mode.ShowingCustom;
						int num = (flag ? 0 : this._bar.Value);
						this.ScheduleScrollFix(num);
						this.webBrowser1.DocumentText = FormNews.BuildHtml(cleaned);
					}
					finally
					{
						this._refreshWatchdog = FormNews.StopTimer(this._refreshWatchdog);
						this._refreshInProgress = false;
					}
				});
				return;
			}
			this._refreshWatchdog = FormNews.StopTimer(this._refreshWatchdog);
			this._refreshInProgress = false;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00012788 File Offset: 0x00010988
		private void WebBrowser_Main_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			if (this._mode != FormNews.Mode.ShowingCustom)
			{
				return;
			}
			HtmlDocument document = this.webBrowser1.Document;
			if (!(document == null) && !(document.Body == null) && !(document.Window == null))
			{
				this.SyncMetrics();
				this.ApplyScrollFix();
				return;
			}
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x000127E0 File Offset: 0x000109E0
		private void StartAutoScrollCapture(WebBrowser wb, Action<string> onDone)
		{
			this._captureTimerFetch = FormNews.StopTimer(this._captureTimerFetch);
			int scrollY = 0;
			int lastDocH = 0;
			int start = Environment.TickCount;
			int lastHeightChange = start;
			Timer timer_0 = new Timer
			{
				Interval = 50
			};
			this._captureTimerFetch = timer_0;
			timer_0.Tick += delegate(object sender, EventArgs e)
			{
				HtmlDocument document = wb.Document;
				if (document == null || document.Body == null || document.Window == null)
				{
					return;
				}
				int tickCount = Environment.TickCount;
				if (tickCount - start >= 200)
				{
					timer_0.Stop();
					timer_0.Dispose();
					this._captureTimerFetch = null;
					string text = FormNews.ExtractAndClean(document);
					if (onDone != null)
					{
						onDone(text);
					}
					return;
				}
				int docHeight = this.GetDocHeight(wb);
				int num = Math.Max(1, wb.ClientSize.Height);
				if (docHeight != lastDocH)
				{
					lastDocH = docHeight;
					lastHeightChange = tickCount;
				}
				int num2 = Math.Max(400, num / 2);
				int num3 = Math.Max(0, docHeight - num);
				if (scrollY < num3)
				{
					scrollY = Math.Min(scrollY + num2, num3);
				}
				try
				{
					document.Window.ScrollTo(0, scrollY);
				}
				catch
				{
				}
				bool flag = docHeight > num + 50;
				bool flag2 = scrollY >= Math.Max(0, num3 - 2);
				bool flag3 = tickCount - lastHeightChange >= 100;
				if ((flag && flag2 && flag3) || (!flag && flag3))
				{
					timer_0.Stop();
					timer_0.Dispose();
					this._captureTimerFetch = null;
					string text2 = FormNews.ExtractAndClean(document);
					if (onDone != null)
					{
						onDone(text2);
					}
				}
			};
			timer_0.Start();
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00012880 File Offset: 0x00010A80
		private static Timer StopTimer(Timer timer_0)
		{
			if (timer_0 == null)
			{
				return null;
			}
			try
			{
				timer_0.Stop();
			}
			catch
			{
			}
			try
			{
				timer_0.Dispose();
			}
			catch
			{
			}
			return null;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x000128C8 File Offset: 0x00010AC8
		private static string ExtractAndClean(HtmlDocument doc)
		{
			string text = FormNews.ExtractTildaText(doc);
			if (text == null)
			{
				text = "";
			}
			string text2 = "";
			if (doc.Body != null)
			{
				text2 = doc.Body.InnerText ?? "";
			}
			string text3 = ((text2.Length > text.Length) ? text2 : text);
			if (string.IsNullOrWhiteSpace(text3))
			{
				text3 = text2;
			}
			text3 = text3.Replace("\r\n", "\n").Replace("\r", "\n").Replace('\u00a0', ' ');
			return Regex.Replace(FormNews.FilterLines(text3), "\n{3,}", "\n\n").Trim();
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00012974 File Offset: 0x00010B74
		private static string ExtractTildaText(HtmlDocument doc)
		{
			string text = "\r\n(function () {\r\n    var root = document.getElementById('allrecords') || document.body;\r\n\r\n    function norm(s) {\r\n        if (!s) return '';\r\n        s = s.replace(/\\u00A0/g, ' ');\r\n        s = s.replace(/[ \\t]+/g, ' ');\r\n        s = s.replace(/^\\s+|\\s+$/g, '');\r\n        return s;\r\n    }\r\n\r\n    function getText(el) {\r\n        return norm((el.textContent || el.innerText || ''));\r\n    }\r\n\r\n    function hasLiInside(el) {\r\n        try { return el.querySelectorAll && el.querySelectorAll('li').length > 0; }\r\n        catch (e) { return false; }\r\n    }\r\n\r\n    var out = [];\r\n    var last = '';\r\n\r\n    function pushBlock(s) {\r\n        s = norm(s);\r\n        if (!s) return;\r\n        if (s === last) return;\r\n        out.push(s);\r\n        last = s;\r\n    }\r\n\r\n    var selector = 'h1,h2,h3,h4,h5,h6,div.t-title,div.t-name,div.t-descr,div.t-text,div.tn-atom,p,li';\r\n    var nodes = root.querySelectorAll ? root.querySelectorAll(selector) : [];\r\n\r\n    for (var i = 0; i < nodes.length; i++) {\r\n        var el = nodes[i];\r\n        var tag = (el.tagName || '').toLowerCase();\r\n\r\n        if (tag === 'li') {\r\n            var liText = getText(el);\r\n            if (liText) pushBlock('• ' + liText);\r\n            continue;\r\n        }\r\n\r\n        if (tag === 'div' && hasLiInside(el))\r\n            continue;\r\n\r\n        var t = getText(el);\r\n        if (t) pushBlock(t);\r\n    }\r\n\r\n    return out.join('\\n\\n');\r\n})();";
			string text2;
			try
			{
				object obj = doc.InvokeScript("eval", new object[] { text });
				text2 = ((obj != null) ? obj.ToString() : "");
			}
			catch
			{
				text2 = "";
			}
			return text2;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x000129CC File Offset: 0x00010BCC
		private static string FilterLines(string text)
		{
			string[] array = text.Split(new char[] { '\n' });
			StringBuilder stringBuilder = new StringBuilder();
			Regex regex = new Regex("^\\s*news\\s*$", RegexOptions.IgnoreCase);
			Regex regex2 = new Regex("made[\\s\\u00A0]*on[\\s\\u00A0]*tilda", RegexOptions.IgnoreCase);
			Regex regex3 = new Regex("^\\s*made[\\s\\u00A0]*on\\s*$", RegexOptions.IgnoreCase);
			Regex regex4 = new Regex("^\\s*tilda\\s*$", RegexOptions.IgnoreCase);
			bool flag = false;
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text2 = array2[i].Replace('\u00a0', ' ').TrimEnd(Array.Empty<char>());
				string text3 = FormNews.NormalizeLine(text2);
				if (!regex.IsMatch(text3) && !regex2.IsMatch(text3))
				{
					if (regex3.IsMatch(text3))
					{
						flag = true;
					}
					else if (!flag || !string.IsNullOrWhiteSpace(text3))
					{
						if (flag && regex4.IsMatch(text3))
						{
							flag = false;
						}
						else if (!regex4.IsMatch(text3) && !(text3 == "•"))
						{
							stringBuilder.AppendLine(text2);
						}
					}
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00003277 File Offset: 0x00001477
		private static string NormalizeLine(string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return "";
			}
			string_0 = string_0.Replace('\u00a0', ' ').Trim();
			string_0 = Regex.Replace(string_0, "\\s+", " ");
			return string_0;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00012AD4 File Offset: 0x00010CD4
		private static string BuildHtml(string text)
		{
			string text2 = WebUtility.HtmlEncode(text);
			text2 = Regex.Replace(text2, "\\[[\\s\\S]*?\\]", (Match match_0) => "<span class='bracket'>" + match_0.Value + "</span>");
			return "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n<meta charset='utf-8'>\r\n<meta http-equiv='X-UA-Compatible' content='IE=edge' />\r\n<style>\r\n    html, body {\r\n        margin: 0;\r\n        padding: 0;\r\n        background: #161616;\r\n        color: white !important;\r\n\r\n        overflow-x: hidden;\r\n        overflow-y: auto;              /* нужно для работы программного ScrollTo */\r\n\r\n        -ms-overflow-style: none;      /* IE/Edge Legacy: скрыть скроллбар */\r\n        scrollbar-width: none;         /* Firefox: скрыть скроллбар (на будущее) */\r\n\r\n        -ms-user-select: none;\r\n        user-select: none;\r\n    }\r\n\r\n    /* Chrome/Edge Chromium/Safari: скрыть скроллбар (IE проигнорирует) */\r\n    html::-webkit-scrollbar, body::-webkit-scrollbar {\r\n        width: 0;\r\n        height: 0;\r\n    }\r\n\r\n    pre {\r\n        margin: 0;\r\n        box-sizing: border-box;\r\n        padding: 20px;\r\n        padding-right: 8px;\r\n        white-space: pre-wrap;\r\n        word-wrap: break-word;\r\n        font-family: Verdana, Arial, sans-serif !important;\r\n        font-size: 11pt !important;\r\n        line-height: 1.5 !important;\r\n        color: white !important;\r\n    }\r\n    .bracket { color: #00ff66 !important; }\r\n</style>\r\n<script>\r\n(function(){\r\n    // блокируем прокрутку клавишами, чтобы работал только твой кастомный скроллбар\r\n    function cancel(e){\r\n        e = e || window.event;\r\n        if (e.preventDefault) e.preventDefault();\r\n        e.returnValue = false;\r\n        e.cancelBubble = true;\r\n        return false;\r\n    }\r\n    document.onkeydown = function(e){\r\n        e = e || window.event;\r\n        var k = e.keyCode || e.which;\r\n        // Space, PgUp, PgDn, End, Home, arrows\r\n        if (k === 32 || k === 33 || k === 34 || k === 35 || k === 36 ||\r\n            k === 37 || k === 38 || k === 39 || k === 40)\r\n            return cancel(e);\r\n        return true;\r\n    };\r\n})();\r\n</script>\r\n</head>\r\n<body oncontextmenu='return false;' onselectstart='return false;' ondragstart='return false;'>\r\n<pre>" + text2 + "</pre>\r\n</body>\r\n</html>";
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00012B24 File Offset: 0x00010D24
		private int GetDocHeight(WebBrowser wb)
		{
			HtmlDocument document = wb.Document;
			if (document == null || document.Window == null)
			{
				return 0;
			}
			object obj = document.InvokeScript("eval", new object[] { "Math.max(document.body.scrollHeight, document.documentElement.scrollHeight,document.body.offsetHeight, document.documentElement.offsetHeight)" });
			if (!(obj is int))
			{
				return Convert.ToInt32(obj);
			}
			return (int)obj;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00012B80 File Offset: 0x00010D80
		private int GetMaxScroll()
		{
			int docHeight = this.GetDocHeight(this.webBrowser1);
			int num = Math.Max(1, this.webBrowser1.ClientSize.Height);
			return Math.Max(0, docHeight - num);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00012BC0 File Offset: 0x00010DC0
		private void SyncMetrics()
		{
			if (this._mode != FormNews.Mode.ShowingCustom)
			{
				return;
			}
			HtmlDocument document = this.webBrowser1.Document;
			if (!(document == null) && !(document.Window == null))
			{
				int maxScroll = this.GetMaxScroll();
				int num = Math.Max(1, this.webBrowser1.ClientSize.Height);
				int num2 = maxScroll + num;
				this._bar.ContentSize = num2;
				this._bar.ViewportSize = num;
				bool flag;
				float num3 = ((flag = maxScroll > 0) ? 12f : 0f);
				this._rightHost.Visible = flag;
				if (Math.Abs(this._layout.ColumnStyles[1].Width - num3) > 0.1f)
				{
					this._layout.ColumnStyles[1].Width = num3;
					this._layout.PerformLayout();
				}
				if (this._bar.Value > maxScroll)
				{
					this._bar.Value = maxScroll;
				}
				if (this._bar.Value < 0)
				{
					this._bar.Value = 0;
				}
				return;
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000032AE File Offset: 0x000014AE
		private void Bar_ValueChanged(object sender, EventArgs e)
		{
			if (this._mode != FormNews.Mode.ShowingCustom)
			{
				return;
			}
			FormNews.ForceScroll(this.webBrowser1, this._bar.Value);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00012CE0 File Offset: 0x00010EE0
		protected override void OnMouseWheel(MouseEventArgs mouseEventArgs_0)
		{
			if (this._rightHost != null && this._rightHost.Visible)
			{
				this._bar.Value -= Math.Sign(mouseEventArgs_0.Delta) * this._bar.SmallChange;
				return;
			}
			base.OnMouseWheel(mouseEventArgs_0);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00012D34 File Offset: 0x00010F34
		internal void HandleExternalWheel(int wheelDelta)
		{
			if (this._mode != FormNews.Mode.ShowingCustom)
			{
				return;
			}
			if (this._rightHost == null || !this._rightHost.Visible)
			{
				return;
			}
			int num = Math.Sign(wheelDelta) * this._bar.SmallChange;
			int num2 = this._bar.Value - num;
			int maxScroll = this.GetMaxScroll();
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num2 > maxScroll)
			{
				num2 = maxScroll;
			}
			if (this._bar.Value != num2)
			{
				this._bar.Value = num2;
				return;
			}
			FormNews.ForceScroll(this.webBrowser1, num2);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x000032D0 File Offset: 0x000014D0
		private void ScheduleScrollFix(int desiredY)
		{
			this._pendingScrollApply = true;
			this._pendingScrollY = desiredY;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00012DBC File Offset: 0x00010FBC
		private void ApplyScrollFix()
		{
			if (!this._pendingScrollApply)
			{
				return;
			}
			this._pendingScrollApply = false;
			int maxScroll = this.GetMaxScroll();
			int num = this._pendingScrollY;
			if (num < 0)
			{
				num = 0;
			}
			if (num > maxScroll)
			{
				num = maxScroll;
			}
			if (this._bar.Value != num)
			{
				this._bar.Value = num;
			}
			FormNews.ForceScroll(this.webBrowser1, num);
			this._scrollFixTimer = FormNews.StopTimer(this._scrollFixTimer);
			int repeats = 0;
			this._scrollFixTimer = new Timer
			{
				Interval = 120
			};
			this._scrollFixTimer.Tick += delegate(object sender, EventArgs e)
			{
				int repeats2 = repeats;
				repeats = repeats2 + 1;
				FormNews.ForceScroll(this.webBrowser1, this._bar.Value);
				if (repeats >= 3)
				{
					this._scrollFixTimer = FormNews.StopTimer(this._scrollFixTimer);
				}
			};
			this._scrollFixTimer.Start();
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00012E74 File Offset: 0x00011074
		private static void ForceScroll(WebBrowser wb, int int_0)
		{
			HtmlDocument document = wb.Document;
			if (!(document == null) && !(document.Window == null))
			{
				try
				{
					document.InvokeScript("eval", new object[] { "(function(){var y=" + int_0.ToString() + ";if(document.documentElement) document.documentElement.scrollTop=y;if(document.body) document.body.scrollTop=y;window.scrollTo(0,y);})();" });
				}
				catch
				{
				}
				return;
			}
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00012EE4 File Offset: 0x000110E4
		protected override void OnFormClosed(FormClosedEventArgs formClosedEventArgs_0)
		{
			this._captureTimerFetch = FormNews.StopTimer(this._captureTimerFetch);
			this._refreshWatchdog = FormNews.StopTimer(this._refreshWatchdog);
			this._scrollFixTimer = FormNews.StopTimer(this._scrollFixTimer);
			if (this._refreshTimer != null)
			{
				this._refreshTimer.Stop();
				this._refreshTimer.Dispose();
				this._refreshTimer = null;
			}
			if (this._fetchBrowser != null)
			{
				this._fetchBrowser.DocumentCompleted -= this.WebBrowser_Fetch_DocumentCompleted;
				this._fetchBrowser.Dispose();
				this._fetchBrowser = null;
			}
			if (this._wheelFilter != null)
			{
				Application.RemoveMessageFilter(this._wheelFilter);
				this._wheelFilter = null;
			}
			base.OnFormClosed(formClosedEventArgs_0);
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00012F9C File Offset: 0x0001119C
		public static void SetSilent(WebBrowser browser, bool silent)
		{
			IOleServiceProvider oleServiceProvider = browser.ActiveXInstance as IOleServiceProvider;
			if (oleServiceProvider != null)
			{
				Guid guid = new Guid("0002DF05-0000-0000-C000-000000000046");
				Guid guid2 = new Guid("D30C1661-CDAF-11D0-8A3E-00C04FC9E26E");
				object obj;
				oleServiceProvider.QueryService(ref guid, ref guid2, out obj);
				if (obj != null)
				{
					obj.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, obj, new object[] { silent });
				}
			}
		}

		// Token: 0x04000162 RID: 354
		private global::System.ScrollBar _bar;

		// Token: 0x04000163 RID: 355
		private TableLayoutPanel _layout;

		// Token: 0x04000164 RID: 356
		private Panel _rightHost;

		// Token: 0x04000165 RID: 357
		private Panel _barGap;

		// Token: 0x04000166 RID: 358
		private Panel _barRightPad;

		// Token: 0x04000167 RID: 359
		private const int BarRightPadPx = -6;

		// Token: 0x04000168 RID: 360
		private const int BottomClampPx = 0;

		// Token: 0x04000169 RID: 361
		private const int BarGapPx = 0;

		// Token: 0x0400016A RID: 362
		private const int BarWidthPx = 18;

		// Token: 0x0400016B RID: 363
		private const string Url = "https://antia-bot.ru/majestic/news";

		// Token: 0x0400016C RID: 364
		private const int RefreshIntervalMs = 10000;

		// Token: 0x0400016D RID: 365
		private Timer _refreshTimer;

		// Token: 0x0400016E RID: 366
		private Timer _refreshWatchdog;

		// Token: 0x0400016F RID: 367
		private bool _refreshInProgress;

		// Token: 0x04000170 RID: 368
		private string _lastCleanedText = "";

		// Token: 0x04000171 RID: 369
		private WebBrowser _fetchBrowser;

		// Token: 0x04000172 RID: 370
		private Timer _captureTimerFetch;

		// Token: 0x04000173 RID: 371
		private FormNews.Mode _mode;

		// Token: 0x04000174 RID: 372
		private bool _pendingScrollApply;

		// Token: 0x04000175 RID: 373
		private int _pendingScrollY;

		// Token: 0x04000176 RID: 374
		private Timer _scrollFixTimer;

		// Token: 0x04000177 RID: 375
		private FormNews.WheelMessageFilter _wheelFilter;

		// Token: 0x02000019 RID: 25
		private enum Mode
		{
			// Token: 0x0400017B RID: 379
			LoadingSource,
			// Token: 0x0400017C RID: 380
			ShowingCustom
		}

		// Token: 0x0200001A RID: 26
		private sealed class WheelMessageFilter : IMessageFilter
		{
			// Token: 0x060000E1 RID: 225 RVA: 0x0000334B File Offset: 0x0000154B
			public WheelMessageFilter(FormNews owner, WebBrowser browser)
			{
				this._owner = owner;
				this._browser = browser;
			}

			// Token: 0x060000E2 RID: 226 RVA: 0x000131D8 File Offset: 0x000113D8
			public bool PreFilterMessage(ref Message message_0)
			{
				if (message_0.Msg != 522)
				{
					return false;
				}
				if (this._owner == null || this._browser == null)
				{
					return false;
				}
				if (this._owner.IsDisposed || this._browser.IsDisposed)
				{
					return false;
				}
				int wheelDelta = FormNews.WheelMessageFilter.GetWheelDelta(message_0.WParam);
				if (wheelDelta == 0)
				{
					return false;
				}
				IntPtr intPtr = FormNews.WheelMessageFilter.Native.WindowFromCursor();
				if (intPtr == IntPtr.Zero)
				{
					return false;
				}
				if (FormNews.WheelMessageFilter.Native.IsDescendant(this._browser.Handle, intPtr))
				{
					this._owner.HandleExternalWheel(wheelDelta);
					return true;
				}
				return false;
			}

			// Token: 0x060000E3 RID: 227 RVA: 0x00003361 File Offset: 0x00001561
			private static int GetWheelDelta(IntPtr wParam)
			{
				return (int)((short)((wParam.ToInt64() >> 16) & 65535L));
			}

			// Token: 0x0400017D RID: 381
			private const int WM_MOUSEWHEEL = 522;

			// Token: 0x0400017E RID: 382
			private readonly FormNews _owner;

			// Token: 0x0400017F RID: 383
			private readonly WebBrowser _browser;

			// Token: 0x0200001B RID: 27
			private static class Native
			{
				// Token: 0x060000E4 RID: 228
				[DllImport("user32.dll")]
				private static extern bool GetCursorPos(out FormNews.WheelMessageFilter.Native.POINT lpPoint);

				// Token: 0x060000E5 RID: 229
				[DllImport("user32.dll")]
				private static extern IntPtr WindowFromPoint(FormNews.WheelMessageFilter.Native.POINT Point);

				// Token: 0x060000E6 RID: 230
				[DllImport("user32.dll")]
				private static extern IntPtr GetParent(IntPtr hWnd);

				// Token: 0x060000E7 RID: 231 RVA: 0x0001326C File Offset: 0x0001146C
				public static IntPtr WindowFromCursor()
				{
					FormNews.WheelMessageFilter.Native.POINT point;
					if (!FormNews.WheelMessageFilter.Native.GetCursorPos(out point))
					{
						return IntPtr.Zero;
					}
					return FormNews.WheelMessageFilter.Native.WindowFromPoint(point);
				}

				// Token: 0x060000E8 RID: 232 RVA: 0x00013290 File Offset: 0x00011490
				public static bool IsDescendant(IntPtr parent, IntPtr child)
				{
					if (!(parent == IntPtr.Zero) && !(child == IntPtr.Zero))
					{
						IntPtr intPtr = child;
						while (intPtr != IntPtr.Zero)
						{
							if (intPtr == parent)
							{
								return true;
							}
							intPtr = FormNews.WheelMessageFilter.Native.GetParent(intPtr);
						}
						return false;
					}
					return false;
				}

				// Token: 0x0200001C RID: 28
				private struct POINT
				{
					// Token: 0x04000180 RID: 384
					public int int_0;

					// Token: 0x04000181 RID: 385
					public int int_1;
				}
			}
		}
	}
}
