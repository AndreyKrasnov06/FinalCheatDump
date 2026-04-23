using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ns0
{
	// Token: 0x02000072 RID: 114
	internal static class Class43
	{
		// Token: 0x060003B1 RID: 945 RVA: 0x00032B7C File Offset: 0x00030D7C
		static Class43()
		{
			ServicePointManager.Expect100Continue = false;
			ServicePointManager.DefaultConnectionLimit = 10;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			Class43.smethod_0();
			Class43.smethod_1();
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x00004E17 File Offset: 0x00003017
		private static void smethod_0()
		{
			ServicePointManager.FindServicePoint(new Uri("https://antia.space/majestic/")).SetTcpKeepAlive(true, 60000, 10000);
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x00032BD4 File Offset: 0x00030DD4
		private static void smethod_1()
		{
			if (Class43.httpClient_0 != null && DateTime.UtcNow - Class43.dateTime_0 < Class43.timeSpan_0)
			{
				return;
			}
			try
			{
				HttpClient httpClient = Class43.httpClient_0;
				if (httpClient != null)
				{
					httpClient.Dispose();
				}
			}
			catch
			{
			}
			Class43.httpClient_0 = new HttpClient
			{
				BaseAddress = new Uri("https://antia.space/majestic/"),
				Timeout = TimeSpan.FromSeconds(60.0)
			};
			Class43.httpClient_0.DefaultRequestHeaders.Remove(Encoding.UTF8.GetString(GClass2.smethod_3(ref Form1.byte_0, false)));
			Class43.httpClient_0.DefaultRequestHeaders.Add(Encoding.UTF8.GetString(GClass2.smethod_3(ref Form1.byte_0, false)), Encoding.UTF8.GetString(GClass2.smethod_3(ref Form1.byte_1, false)));
			Class43.dateTime_0 = DateTime.UtcNow;
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x00032CC0 File Offset: 0x00030EC0
		private static bool smethod_2()
		{
			bool flag;
			try
			{
				using (Ping ping = new Ping())
				{
					flag = ping.Send("antia.space", 1000).Status == IPStatus.Success;
				}
			}
			catch
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x00032D1C File Offset: 0x00030F1C
		private static async Task<HttpResponseMessage> smethod_3(string string_1, byte[] byte_0)
		{
			int i = 1;
			while (i <= 3)
			{
				int num = 0;
				try
				{
					using (ByteArrayContent byteArrayContent = new ByteArrayContent(byte_0))
					{
						byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
						return await Class43.httpClient_0.PostAsync(string_1, byteArrayContent);
					}
				}
				catch (HttpRequestException obj)
				{
					num = 1;
					goto IL_01EB;
				}
				catch (TaskCanceledException obj)
				{
					num = 2;
					goto IL_01EB;
				}
				goto IL_0155;
				IL_0068:
				num = i;
				i = num + 1;
				continue;
				IL_0155:
				if (num != 2)
				{
					goto IL_0068;
				}
				if (i == 3)
				{
					object obj;
					Exception ex = obj as Exception;
					if (ex == null)
					{
						throw obj;
					}
					ExceptionDispatchInfo.Capture(ex).Throw();
				}
				Class43.smethod_1();
				TaskAwaiter taskAwaiter = Task.Delay(2000).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
				goto IL_0068;
				IL_01EB:
				if (num != 1)
				{
					goto IL_0155;
				}
				if (i == 3)
				{
					object obj;
					Exception ex2 = obj as Exception;
					if (ex2 == null)
					{
						throw obj;
					}
					ExceptionDispatchInfo.Capture(ex2).Throw();
				}
				Class43.smethod_1();
				taskAwaiter = Task.Delay(2000).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
				goto IL_0068;
			}
			throw new Exception("Не удалось отправить запрос после нескольких попыток.");
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x00032D68 File Offset: 0x00030F68
		public static async Task<bool> smethod_4()
		{
			int i = 1;
			while (i <= 3)
			{
				int num = 0;
				try
				{
					byte[] bytes = Encoding.UTF8.GetBytes(Form1.ID);
					GClass2.smethod_1(ref bytes);
					byte[] array = Class5.smethod_0(ref bytes);
					byte[] array2 = GClass2.smethod_3(ref array, true);
					HttpResponseMessage httpResponseMessage = await Class43.smethod_3("jwt", array2);
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
							byte[] array3 = Class5.smethod_1(ref result);
							JObject jobject = JObject.Parse(Encoding.UTF8.GetString(GClass2.smethod_3(ref array3, true)));
							Class43.jtoken_0 = jobject["access_token"];
							Class43.jtoken_1 = jobject["refresh_token"];
							Class65.smethod_2(jobject["settings"]);
							Class23.smethod_0((JObject)jobject["resources"]);
							Class43.task_0 = Task.Run(new Func<Task>(Class43.Class44.class44_0.method_0));
							return true;
						}
						Class43.smethod_8(string.Format("Ошибка получения токенов: {0}", httpResponseMessage2.StatusCode));
					}
					HttpResponseMessage httpResponseMessage2 = null;
					goto IL_02BA;
				}
				catch (Exception obj)
				{
					num = 1;
					goto IL_02BA;
				}
				goto IL_0253;
				IL_028C:
				object obj = null;
				i++;
				continue;
				IL_0253:
				Exception ex = (Exception)obj;
				if (i == 3)
				{
					Class43.smethod_8("Ошибка GetToken: " + ex.Message);
					return false;
				}
				TaskAwaiter taskAwaiter3 = Task.Delay(2000).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
				}
				taskAwaiter3.GetResult();
				goto IL_028C;
				IL_02BA:
				if (num == 1)
				{
					goto IL_0253;
				}
				goto IL_028C;
			}
			return false;
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x00032DA4 File Offset: 0x00030FA4
		public static async Task smethod_5()
		{
			try
			{
				Class61 @class = new Class61
				{
					ID = Form1.ID,
					Key = Class43.jtoken_1.ToString()
				};
				byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@class));
				@class.method_0();
				GClass2.smethod_1(ref bytes);
				byte[] array = Class5.smethod_0(ref bytes);
				ByteArrayContent byteArrayContent = new ByteArrayContent(GClass2.smethod_3(ref array, true));
				byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
				HttpResponseMessage httpResponseMessage = await Class43.httpClient_0.PostAsync("reset", byteArrayContent);
				using (HttpResponseMessage httpResponseMessage2 = httpResponseMessage)
				{
					byteArrayContent.Dispose();
					httpResponseMessage2.EnsureSuccessStatusCode();
					byte[] array2 = await httpResponseMessage2.Content.ReadAsByteArrayAsync();
					GClass2.smethod_1(ref array2);
					byte[] array3 = Class5.smethod_1(ref array2);
					byte[] array4;
					byte[] array5;
					byte[] array6;
					JsonConvert.DeserializeObject<Class62>(Encoding.UTF8.GetString(GClass2.smethod_3(ref array3, true))).method_0(out array4, out array5, out array6);
					if (Encoding.UTF8.GetString(GClass2.smethod_3(ref array4, true)) == "error")
					{
						new FormMessage(Encoding.UTF8.GetString(GClass2.smethod_3(ref array6, true)));
						GClass2.smethod_6(ref array6);
					}
					else
					{
						Form1.Main.Close();
					}
				}
				HttpResponseMessage httpResponseMessage2 = null;
				byteArrayContent = null;
			}
			catch (Exception ex)
			{
				new FormMessage(ex);
			}
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x00032DE0 File Offset: 0x00030FE0
		private static async Task<bool> smethod_6()
		{
			if (Class43.smethod_2())
			{
				try
				{
					byte[] bytes = Encoding.UTF8.GetBytes(Class43.jtoken_1.ToString());
					GClass2.smethod_1(ref bytes);
					byte[] array = Class5.smethod_0(ref bytes);
					byte[] array2 = GClass2.smethod_3(ref array, true);
					TaskAwaiter<HttpResponseMessage> taskAwaiter = Class43.smethod_3("jwt_refresh", array2).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						goto IL_01A3;
					}
					IL_0089:
					HttpResponseMessage result = taskAwaiter.GetResult();
					using (HttpResponseMessage httpResponseMessage = result)
					{
						if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
						{
							TaskAwaiter<byte[]> taskAwaiter2 = httpResponseMessage.Content.ReadAsByteArrayAsync().GetAwaiter();
							if (!taskAwaiter2.IsCompleted)
							{
								await taskAwaiter2;
								TaskAwaiter<byte[]> taskAwaiter3;
								taskAwaiter2 = taskAwaiter3;
								taskAwaiter3 = default(TaskAwaiter<byte[]>);
							}
							byte[] result2 = taskAwaiter2.GetResult();
							GClass2.smethod_1(ref result2);
							byte[] array3 = Class5.smethod_1(ref result2);
							JObject jobject = JObject.Parse(Encoding.UTF8.GetString(GClass2.smethod_3(ref array3, true)));
							Class43.jtoken_0 = jobject["access_token"];
							Class43.jtoken_1 = jobject["refresh_token"];
							return true;
						}
						Class43.smethod_8(string.Format("Ошибка сервера при обновлении токенов: {0}", httpResponseMessage.StatusCode));
						return false;
					}
					IL_01A3:
					await taskAwaiter;
					TaskAwaiter<HttpResponseMessage> taskAwaiter4;
					taskAwaiter = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<HttpResponseMessage>);
					goto IL_0089;
				}
				catch (TaskCanceledException)
				{
					return false;
				}
				catch (Exception ex)
				{
					Class43.smethod_8("Ошибка RefreshToken: " + ex.Message);
					return false;
				}
			}
			return false;
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x00032E1C File Offset: 0x0003101C
		private static async Task smethod_7(CancellationToken cancellationToken_0)
		{
			int num = 5;
			try
			{
				await Task.Delay(TimeSpan.FromMinutes(4.0), cancellationToken_0);
				goto IL_0229;
			}
			catch (TaskCanceledException)
			{
				return;
			}
			goto IL_00A1;
			IL_0229:
			while (!cancellationToken_0.IsCancellationRequested)
			{
				bool flag = false;
				try
				{
					flag = await Class43.smethod_6();
					goto IL_023B;
				}
				catch (Exception)
				{
					goto IL_023B;
				}
				IL_01AD:
				num = 5;
				try
				{
					await Task.Delay(TimeSpan.FromMinutes(4.0), cancellationToken_0);
				}
				catch (TaskCanceledException)
				{
					break;
				}
				continue;
				IL_023B:
				if (flag)
				{
					goto IL_01AD;
				}
				goto IL_00A1;
			}
			return;
			IL_00A1:
			try
			{
				await Task.Delay(TimeSpan.FromSeconds((double)num), cancellationToken_0);
			}
			catch (TaskCanceledException)
			{
				return;
			}
			num = Math.Min(num * 2, 60);
			goto IL_0229;
		}

		// Token: 0x060003BA RID: 954 RVA: 0x00004E38 File Offset: 0x00003038
		private static void smethod_8(string string_1)
		{
			if (Form1.bool_8)
			{
				Form1.smethod_0();
			}
			Form1 main = Form1.Main;
			if (main != null)
			{
				main.Hide();
			}
			new FormMessage("Сетевая ошибка: " + string_1);
			Environment.Exit(0);
		}

		// Token: 0x060003BB RID: 955 RVA: 0x00032E60 File Offset: 0x00031060
		public static async Task smethod_9()
		{
			if (Class43.cancellationTokenSource_0 != null)
			{
				Class43.cancellationTokenSource_0.Cancel();
				try
				{
					if (Class43.task_0 != null)
					{
						await Class43.task_0;
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x04000460 RID: 1120
		private static HttpClient httpClient_0;

		// Token: 0x04000461 RID: 1121
		private static CancellationTokenSource cancellationTokenSource_0 = new CancellationTokenSource();

		// Token: 0x04000462 RID: 1122
		private static Task task_0;

		// Token: 0x04000463 RID: 1123
		private const string string_0 = "https://antia.space/majestic/";

		// Token: 0x04000464 RID: 1124
		public static JToken jtoken_0;

		// Token: 0x04000465 RID: 1125
		private static JToken jtoken_1;

		// Token: 0x04000466 RID: 1126
		private static DateTime dateTime_0 = DateTime.UtcNow;

		// Token: 0x04000467 RID: 1127
		private static readonly TimeSpan timeSpan_0 = TimeSpan.FromMinutes(10.0);

		// Token: 0x02000073 RID: 115
		[CompilerGenerated]
		[Serializable]
		private sealed class Class44
		{
			// Token: 0x060003BE RID: 958 RVA: 0x00004E79 File Offset: 0x00003079
			internal Task method_0()
			{
				return Class43.smethod_7(Class43.cancellationTokenSource_0.Token);
			}

			// Token: 0x04000468 RID: 1128
			public static readonly Class43.Class44 class44_0 = new Class43.Class44();

			// Token: 0x04000469 RID: 1129
			public static Func<Task> func_0;
		}
	}
}
