using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace ns0
{
	// Token: 0x02000086 RID: 134
	internal static class Class50
	{
		// Token: 0x060003F6 RID: 1014 RVA: 0x000352AC File Offset: 0x000334AC
		static Class50()
		{
			Class50.httpClient_0.DefaultRequestHeaders.Remove(Encoding.UTF8.GetString(GClass2.smethod_3(ref Form1.byte_0, false)));
			Class50.httpClient_0.DefaultRequestHeaders.Add(Encoding.UTF8.GetString(GClass2.smethod_3(ref Form1.byte_0, false)), Encoding.UTF8.GetString(GClass2.smethod_3(ref Form1.byte_1, false)));
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x00035348 File Offset: 0x00033548
		public static async Task smethod_0(string string_1)
		{
			try
			{
				if (Class43.jtoken_0 == null)
				{
					new FormMessage("Произошла ошибка во время загрузки: Отсутствует токен.");
					Environment.Exit(0);
				}
				Class50.httpClient_0.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Class43.jtoken_0.ToString());
				Class0<string> @class = new Class0<string>(string_1);
				string text = JsonConvert.SerializeObject(@class);
				byte[] bytes = Encoding.UTF8.GetBytes(text);
				GClass2.smethod_1(ref bytes);
				byte[] array = Class5.smethod_0(ref bytes);
				using (ByteArrayContent byteArrayContent = new ByteArrayContent(GClass2.smethod_3(ref array, true)))
				{
					byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
					HttpResponseMessage httpResponseMessage = await Class50.httpClient_0.PostAsync("", byteArrayContent);
					using (HttpResponseMessage httpResponseMessage2 = httpResponseMessage)
					{
						if (httpResponseMessage2.StatusCode == HttpStatusCode.OK)
						{
							TaskAwaiter<byte[]> taskAwaiter = httpResponseMessage2.Content.ReadAsByteArrayAsync().GetAwaiter();
							if (!taskAwaiter.IsCompleted)
							{
								await taskAwaiter;
								TaskAwaiter<byte[]> taskAwaiter2;
								taskAwaiter = taskAwaiter2;
								taskAwaiter2 = default(TaskAwaiter<byte[]>);
							}
							byte[] result = taskAwaiter.GetResult();
							GClass2.smethod_1(ref result);
							byte[] array2 = Class5.smethod_1(ref result);
							byte[] array3;
							if (!Class23.Data.TryGetValue(@class.job, out array3))
							{
								throw new Form1.GException0("Ошибка. Код 23. Сообщите мне об этом.");
							}
							byte[] array4 = Class5.smethod_2(array3, ref array2);
							Class50.jobject_0 = JObject.Parse(Encoding.UTF8.GetString(GClass2.smethod_3(ref array4, true)));
						}
						else
						{
							Form1.Main.Hide();
							new FormMessage(httpResponseMessage2.StatusCode.ToString());
							Environment.Exit(0);
						}
					}
					HttpResponseMessage httpResponseMessage2 = null;
				}
				ByteArrayContent byteArrayContent = null;
				@class = null;
			}
			catch (TaskCanceledException ex)
			{
				Form1.Main.Hide();
				new FormMessage(ex);
				Environment.Exit(0);
			}
			catch (Exception ex2)
			{
				Form1.Main.Hide();
				new FormMessage(ex2);
				Environment.Exit(0);
			}
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x0003538C File Offset: 0x0003358C
		public static Bitmap smethod_1(string string_1, string string_2)
		{
			JToken jtoken = Class50.jobject_0[string_1];
			string text = (string)((jtoken != null) ? jtoken[string_2] : null);
			if (text == null)
			{
				return null;
			}
			Bitmap bitmap;
			using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(text)))
			{
				bitmap = new Bitmap(memoryStream);
			}
			return bitmap;
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x000353EC File Offset: 0x000335EC
		public static Mat smethod_2(string string_1, string string_2)
		{
			Mat mat;
			try
			{
				JToken jtoken = Class50.jobject_0[string_1];
				string text = (string)((jtoken != null) ? jtoken[string_2] : null);
				if (text != null)
				{
					using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(text)))
					{
						using (Bitmap bitmap = new Bitmap(memoryStream))
						{
							return BitmapConverter.ToMat(bitmap);
						}
					}
				}
				mat = null;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				mat = null;
			}
			return mat;
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x00035488 File Offset: 0x00033688
		public static Rectangle smethod_3(Class76 class76_0, string string_1)
		{
			JToken jtoken = Class50.jobject_0["Coordinates"];
			object obj;
			if (jtoken == null)
			{
				obj = null;
			}
			else
			{
				JToken jtoken2 = jtoken[class76_0.method_5()];
				obj = ((jtoken2 != null) ? jtoken2[string_1] : null);
			}
			JArray jarray = obj as JArray;
			if (jarray != null)
			{
				double[] array = jarray.ToObject<double[]>();
				int num = (int)(array[0] * (double)class76_0.Width);
				int num2 = (int)(array[1] * (double)class76_0.Height);
				int num3 = (int)(array[2] * (double)class76_0.Width) - num;
				int num4 = (int)(array[3] * (double)class76_0.Height) - num2;
				return new Rectangle(num, num2, num3, num4);
			}
			return default(Rectangle);
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x00035520 File Offset: 0x00033720
		public static Rect smethod_4(Class76 class76_0, string string_1)
		{
			JToken jtoken = Class50.jobject_0["Coordinates"];
			object obj;
			if (jtoken == null)
			{
				obj = null;
			}
			else
			{
				JToken jtoken2 = jtoken[class76_0.method_5()];
				obj = ((jtoken2 != null) ? jtoken2[string_1] : null);
			}
			JArray jarray = obj as JArray;
			if (jarray != null)
			{
				double[] array = jarray.ToObject<double[]>();
				int num = (int)(array[0] * (double)class76_0.Width);
				int num2 = (int)(array[1] * (double)class76_0.Height);
				int num3 = (int)(array[2] * (double)class76_0.Width) - num;
				int num4 = (int)(array[3] * (double)class76_0.Height) - num2;
				return new Rect(num, num2, num3, num4);
			}
			return default(Rect);
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x000355B8 File Offset: 0x000337B8
		public static Point smethod_5(Class76 class76_0, string string_1)
		{
			JToken jtoken = Class50.jobject_0["Coordinates"];
			object obj;
			if (jtoken == null)
			{
				obj = null;
			}
			else
			{
				JToken jtoken2 = jtoken[class76_0.method_5()];
				obj = ((jtoken2 != null) ? jtoken2[string_1] : null);
			}
			JArray jarray = obj as JArray;
			if (jarray != null)
			{
				double[] array = jarray.ToObject<double[]>();
				int num = (int)(array[0] * (double)class76_0.Width);
				int num2 = (int)(array[1] * (double)class76_0.Height);
				return new Point(num, num2);
			}
			return default(Point);
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x0003562C File Offset: 0x0003382C
		public static Size smethod_6(Class76 class76_0, string string_1)
		{
			JToken jtoken = Class50.jobject_0["Coordinates"];
			object obj;
			if (jtoken == null)
			{
				obj = null;
			}
			else
			{
				JToken jtoken2 = jtoken[class76_0.method_5()];
				obj = ((jtoken2 != null) ? jtoken2[string_1] : null);
			}
			JArray jarray = obj as JArray;
			if (jarray != null)
			{
				double[] array = jarray.ToObject<double[]>();
				int num = (int)(array[0] * (double)class76_0.Width);
				int num2 = (int)(array[1] * (double)class76_0.Height);
				return new Size(num, num2);
			}
			return default(Size);
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x000356A0 File Offset: 0x000338A0
		public static T smethod_7<T>(string string_1, string string_2, Func<string, T> func_0)
		{
			JToken jtoken = Class50.jobject_0[string_1];
			string text = (string)((jtoken != null) ? jtoken[string_2] : null);
			if (text == null)
			{
				throw new Exception("Данные не найдены в JSON по указанному ключу.");
			}
			byte[] array = Convert.FromBase64String(text);
			string text2 = new Random().Next(1000, 10000).ToString();
			string text3 = "eac_usеrmоde_105466826948" + text2 + ".dll";
			string text4 = Path.Combine(Path.GetTempPath(), text3);
			File.WriteAllBytes(text4, array);
			T t;
			try
			{
				t = func_0(text4);
			}
			finally
			{
				try
				{
					if (File.Exists(text4))
					{
						File.Delete(text4);
					}
				}
				catch (Exception)
				{
				}
			}
			return t;
		}

		// Token: 0x040004C4 RID: 1220
		private static readonly HttpClient httpClient_0 = new HttpClient
		{
			BaseAddress = new Uri("https://antia.space/majestic/resources"),
			Timeout = TimeSpan.FromSeconds(5.0)
		};

		// Token: 0x040004C5 RID: 1221
		private const string string_0 = "https://antia.space/majestic/resources";

		// Token: 0x040004C6 RID: 1222
		private static JObject jobject_0;
	}
}
