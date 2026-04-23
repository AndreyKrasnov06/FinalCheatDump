using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using ns1;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using psClick;

namespace ns0
{
	// Token: 0x02000047 RID: 71
	internal static class Class26
	{
		// Token: 0x06000222 RID: 546 RVA: 0x00015108 File Offset: 0x00013308
		private static Random smethod_0()
		{
			byte[] array = new byte[4];
			using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
			{
				randomNumberGenerator.GetBytes(array);
			}
			return new Random(BitConverter.ToInt32(array, 0));
		}

		// Token: 0x06000223 RID: 547 RVA: 0x0001A3B4 File Offset: 0x000185B4
		public static void smethod_1(Class76 class76_1)
		{
			Class26.bool_0 = true;
			Class26.bool_1 = false;
			Class26.class76_0 = class76_1;
			Class26.cancellationToken_0 = Form1.cancellationToken_0;
			Class26.cancellationToken_0.Register(new Action(Class26.Class27.class27_0.method_0));
			string text = ((Class26.class76_0.Width == 1360) ? "1366x768" : Class26.class76_0.Resolution);
			Class26.rect_0 = Class50.smethod_4(Class26.class76_0, "regionIsFishing");
			Class26.rectangle_0 = Class50.smethod_3(Class26.class76_0, "regionCast");
			Class26.rectangle_1 = Class50.smethod_3(Class26.class76_0, "regionWaitingFish");
			Class26.rectangle_2 = Class50.smethod_3(Class26.class76_0, "regionGame");
			Class26.rectangle_3 = Class50.smethod_3(Class26.class76_0, "regionCamera");
			Class26.rectangle_4 = Class50.smethod_3(Class26.class76_0, "regionSelectAction");
			Class26.rectangle_5 = Class50.smethod_3(Class26.class76_0, "regionTrophy");
			Class26.rectangle_6 = Class50.smethod_3(Class26.class76_0, "regionNameFish");
			Class26.rectangle_8 = Class50.smethod_3(Class26.class76_0, "regionDefaultBait");
			Class26.rect_7 = Class50.smethod_4(Class26.class76_0, "regionUsedBait");
			Class26.rect_1 = Class50.smethod_4(Class26.class76_0, "regionRemoveBait");
			Class26.rect_2 = Class50.smethod_4(Class26.class76_0, "regionListBait");
			Class26.rect_4 = Class50.smethod_4(Class26.class76_0, "regionStatusBar");
			Class26.rect_8 = Class50.smethod_4(Class26.class76_0, "regionMessage");
			Class26.rect_9 = Class50.smethod_4(Class26.class76_0, "regionAnotherBait");
			Class26.rect_5 = Class50.smethod_4(Class26.class76_0, "regionSelectBaggage");
			Class26.rect_6 = Class50.smethod_4(Class26.class76_0, "regionBaggage");
			Class26.rectangle_7 = Class50.smethod_3(Class26.class76_0, "regionStorage");
			Class26.rectangle_9 = Class50.smethod_3(Class26.class76_0, "regionStorageGround");
			Class26.rectangle_10 = Class50.smethod_3(Class26.class76_0, "regionStorageTrunk");
			Class26.size_0 = Class50.smethod_6(Class26.class76_0, "textMessage");
			Class26.point_0 = Class50.smethod_5(Class26.class76_0, "mouseSelectPickUp");
			Class26.point_1 = Class50.smethod_5(Class26.class76_0, "mouseSelectBack");
			Class26.rectangle_3 = new Rectangle(0, Class26.class76_0.Height - Class26.class76_0.Height / 4, Class26.class76_0.Width, Class26.class76_0.Height / 4);
			for (int i = 0; i < Class26.mat_13.Length; i++)
			{
				Class26.mat_13[i] = Class50.smethod_2("Icon", Class26.string_0[i]);
			}
			Class26.bitmap_0 = Class50.smethod_1("Cast", "green");
			Class26.bitmap_1 = Class50.smethod_1("Cast", "white");
			Class26.bitmap_2 = Class50.smethod_1("Game", "game");
			Class26.bitmap_3 = Class50.smethod_1("Window", "window_new");
			Class26.mat_12[0] = Class50.smethod_2(text, "inventory");
			Class26.mat_12[1] = Class50.smethod_2(text, "ground");
			Class26.mat_12[2] = Class50.smethod_2(text, "transport");
			Class26.mat_4 = Class50.smethod_2(text, "smallTrunk");
			Class26.mat_5 = Class50.smethod_2(text, "bigTrunk");
			Class26.mat_6 = Class50.smethod_2(text, "smallInventory");
			Class26.mat_7 = Class50.smethod_2(text, "bigInventory");
			for (int j = 0; j < Class26.bitmap_5.Length; j++)
			{
				Class26.bitmap_5[j] = Class50.smethod_1("Waiting", "waiting_" + j.ToString());
			}
			Class26.bitmap_6[0] = Class50.smethod_1("CatchType", "modest");
			Class26.bitmap_6[1] = Class50.smethod_1("CatchType", "good");
			Class26.bitmap_6[2] = Class50.smethod_1("CatchType", "record");
			Class26.bitmap_6[3] = Class50.smethod_1("CatchType", "trophy");
			Class26.mat_1 = Class50.smethod_2(text, "overweight");
			Class26.mat_2 = Class50.smethod_2(text, "hunger");
			Class26.mat_3 = Class50.smethod_2(text, "thirst");
			Class26.mat_8 = Class50.smethod_2(text, "message_green");
			Class26.mat_10 = Class50.smethod_2(text, "message_orange");
			Class26.mat_9 = Class50.smethod_2(text, "message_red");
			Class26.mat_11 = Class50.smethod_2(text, "remove_bait");
			Class26.list_0 = Class50.smethod_7<List<BaseSymbolStruct>>("SymbolBase", "message_base", new Func<string, List<BaseSymbolStruct>>(ReadText.LoadSymbolBase));
			Class26.list_1 = Class50.smethod_7<List<BaseSymbolStruct>>(text, "name_base", new Func<string, List<BaseSymbolStruct>>(ReadText.LoadSymbolBase));
			Class26.dictionary_0 = FormFishMain.fishContent.GetAllChecked();
			try
			{
				Class26.smethod_2();
			}
			catch (Form1.GException0 gexception)
			{
				Form1.Main.method_11();
				if (gexception.HasMessage)
				{
					Form1.smethod_0();
					new FormMessage(gexception);
				}
			}
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0001A8A0 File Offset: 0x00018AA0
		private static void smethod_2()
		{
			Class65.smethod_0(Form1.Main.string_0, Form1.Main.genum0_0, Form1.Main.keys_0, Form1.Main.genum0_1, Form1.Main.keys_1);
			Class26.smethod_7(true);
			Class26.smethod_8();
			Class26.smethod_16();
			if (!FormFishing.IsTrunk)
			{
				Class26.smethod_48(1000.0, 0.0);
			}
			Class26.smethod_5();
			Class46.smethod_6(Keys.E, null, false);
			Class26.bool_2 = !FormFishing.IsReuseBait && !FormFishing.IsAnotherBait;
			Class26.bool_3 = false;
			Class26.bool_4 = false;
			Class26.int_2 = 0;
			new Thread(new ThreadStart(Class26.smethod_43)).Start();
			while (!Class26.cancellationToken_0.IsCancellationRequested)
			{
				if (!Class26.smethod_17())
				{
					Class26.smethod_8();
					Class26.smethod_16();
					if (!FormFishing.IsTrunk)
					{
						Class26.smethod_48(1000.0, 0.0);
					}
					Class26.smethod_6();
					Class46.smethod_6(Keys.E, null, false);
					Class26.int_2 = 0;
				}
				Class26.smethod_7(false);
				if (Class26.bool_4 && Class26.bool_0)
				{
					Class26.bool_4 = false;
					new Thread(new ThreadStart(Class26.smethod_43)).Start();
				}
				if (Class26.int_2 > 6 && (FormFishing.IsReuseBait || FormFishing.IsAnotherBait))
				{
					Class26.smethod_15();
					Class26.int_2 = 0;
				}
				Class26.smethod_21();
				Class26.smethod_48(1000.0, 0.0);
				Class26.smethod_44();
				Class26.smethod_25();
				if (FormFishing.IsShore)
				{
					Class26.smethod_26();
				}
				else
				{
					Class26.smethod_27();
				}
				if (!Class26.smethod_17())
				{
					Class26.smethod_8();
					Class26.smethod_16();
					if (!FormFishing.IsTrunk)
					{
						Class26.smethod_48(1000.0, 0.0);
					}
					Class26.smethod_6();
					Class46.smethod_6(Keys.E, null, false);
					Class26.int_2 = 0;
				}
				else
				{
					Class26.int_2++;
					if (Class26.smethod_40())
					{
						Class26.smethod_44();
					}
					else
					{
						Class26.smethod_48(2500.0, 3500.0);
					}
				}
			}
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0001AAB8 File Offset: 0x00018CB8
		private static bool smethod_3()
		{
			bool flag;
			using (Mat mat = Class40.smethod_4(Class26.class76_0, Class26.rect_8))
			{
				Point point;
				flag = Class40.smethod_17(Class26.mat_10, 0.85, false, out point, mat) || Class40.smethod_17(Class26.mat_8, 0.85, false, out point, mat) || Class40.smethod_17(Class26.mat_9, 0.85, false, out point, mat);
			}
			return flag;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0001AB40 File Offset: 0x00018D40
		private static bool smethod_4()
		{
			while (!Class26.cancellationToken_0.IsCancellationRequested && Class26.smethod_3())
			{
				Class26.smethod_48(100.0, 300.0);
			}
			if (Class26.cancellationToken_0.IsCancellationRequested)
			{
				throw new Form1.GException0();
			}
			return true;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000401D File Offset: 0x0000221D
		private static void smethod_5()
		{
			if (Class26.smethod_4())
			{
				Class26.mat_15 = Class40.smethod_4(Class26.class76_0, Class26.rect_7);
			}
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0001AB90 File Offset: 0x00018D90
		private static void smethod_6()
		{
			if (Class26.bool_2)
			{
				return;
			}
			Point point;
			if (Class26.smethod_4() && Class40.smethod_13(Class26.mat_15, Class26.rect_7, 0.8, false, out point, Class26.class76_0))
			{
				return;
			}
			if (Class26.smethod_17())
			{
				Class56.smethod_8(Class26.class76_0, Class26.random_0.Next(40, 60), Class26.random_0.Next(10, 30), Class26.rect_7);
				if (Class26.smethod_4() && Class40.smethod_14(Class26.mat_11, Class26.rect_1, 0.8, false, out point, Class26.class76_0, Class26.cancellationToken_0, 3000, 100, false))
				{
					Point point2;
					if (Class26.smethod_4() && Class40.smethod_14(Class26.mat_15, Class26.rect_2, 0.8, false, out point2, Class26.class76_0, Class26.cancellationToken_0, 3000, 100, false))
					{
						if (!Class26.smethod_17())
						{
							throw new Form1.GException0("Персонаж не находится в интерфейсе рыбалки. Взаимодействие с приманкой невозможно.");
						}
						Class56.smethod_7(Class26.class76_0, Class26.random_0.Next(40, 60), Class26.random_0.Next(10, 30), new Rectangle(Class26.rect_2.X + point2.X, Class26.rect_2.Y + point2.Y, Class26.mat_15.Width, Class26.mat_15.Height));
						if (Class26.smethod_4() && !Class40.smethod_14(Class26.mat_15, Class26.rect_7, 0.8, false, out point, Class26.class76_0, Class26.cancellationToken_0, 3000, 100, false))
						{
							throw new Form1.GException0("Приманка не была успешно надета.");
						}
					}
					else
					{
						if (!Class26.smethod_17())
						{
							throw new Form1.GException0("Персонаж не находится в интерфейсе рыбалки. Взаимодействие с приманкой невозможно.");
						}
						Class26.Enum3 @enum = Class26.enum3_0;
						if (@enum != Class26.Enum3.const_0)
						{
							if (@enum != Class26.Enum3.const_1)
							{
							}
							Class56.smethod_8(Class26.class76_0, Class26.random_0.Next(40, 60), Class26.random_0.Next(10, 30), Class26.rect_9);
							Class26.enum3_0 = Class26.Enum3.const_0;
							return;
						}
						Class56.smethod_7(Class26.class76_0, Class26.random_0.Next(40, 60), Class26.random_0.Next(10, 30), Class26.rectangle_8);
						Class26.enum3_0 = Class26.Enum3.const_1;
						return;
					}
				}
				else
				{
					Class26.bool_2 = true;
				}
				return;
			}
			throw new Form1.GException0("Персонаж не находится в интерфейсе рыбалки. Взаимодействие с приманкой невозможно.");
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0001ADD4 File Offset: 0x00018FD4
		private static void smethod_7(bool bool_5 = false)
		{
			using (Mat mat = Class40.smethod_4(Class26.class76_0, Class26.rect_4))
			{
				Point point;
				if (FormFishing.IsOverWeight && Class40.smethod_17(Class26.mat_1, 0.9, false, out point, mat))
				{
					if (bool_5 && FormFishing.Main.comboBox2.SelectedItem != "отпускать рыбу")
					{
						throw new Form1.GException0("У вас избыточный вес в инвентаре.");
					}
					if (FormFishing.IsOverWeight && !Class26.bool_1)
					{
						string selectedItem = FormFishing.Main.comboBox2.SelectedItem;
						if (!(selectedItem == "отпускать рыбу"))
						{
							if (selectedItem == "остановиться")
							{
								Class26.smethod_9();
								throw new Form1.GException0("У вас избыточный вес в инвентаре, работа бота остановлена.");
							}
							if (selectedItem == "закрыть игру")
							{
								Class26.smethod_9();
								Class26.smethod_10();
								throw new Form1.GException0("У вас избыточный вес в инвентаре, окно игры закрыто.");
							}
							if (selectedItem == "выключить компьютер")
							{
								Class26.smethod_9();
								Class26.smethod_10();
								Form1.bool_10 = true;
								Form1.Main.Close();
							}
						}
						else
						{
							Class26.bool_1 = true;
						}
					}
				}
				if (FormFishing.IsHandleNeeds && Class26.bool_0 && (Class26.bool_4 || Class40.smethod_17(Class26.mat_2, 0.8, false, out point, mat) || Class40.smethod_17(Class26.mat_3, 0.8, false, out point, mat)))
				{
					Class26.smethod_9();
					using (Class20 @class = new Class20(Class26.class76_0, Class26.cancellationToken_0))
					{
						Class26.bool_0 = @class.method_2();
					}
					if (!bool_5)
					{
						Class26.smethod_8();
						Class26.smethod_16();
						if (!FormFishing.IsTrunk)
						{
							Class26.smethod_48(2000.0, 2200.0);
						}
						Class26.smethod_6();
						Class46.smethod_6(Keys.E, null, false);
						Class26.int_2 = 0;
					}
				}
			}
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000403A File Offset: 0x0000223A
		private static void smethod_8()
		{
			if (Class26.smethod_17())
			{
				return;
			}
			Class46.smethod_6(Keys.E, Class26.class76_0, false);
			Class26.smethod_14();
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0001AFDC File Offset: 0x000191DC
		private static void smethod_9()
		{
			Class26.smethod_48(1000.0, 1500.0);
			if (!Class26.smethod_17())
			{
				return;
			}
			Class46.smethod_6(Keys.Escape, Class26.class76_0, false);
			Class26.smethod_48(1000.0, 0.0);
			if (Class26.smethod_17())
			{
				Class26.smethod_48(1000.0, 2000.0);
				Class46.smethod_6(Keys.Escape, Class26.class76_0, false);
				Class26.smethod_48(4000.0, 4200.0);
				if (Class26.smethod_17())
				{
					throw new Form1.GException0("Персонаж застрял в интерфейсе рыбалки. Игра не реагирует на кнопку [ESC].");
				}
			}
			else
			{
				Class26.smethod_48(3000.0, 3200.0);
			}
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0001B098 File Offset: 0x00019298
		private static void smethod_10()
		{
			Class46.smethod_8(Keys.LMenu, null, false);
			Class26.smethod_48(500.0, 1000.0);
			Class46.smethod_6(Keys.F4, null, false);
			Class26.smethod_48(500.0, 1000.0);
			Class46.smethod_9(Keys.LMenu, null, false, true);
			Class26.smethod_48(1500.0, 2454.0);
			Class46.smethod_6(Keys.Return, null, false);
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0001B118 File Offset: 0x00019318
		private static void smethod_11()
		{
			if (Class26.smethod_4())
			{
				Class26.mat_15 = Class40.smethod_4(Class26.class76_0, Class26.rect_7);
			}
			if (!Class26.smethod_17())
			{
				throw new Form1.GException0("Персонаж не находится в интерфейсе рыбалки. Взаимодействие с приманкой невозможно.");
			}
			Class56.smethod_26(Class26.rect_7, Class26.class76_0, true);
			Class56.smethod_21(Class26.random_0.Next(40, 60), new Point(Class26.rect_1.X, Class26.rect_1.Y), Class26.class76_0, 100);
			Point point;
			if (!Class26.smethod_4() || !Class40.smethod_14(Class26.mat_11, Class26.rect_1, 0.8, false, out point, Class26.class76_0, Class26.cancellationToken_0, 3000, 100, false))
			{
				Class56.smethod_21(Class26.random_0.Next(40, 60), new Point(Class26.rect_1.X, Class26.rect_1.Y), Class26.class76_0, 100);
				Class26.bool_2 = true;
				Class26.smethod_13();
				return;
			}
			Class26.smethod_48(100.0, 500.0);
			Class56.smethod_7(Class26.class76_0, Class26.random_0.Next(40, 60), Class26.random_0.Next(10, 30), new Rectangle(Class26.rect_1.X + point.X, Class26.rect_1.Y + point.Y, Class26.mat_11.Width, Class26.mat_11.Height));
			Point point2;
			if (Class26.smethod_4() && !Class40.smethod_14(Class26.mat_15, Class26.rect_7, 0.8, false, out point2, Class26.class76_0, Class26.cancellationToken_0, 3000, 100, true))
			{
				throw new Form1.GException0("Приманка не была успешно снята.");
			}
			Class26.smethod_48(800.0, 1000.0);
			if (!Class26.smethod_17())
			{
				throw new Form1.GException0("Персонаж не находится в интерфейсе рыбалки. Взаимодействие с приманкой невозможно.");
			}
			Class56.smethod_8(Class26.class76_0, Class26.random_0.Next(40, 60), Class26.random_0.Next(10, 30), Class26.rect_7);
			if (!Class26.smethod_4() || !Class40.smethod_14(Class26.mat_11, Class26.rect_1, 0.8, false, out point2, Class26.class76_0, Class26.cancellationToken_0, 3000, 100, false))
			{
				throw new Form1.GException0("Не удалось открыть меню выбора приманки");
			}
			if (Class26.smethod_4() && Class40.smethod_14(Class26.mat_15, Class26.rect_2, 0.8, false, out point, Class26.class76_0, Class26.cancellationToken_0, 3000, 100, false))
			{
				Class26.smethod_48(100.0, 500.0);
				Class56.smethod_7(Class26.class76_0, Class26.random_0.Next(40, 60), Class26.random_0.Next(10, 30), new Rectangle(Class26.rect_2.X + point.X, Class26.rect_2.Y + point.Y, Class26.mat_15.Width, Class26.mat_15.Height));
				if (Class26.smethod_4() && !Class40.smethod_14(Class26.mat_15, Class26.rect_7, 0.8, false, out point2, Class26.class76_0, Class26.cancellationToken_0, 3000, 100, false))
				{
					throw new Form1.GException0("Приманка не была успешно надета.");
				}
			}
			else
			{
				Class26.smethod_12(true);
			}
			Class26.smethod_8();
			if (!FormFishing.IsTrunk)
			{
				Class26.smethod_48(2000.0, 2200.0);
			}
			if (Class26.smethod_17())
			{
				Class46.smethod_6(Keys.E, Class26.class76_0, false);
				return;
			}
			throw new Form1.GException0("Персонаж не находится в интерфейсе рыбалки.");
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0001B4AC File Offset: 0x000196AC
		private static void smethod_12(bool bool_5 = false)
		{
			if (!bool_5)
			{
				if (Class26.smethod_4())
				{
					Class26.mat_15 = Class40.smethod_4(Class26.class76_0, Class26.rect_7);
				}
				if (!Class26.smethod_17())
				{
					throw new Form1.GException0("Персонаж не находится в интерфейсе рыбалки. Взаимодействие с приманкой невозможно.");
				}
				Class56.smethod_8(Class26.class76_0, Class26.random_0.Next(40, 60), Class26.random_0.Next(10, 30), Class26.rect_7);
				Class56.smethod_21(Class26.random_0.Next(40, 60), new Point(Class26.rect_1.X, Class26.rect_1.Y), Class26.class76_0, 100);
			}
			Point point;
			if (!Class26.smethod_4() || !Class40.smethod_14(Class26.mat_11, Class26.rect_1, 0.8, false, out point, Class26.class76_0, Class26.cancellationToken_0, 3000, 100, false))
			{
				Class56.smethod_21(Class26.random_0.Next(40, 60), new Point(Class26.rect_1.X, Class26.rect_1.Y), Class26.class76_0, 100);
				Class26.bool_2 = true;
				Class26.smethod_13();
				return;
			}
			Point point2;
			if (Class26.smethod_4() && Class40.smethod_14(Class26.mat_15, Class26.rect_2, 0.8, false, out point2, Class26.class76_0, Class26.cancellationToken_0, 3000, 100, false))
			{
				int num = Class26.rect_2.Y + point2.Y + Class26.rect_7.Height * 2;
				if (!Class26.smethod_17())
				{
					throw new Form1.GException0("Персонаж не находится в интерфейсе рыбалки. Взаимодействие с приманкой невозможно.");
				}
				if (num <= Class26.rect_2.Bottom)
				{
					Class26.smethod_48(100.0, 500.0);
					Class56.smethod_7(Class26.class76_0, Class26.random_0.Next(40, 60), Class26.random_0.Next(10, 30), Class26.rectangle_8);
					Class26.enum3_0 = Class26.Enum3.const_1;
				}
				else
				{
					Class26.smethod_48(100.0, 500.0);
					Class56.smethod_8(Class26.class76_0, Class26.random_0.Next(40, 60), Class26.random_0.Next(10, 30), Class26.rect_9);
					Class26.enum3_0 = Class26.Enum3.const_0;
				}
			}
			else
			{
				if (!Class26.smethod_17())
				{
					throw new Form1.GException0("Персонаж не находится в интерфейсе рыбалки. Взаимодействие с приманкой невозможно.");
				}
				Class26.Enum3 @enum = Class26.enum3_0;
				if (@enum != Class26.Enum3.const_0)
				{
					if (@enum != Class26.Enum3.const_1)
					{
					}
					Class26.smethod_48(100.0, 500.0);
					Class56.smethod_8(Class26.class76_0, Class26.random_0.Next(40, 60), Class26.random_0.Next(10, 30), Class26.rect_9);
					Class26.enum3_0 = Class26.Enum3.const_0;
				}
				else
				{
					Class26.smethod_48(100.0, 500.0);
					Class56.smethod_7(Class26.class76_0, Class26.random_0.Next(40, 60), Class26.random_0.Next(10, 30), Class26.rectangle_8);
					Class26.enum3_0 = Class26.Enum3.const_1;
				}
			}
			Class26.smethod_8();
			if (!FormFishing.IsTrunk)
			{
				Class26.smethod_48(2000.0, 2200.0);
			}
			if (Class26.smethod_17())
			{
				Class46.smethod_6(Keys.E, Class26.class76_0, false);
				return;
			}
			throw new Form1.GException0("Персонаж не находится в интерфейсе рыбалки.");
		}

		// Token: 0x0600022F RID: 559 RVA: 0x0001B7D8 File Offset: 0x000199D8
		private static void smethod_13()
		{
			Class26.smethod_9();
			Class26.smethod_8();
			Class26.smethod_16();
			if (!FormFishing.IsTrunk)
			{
				Class26.smethod_48(2000.0, 2200.0);
			}
			if (!Class26.smethod_17())
			{
				throw new Form1.GException0("Персонаж не находится в интерфейсе рыбалки.");
			}
			Class46.smethod_6(Keys.E, Class26.class76_0, false);
		}

		// Token: 0x06000230 RID: 560 RVA: 0x0001B834 File Offset: 0x00019A34
		private static void smethod_14()
		{
			for (int i = 0; i < 3; i++)
			{
				Stopwatch stopwatch = Stopwatch.StartNew();
				while (stopwatch.Elapsed.TotalSeconds <= 3.0 && !Class26.smethod_17())
				{
					Class26.smethod_48(100.0, 300.0);
				}
				stopwatch.Stop();
				if (Class26.smethod_17())
				{
					return;
				}
				if (i != 0)
				{
					if (i != 1)
					{
						throw new Form1.GException0("Вы находитесь за пределами зоны рыбалки.");
					}
					Class46.smethod_8(Keys.W, Class26.class76_0, false);
					Class26.smethod_48(150.0, 0.0);
					Class46.smethod_9(Keys.W, Class26.class76_0, false, true);
					Class26.smethod_48(300.0, 500.0);
					Class46.smethod_6(Keys.E, Class26.class76_0, false);
				}
				else
				{
					Class46.smethod_6(Keys.E, Class26.class76_0, false);
				}
			}
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0001B920 File Offset: 0x00019B20
		private static void smethod_15()
		{
			Class26.smethod_48(1000.0, 1500.0);
			if (!Class26.smethod_17())
			{
				throw new Form1.GException0("Персонаж не находится в интерфейсе рыбалки.");
			}
			Class46.smethod_6(Keys.Escape, Class26.class76_0, false);
			Class26.smethod_48(1500.0, 2000.0);
			if (Class26.bool_2)
			{
				Class26.smethod_13();
				return;
			}
			if (FormFishing.IsReuseBait)
			{
				Class26.smethod_11();
				return;
			}
			if (FormFishing.IsAnotherBait)
			{
				Class26.smethod_12(false);
			}
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0001B9A4 File Offset: 0x00019BA4
		private static void smethod_16()
		{
			Point[] array;
			if (Class40.smethod_18(2, 1, Class26.bitmap_0, -1, out array, Class26.rectangle_0, 30, 100, Class26.class76_0))
			{
				return;
			}
			if (Class26.bool_3)
			{
				Class26.smethod_48(2000.0, 3000.0);
				return;
			}
			Point point;
			if (FormFishing.IsTrunk && !Class40.smethod_13(Class26.mat_4, Class26.rect_6, 0.8, false, out point, Class26.class76_0))
			{
				Class56.smethod_8(Class26.class76_0, Class26.random_0.Next(40, 60), Class26.random_0.Next(10, 30), Class26.rect_6);
				Point point2;
				if (Class40.smethod_14(Class26.mat_5, Class26.rect_5, 0.8, false, out point2, Class26.class76_0, Class26.cancellationToken_0, 3000, 100, false))
				{
					Class56.smethod_7(Class26.class76_0, Class26.random_0.Next(40, 60), Class26.random_0.Next(10, 30), new Rectangle(Class26.rect_5.X + point2.X, Class26.rect_5.Y + point2.Y, Class26.mat_5.Width, Class26.mat_5.Height));
					Class40.smethod_14(Class26.mat_4, Class26.rect_6, 0.8, false, out point, Class26.class76_0, Class26.cancellationToken_0, 3000, 100, false);
				}
				else if (Class40.smethod_14(Class26.mat_7, Class26.rect_5, 0.8, false, out point2, Class26.class76_0, Class26.cancellationToken_0, 3000, 100, false))
				{
					Class56.smethod_7(Class26.class76_0, Class26.random_0.Next(40, 60), Class26.random_0.Next(10, 30), new Rectangle(Class26.rect_5.X + point2.X, Class26.rect_5.Y + point2.Y, Class26.mat_7.Width, Class26.mat_7.Height));
					Class26.bool_3 = true;
					Class40.smethod_14(Class26.mat_6, Class26.rect_6, 0.8, false, out point, Class26.class76_0, Class26.cancellationToken_0, 3000, 100, false);
				}
			}
			else if (!FormFishing.IsTrunk && Class40.smethod_13(Class26.mat_4, Class26.rect_6, 0.8, false, out point, Class26.class76_0))
			{
				FormFishing.Main.method_1(true);
			}
			Class26.smethod_48(1000.0, 0.0);
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0001BC28 File Offset: 0x00019E28
		private static bool smethod_17()
		{
			if (Class26.cancellationToken_0.IsCancellationRequested)
			{
				throw new Form1.GException0();
			}
			bool flag;
			using (Mat mat = Class40.smethod_4(Class26.class76_0, Class26.rect_6))
			{
				Point point;
				flag = Class40.smethod_17(Class26.mat_6, 0.8, false, out point, mat) || Class40.smethod_17(Class26.mat_4, 0.8, false, out point, mat);
			}
			return flag;
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0001BCA8 File Offset: 0x00019EA8
		private static void smethod_18()
		{
			Class26.smethod_48(1000.0, 1500.0);
			if (Class26.smethod_17())
			{
				Class46.smethod_6(Keys.Escape, Class26.class76_0, false);
				Class26.smethod_48(3000.0, 3500.0);
				if (!Class26.bool_2 && FormFishing.IsReuseBait)
				{
					Class26.mat_15 = BitmapConverter.ToMat(Class40.smethod_6(Class26.class76_0, Class26.rect_7));
					if (!Class26.smethod_17())
					{
						throw new Form1.GException0();
					}
					Class56.smethod_26(Class26.rect_7, Class26.class76_0, true);
					Class26.smethod_48(800.0, 1000.0);
					Point point;
					if (Class40.smethod_14(Class26.mat_11, Class26.rect_1, 0.8, false, out point, Class26.class76_0, Class26.cancellationToken_0, 2000, 100, false))
					{
						if (!Class26.smethod_17())
						{
							throw new Form1.GException0();
						}
						Class56.smethod_26(Class26.rect_1, Class26.class76_0, true);
						Class26.smethod_48(1000.0, 1500.0);
						if (!Class26.smethod_17())
						{
							throw new Form1.GException0();
						}
						Class56.smethod_26(Class26.rect_7, Class26.class76_0, true);
						Class26.smethod_48(800.0, 1000.0);
						Point point2;
						if (Class40.smethod_14(Class26.mat_15, Class26.rect_2, 0.8, false, out point2, Class26.class76_0, Class26.cancellationToken_0, 5000, 100, false))
						{
							point = new Point
							{
								X = Class26.rect_2.X + point2.X,
								Y = Class26.rect_2.Y + point2.Y
							};
							Point point3 = point;
							Size size = new Size
							{
								Width = Class26.mat_15.Width,
								Height = Class26.mat_15.Height
							};
							if (!Class26.smethod_17())
							{
								throw new Form1.GException0();
							}
							Class56.smethod_27(point3, size, Class26.class76_0, true);
						}
						else
						{
							if (Class26.cancellationToken_0.IsCancellationRequested)
							{
								return;
							}
							if (!Class26.smethod_17())
							{
								throw new Form1.GException0();
							}
							Class56.smethod_25(Class26.rectangle_8, Class26.class76_0, true);
							Class26.smethod_48(400.0, 0.0);
							Class26.mat_15 = BitmapConverter.ToMat(Class40.smethod_6(Class26.class76_0, Class26.rect_7));
						}
						Class26.smethod_48(400.0, 1000.0);
						if (Class26.smethod_17())
						{
							Class46.smethod_6(Keys.E, Class26.class76_0, false);
							return;
						}
						throw new Form1.GException0();
					}
					else
					{
						if (Class26.cancellationToken_0.IsCancellationRequested)
						{
							return;
						}
						Class26.bool_2 = true;
					}
				}
				if (!Class26.bool_2 && FormFishing.IsAnotherBait)
				{
					Class26.mat_15 = BitmapConverter.ToMat(Class40.smethod_6(Class26.class76_0, Class26.rect_7));
					if (!Class26.smethod_17())
					{
						throw new Form1.GException0();
					}
					Class56.smethod_26(Class26.rect_7, Class26.class76_0, true);
					Class26.smethod_48(800.0, 1000.0);
					Point point;
					if (Class40.smethod_14(Class26.mat_11, Class26.rect_1, 0.8, false, out point, Class26.class76_0, Class26.cancellationToken_0, 2000, 100, false))
					{
						Point point4;
						if (Class40.smethod_14(Class26.mat_15, Class26.rect_2, 0.8, false, out point4, Class26.class76_0, Class26.cancellationToken_0, 5000, 100, false))
						{
							int num = Class26.rect_2.Y + point4.Y + Class26.rect_7.Height * 2;
							if (!Class26.smethod_17())
							{
								throw new Form1.GException0();
							}
							if (num <= Class26.rect_2.Bottom)
							{
								Class56.smethod_25(Class26.rectangle_8, Class26.class76_0, true);
								Class26.enum3_0 = Class26.Enum3.const_1;
							}
							else
							{
								Class56.smethod_26(Class26.rect_9, Class26.class76_0, true);
								Class26.enum3_0 = Class26.Enum3.const_0;
							}
							Class26.smethod_48(400.0, 0.0);
							Class26.mat_15 = BitmapConverter.ToMat(Class40.smethod_6(Class26.class76_0, Class26.rect_7));
						}
						else
						{
							if (Class26.cancellationToken_0.IsCancellationRequested)
							{
								return;
							}
							if (!Class26.smethod_17())
							{
								throw new Form1.GException0();
							}
							Class26.Enum3 @enum = Class26.enum3_0;
							if (@enum != Class26.Enum3.const_0)
							{
								if (@enum != Class26.Enum3.const_1)
								{
								}
								Class56.smethod_26(Class26.rect_9, Class26.class76_0, true);
								Class26.enum3_0 = Class26.Enum3.const_0;
							}
							else
							{
								Class56.smethod_25(Class26.rectangle_8, Class26.class76_0, true);
								Class26.enum3_0 = Class26.Enum3.const_1;
							}
							Class26.mat_15 = BitmapConverter.ToMat(Class40.smethod_6(Class26.class76_0, Class26.rect_7));
						}
						Class26.smethod_48(400.0, 1000.0);
						if (Class26.smethod_17())
						{
							Class46.smethod_6(Keys.E, Class26.class76_0, false);
							return;
						}
						throw new Form1.GException0();
					}
					else
					{
						if (Class26.cancellationToken_0.IsCancellationRequested)
						{
							return;
						}
						Class26.bool_2 = true;
					}
				}
				if (Class26.bool_2)
				{
					if (Class26.smethod_17())
					{
						Class46.smethod_6(Keys.Escape, Class26.class76_0, false);
					}
					Class26.smethod_48(5000.0, 6000.0);
					if (!Class26.smethod_17())
					{
						Class46.smethod_6(Keys.E, Class26.class76_0, false);
					}
					while (!Class26.smethod_17())
					{
						Class26.smethod_48(100.0, 0.0);
					}
					Point point;
					if (FormFishing.IsTrunk && !Class40.smethod_13(Class26.mat_4, Class26.rect_6, 0.8, false, out point, Class26.class76_0))
					{
						Class56.smethod_8(Class26.class76_0, Class26.random_0.Next(40, 60), Class26.random_0.Next(10, 30), Class26.rect_6);
						Point point5;
						if (Class40.smethod_14(Class26.mat_5, Class26.rect_5, 0.8, false, out point5, Class26.class76_0, Class26.cancellationToken_0, 3000, 1000, false))
						{
							Class56.smethod_7(Class26.class76_0, Class26.random_0.Next(40, 60), Class26.random_0.Next(10, 30), new Rectangle(Class26.rect_5.X + point5.X, Class26.rect_5.Y + point5.Y, Class26.mat_5.Width, Class26.mat_5.Height));
							Class40.smethod_14(Class26.mat_4, Class26.rect_6, 0.8, false, out point, Class26.class76_0, Class26.cancellationToken_0, 3000, 1000, false);
						}
						else if (Class40.smethod_14(Class26.mat_7, Class26.rect_5, 0.8, false, out point5, Class26.class76_0, Class26.cancellationToken_0, 3000, 1000, false))
						{
							Class56.smethod_7(Class26.class76_0, Class26.random_0.Next(40, 60), Class26.random_0.Next(10, 30), new Rectangle(Class26.rect_5.X + point5.X, Class26.rect_5.Y + point5.Y, Class26.mat_7.Width, Class26.mat_7.Height));
							Class40.smethod_14(Class26.mat_6, Class26.rect_6, 0.8, false, out point, Class26.class76_0, Class26.cancellationToken_0, 3000, 1000, false);
						}
					}
					if (Class26.smethod_17())
					{
						Class46.smethod_6(Keys.E, Class26.class76_0, false);
					}
				}
				return;
			}
			throw new Form1.GException0();
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0001C3EC File Offset: 0x0001A5EC
		private static Class26.Enum2 smethod_19()
		{
			Class26.Enum2 @enum;
			using (Mat mat = BitmapConverter.ToMat(Class40.smethod_5(Class26.class76_0, Class26.rectangle_7)))
			{
				for (int i = 0; i < Class26.mat_12.Length; i++)
				{
					Point point;
					if (Class40.smethod_17(Class26.mat_12[i], 0.8, false, out point, mat))
					{
						return i + Class26.Enum2.const_1;
					}
				}
				@enum = Class26.Enum2.const_0;
			}
			return @enum;
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0001C464 File Offset: 0x0001A664
		private static void smethod_20()
		{
			Class26.Enum2 @enum = Class26.enum2_0;
			if (@enum - Class26.Enum2.const_1 > 1 && @enum == Class26.Enum2.const_3)
			{
				Class56.smethod_25(Class26.rectangle_7, Class26.class76_0, true);
				Class26.smethod_48(800.0, 1000.0);
				Class56.smethod_25(Class26.rectangle_10, Class26.class76_0, true);
				return;
			}
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0001C4BC File Offset: 0x0001A6BC
		private static void smethod_21()
		{
			while (!Class26.cancellationToken_0.IsCancellationRequested)
			{
				Point[] array;
				if (Class40.smethod_18(2, 1, Class26.bitmap_0, -1, out array, Class26.rectangle_0, 30, 100, Class26.class76_0))
				{
					Class46.smethod_8(Keys.Space, null, true);
					ValueTuple<int, Point[]> valueTuple = Class26.smethod_22();
					int item = valueTuple.Item1;
					Point[] item2 = valueTuple.Item2;
					int num = (int)((double)item * 0.7);
					Rectangle rectangle = Class26.smethod_23(item2, item, num);
					while (!Class26.cancellationToken_0.IsCancellationRequested)
					{
						if (Class40.smethod_18(1, 1, Class26.bitmap_1, -1, out array, rectangle, 30, 10, Class26.class76_0))
						{
							Class46.smethod_9(Keys.Space, null, false, true);
							return;
						}
					}
					return;
				}
				Class26.smethod_48(10.0, 0.0);
			}
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0001C578 File Offset: 0x0001A778
		private static ValueTuple<int, Point[]> smethod_22()
		{
			Point[] array;
			if (Class40.smethod_29(0, new List<Color> { Color.FromArgb(68, 196, 53) }, new List<int> { 4 }, 1, out array, 7, 2, 2, 2, 2, Class26.rectangle_0, 30, 2, 999, Class26.class76_0))
			{
				return new ValueTuple<int, Point[]>(Math.Max(Math.Min(array.Length, 100), 60), array);
			}
			return new ValueTuple<int, Point[]>(-1, null);
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0001C5EC File Offset: 0x0001A7EC
		private static Rectangle smethod_23(Point[] point_2, int int_3, int int_4)
		{
			int num = Class26.rectangle_0.X + point_2[0].X + int_3 / 2;
			int height = Class26.rectangle_0.Height;
			string text = Class26.smethod_24();
			if (text == "Left")
			{
				return new Rectangle(Math.Max(Class26.rectangle_0.X, num - int_4), Class26.rectangle_0.Y, int_4, height);
			}
			if (!(text == "Right"))
			{
				return default(Rectangle);
			}
			return new Rectangle(num, Class26.rectangle_0.Y, Math.Min(Class26.rectangle_0.Width - point_2[0].X - int_3 / 2, int_4), height);
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0001C6A0 File Offset: 0x0001A8A0
		private static string smethod_24()
		{
			while (!Class26.cancellationToken_0.IsCancellationRequested)
			{
				string[] array = new string[] { "Left", "Right" };
				int[] array2 = new int[]
				{
					0,
					Class26.rectangle_0.Width - 10
				};
				for (int i = 0; i < array.Length; i++)
				{
					Point[] array3;
					if (Class40.smethod_18(2, 1, Class26.bitmap_1, -1, out array3, new Rectangle(Class26.rectangle_0.X + array2[i], Class26.rectangle_0.Y, 10, Class26.rectangle_0.Height), 30, 10, Class26.class76_0))
					{
						return array[i];
					}
				}
				Class26.smethod_48(10.0, 0.0);
			}
			return null;
		}

		// Token: 0x0600023B RID: 571 RVA: 0x0001C760 File Offset: 0x0001A960
		private static void smethod_25()
		{
			Rectangle rectangle = new Rectangle(Class26.rectangle_1.X, Class26.rectangle_1.Y, Class26.rectangle_1.Width / 3, Class26.rectangle_1.Height / 2);
			while (!Class26.cancellationToken_0.IsCancellationRequested)
			{
				using (Bitmap bitmap = Class40.smethod_2(Class26.class76_0))
				{
					Point[] array;
					if (Class40.smethod_20(1, 1, Class26.bitmap_5[1], -1, out array, Class26.rectangle_1, 25, 90, bitmap) || Class40.smethod_20(1, 1, Class26.bitmap_5[0], -2, out array, rectangle, 25, 80, bitmap))
					{
						Class26.smethod_48(20.0, 55.0);
						Class46.smethod_6(Keys.Space, Class26.class76_0, false);
						break;
					}
					Class26.smethod_48(50.0, 60.0);
				}
			}
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00004056 File Offset: 0x00002256
		private static void smethod_26()
		{
			while (!Class26.cancellationToken_0.IsCancellationRequested)
			{
				if (Class26.smethod_32())
				{
					Class26.smethod_33();
					return;
				}
				Class26.smethod_48(100.0, 0.0);
			}
		}

		// Token: 0x0600023D RID: 573 RVA: 0x0001C850 File Offset: 0x0001AA50
		private static void smethod_27()
		{
			while (!Class26.cancellationToken_0.IsCancellationRequested)
			{
				if (Class26.smethod_32())
				{
					Class26.smethod_48(1000.0, 0.0);
					Class26.smethod_28();
					return;
				}
				Class26.smethod_48(100.0, 0.0);
			}
		}

		// Token: 0x0600023E RID: 574 RVA: 0x0001C8A8 File Offset: 0x0001AAA8
		private static void smethod_28()
		{
			Rect rect;
			rect..ctor(0, 0, Class26.class76_0.Width, Class26.class76_0.Height);
			int num = 0;
			List<double> list2;
			List<Mat> list = Class26.smethod_29(out list2);
			Mat mat = null;
			int num2 = -1;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			try
			{
				while (!Class26.cancellationToken_0.IsCancellationRequested && Class26.smethod_32())
				{
					try
					{
						using (Mat mat2 = BitmapConverter.ToMat(Class40.smethod_2(Class26.class76_0)))
						{
							if (mat2.Empty())
							{
								break;
							}
							num3++;
							using (Mat mat3 = mat2.CvtColor(6, 0))
							{
								if (num > 30)
								{
									rect = new Rect(0, 0, Class26.class76_0.Width, Class26.class76_0.Height);
								}
								Rect rect2;
								rect2..ctor(Math.Max(0, rect.X), Math.Max(0, rect.Y), Math.Min(rect.Width, mat3.Width - rect.X), Math.Min(rect.Height, mat3.Height - rect.Y));
								using (Mat mat4 = new Mat(mat3, rect2))
								{
									using (Mat mat5 = new Mat())
									{
										double num7 = 0.0;
										Point point = default(Point);
										Size size = default(Size);
										List<Mat> list3 = new List<Mat>();
										bool flag;
										if (flag = mat != null)
										{
											list3.Add(mat);
										}
										list3.AddRange(list);
										double num8;
										Point point2;
										if (num6 == 0)
										{
											for (int i = list3.Count - 1; i >= 10; i--)
											{
												Mat mat6 = list3[i];
												if (mat4.Width >= mat6.Width && mat4.Height >= mat6.Height)
												{
													Cv2.MatchTemplate(mat4, mat6, mat5, 5, null);
													double num9;
													Point point3;
													Cv2.MinMaxLoc(mat5, ref num8, ref num9, ref point2, ref point3, null);
													double num10 = Class26.smethod_30(i, flag, num2, list2);
													if (num9 > num7 && num9 > num10)
													{
														num5 = 0;
														num7 = num9;
														point..ctor(point3.X + rect2.X, point3.Y + rect2.Y);
														size = mat6.Size();
														if (!flag || i != 0)
														{
															num2 = i - ((flag > false) ? 1 : 0);
														}
														Class26.smethod_31(point, size, ref rect);
														num4 = point.X;
														Rect rect3;
														rect3..ctor(point.X, point.Y, Math.Min(mat6.Width, mat3.Width - point.X), Math.Min(mat6.Height, mat3.Height - point.Y));
														mat = new Mat(mat3, rect3).Clone();
														num6++;
														break;
													}
												}
											}
										}
										if (num6 == 1)
										{
											num6++;
										}
										else if (num6 != 0)
										{
											for (int j = 0; j < list3.Count; j++)
											{
												if (j <= 0 || (j >= num2 - 1 && j <= num2 + 1))
												{
													Mat mat7 = list3[j];
													if (mat4.Width >= mat7.Width && mat4.Height >= mat7.Height)
													{
														Cv2.MatchTemplate(mat4, mat7, mat5, 5, null);
														double num11;
														Point point4;
														Cv2.MinMaxLoc(mat5, ref num8, ref num11, ref point2, ref point4, null);
														double num12 = Class26.smethod_30(j, flag, num2, list2);
														if (mat7.Height > 60)
														{
															num12 = 0.85;
														}
														else if (mat7.Height > 100)
														{
															num12 = 0.7;
														}
														if (num11 > num7 && num11 > num12)
														{
															num5 = 0;
															num7 = num11;
															point..ctor(point4.X + rect2.X, point4.Y + rect2.Y);
															size = mat7.Size();
															if (!flag || j != 0)
															{
																num2 = j - ((flag > false) ? 1 : 0);
															}
															Class26.smethod_31(point, size, ref rect);
															if (num4 > 0)
															{
																if (point.X < num4)
																{
																	num4 = point.X;
																	Class26.smethod_37();
																}
																else if (point.X > num4)
																{
																	num4 = point.X;
																	Class26.smethod_38();
																}
															}
															else
															{
																num4 = point.X;
															}
														}
													}
												}
											}
											if (num7 > 0.8)
											{
												Size size2 = size;
												Rect rect4;
												rect4..ctor(Math.Max(0, point.X - 50), Math.Max(0, point.Y - 50), Math.Min(mat3.Width - point.X + 50, size.Width + 100), Math.Min(mat3.Height - point.Y + 50, size.Height + 100));
												using (Mat mat8 = new Mat(mat3, rect4))
												{
													for (int k = 1; k < list.Count; k++)
													{
														Mat mat9 = list[k];
														if (mat8.Width >= mat9.Width && mat8.Height >= mat9.Height)
														{
															Cv2.MatchTemplate(mat8, mat9, mat5, 5, null);
															double num13;
															Point point5;
															Cv2.MinMaxLoc(mat5, ref num8, ref num13, ref point2, ref point5, null);
															if (num13 > list2[k])
															{
																size2 = mat9.Size();
																point = new Point(rect4.X + point5.X, rect4.Y + point5.Y);
																num2 = k;
																IL_0563:
																Rect rect5;
																rect5..ctor(point.X, point.Y, Math.Min(size2.Width, mat3.Width - point.X), Math.Min(size2.Height, mat3.Height - point.Y));
																if (mat != null)
																{
																	mat.Dispose();
																}
																mat = new Mat(mat3, rect5).Clone();
																goto IL_0604;
															}
														}
													}
													goto IL_0563;
												}
											}
											if (num5 > 10)
											{
												num5 = 0;
												rect = new Rect(0, 0, Class26.class76_0.Width, Class26.class76_0.Height);
											}
											else
											{
												num5++;
											}
											IL_0604:;
										}
									}
								}
							}
						}
					}
					catch (Exception)
					{
					}
				}
			}
			catch (Form1.GException0)
			{
				throw;
			}
			catch (Exception)
			{
			}
			finally
			{
				Class26.smethod_39();
				if (mat != null)
				{
					mat.Dispose();
				}
				foreach (Mat mat10 in list)
				{
					mat10.Dispose();
				}
			}
		}

		// Token: 0x0600023F RID: 575 RVA: 0x0001D044 File Offset: 0x0001B244
		private static List<Mat> smethod_29(out List<double> list_2)
		{
			List<Mat> list = new List<Mat>();
			list_2 = new List<double>();
			int num = Math.Min(Class26.double_0.Length, Class26.mat_13.Length);
			for (int i = 0; i < num - 3; i++)
			{
				Mat mat = Class26.mat_13[i];
				if (mat != null && !mat.Empty())
				{
					if (mat.Channels() > 1)
					{
						mat = mat.CvtColor(6, 0);
					}
					list.Add(mat);
					list_2.Add(Class26.double_0[i]);
				}
			}
			if (Class26.class76_0.Height <= 1080)
			{
				list.Add(Class50.smethod_2("Icon", "f90").CvtColor(6, 0));
				list.Add(Class50.smethod_2("Icon", "f91").CvtColor(6, 0));
				list.Add(Class50.smethod_2("Icon", "f92").CvtColor(6, 0));
				list_2.Add(0.9);
				list_2.Add(0.9);
				list_2.Add(0.9);
			}
			if (Class26.class76_0.Height <= 900)
			{
				list.Add(Class50.smethod_2("Icon", "f95").CvtColor(6, 0));
				list_2.Add(0.9);
			}
			if (Class26.class76_0.Height <= 800)
			{
				list.Add(Class50.smethod_2("Icon", "f100").CvtColor(6, 0));
				list_2.Add(0.9);
			}
			return list;
		}

		// Token: 0x06000240 RID: 576 RVA: 0x0001D1D0 File Offset: 0x0001B3D0
		private static double smethod_30(int int_3, bool bool_5, int int_4, List<double> list_2)
		{
			if (bool_5 && int_3 == 0 && int_4 >= 0 && int_4 < list_2.Count)
			{
				return list_2[int_4];
			}
			int num = int_3 - ((bool_5 > false) ? 1 : 0);
			if (num >= 0 && num < list_2.Count)
			{
				return list_2[num];
			}
			return 0.8;
		}

		// Token: 0x06000241 RID: 577 RVA: 0x0001D220 File Offset: 0x0001B420
		private static void smethod_31(Point point_2, Size size_1, ref Rect rect_10)
		{
			rect_10.Y = Math.Max(0, point_2.Y - 200 - size_1.Height);
			rect_10.Height = Math.Min(Class26.class76_0.Height - rect_10.Y, 400 + size_1.Height * 2);
			rect_10.X = Math.Max(0, point_2.X - 200 - size_1.Width);
			rect_10.Width = Math.Min(Class26.class76_0.Width - rect_10.X, 400 + size_1.Width * 2);
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0001D2C0 File Offset: 0x0001B4C0
		private static bool smethod_32()
		{
			Point[] array;
			if (Class26.class76_0.method_4() == Class76.Enum5.const_0)
			{
				return Class40.smethod_18(6, 1, Class26.bitmap_2, -1, out array, Class26.rectangle_2, 25, 50, Class26.class76_0);
			}
			if (!Class26.class76_0.IsActive)
			{
				return true;
			}
			if (Class40.smethod_18(6, 1, Class26.bitmap_2, -1, out array, Class26.rectangle_2, 25, 50, Class26.class76_0))
			{
				return true;
			}
			Class26.smethod_48(1000.0, 0.0);
			return Class40.smethod_18(6, 1, Class26.bitmap_2, -1, out array, Class26.rectangle_2, 25, 50, Class26.class76_0);
		}

		// Token: 0x06000243 RID: 579 RVA: 0x0001D35C File Offset: 0x0001B55C
		private static void smethod_33()
		{
			try
			{
				while (!Class26.cancellationToken_0.IsCancellationRequested && Class26.smethod_32())
				{
					using (Bitmap bitmap = Class40.smethod_5(Class26.class76_0, Class26.rectangle_3))
					{
						if (bitmap != null)
						{
							Class26.smethod_48(20.0, 0.0);
							using (Bitmap bitmap2 = Class40.smethod_5(Class26.class76_0, Class26.rectangle_3))
							{
								if (bitmap2 != null)
								{
									Class26.smethod_34(bitmap, bitmap2);
								}
							}
						}
					}
				}
			}
			catch (Form1.GException0)
			{
				throw;
			}
			catch (Exception)
			{
			}
			finally
			{
				Class26.smethod_39();
			}
		}

		// Token: 0x06000244 RID: 580 RVA: 0x0001D430 File Offset: 0x0001B630
		private static void smethod_34(Bitmap bitmap_7, Bitmap bitmap_8)
		{
			using (Mat mat = BitmapConverter.ToMat(bitmap_7))
			{
				using (Mat mat2 = BitmapConverter.ToMat(bitmap_8))
				{
					double num = Class26.smethod_35(mat, mat2);
					if (num > 0.0)
					{
						Class26.smethod_37();
					}
					else if (num < 0.0)
					{
						Class26.smethod_38();
					}
				}
			}
		}

		// Token: 0x06000245 RID: 581 RVA: 0x0001D4AC File Offset: 0x0001B6AC
		private static double smethod_35(Mat mat_16, Mat mat_17)
		{
			double num;
			using (Mat mat = new Mat())
			{
				using (Mat mat2 = new Mat())
				{
					using (Mat mat3 = new Mat())
					{
						try
						{
							Cv2.CvtColor(mat_16, mat, 6, 0);
							Cv2.CvtColor(mat_17, mat2, 6, 0);
							using (Mat mat4 = Class26.smethod_36(mat))
							{
								using (Mat mat5 = Class26.smethod_36(mat2))
								{
									Cv2.CalcOpticalFlowFarneback(mat4, mat5, mat3, 0.2, 3, 15, 3, 5, 1.2, 0);
									if (mat3.Empty())
									{
										num = 0.0;
									}
									else
									{
										num = Cv2.Mean(mat3, null).Val0;
									}
								}
							}
						}
						catch (Exception)
						{
							num = 0.0;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0001D5EC File Offset: 0x0001B7EC
		private static Mat smethod_36(Mat mat_16)
		{
			using (CLAHE clahe = CLAHE.Create(2.0, new Size?(new Size(8, 8))))
			{
				clahe.Apply(mat_16, mat_16);
			}
			return mat_16;
		}

		// Token: 0x06000247 RID: 583 RVA: 0x0000408B File Offset: 0x0000228B
		private static void smethod_37()
		{
			Class46.smethod_9(Keys.A, null, false, true);
			Class46.smethod_8(Keys.D, null, false);
		}

		// Token: 0x06000248 RID: 584 RVA: 0x000040A2 File Offset: 0x000022A2
		private static void smethod_38()
		{
			Class46.smethod_9(Keys.D, null, false, true);
			Class46.smethod_8(Keys.A, null, false);
		}

		// Token: 0x06000249 RID: 585 RVA: 0x000040B9 File Offset: 0x000022B9
		private static void smethod_39()
		{
			Class46.smethod_9(Keys.A, null, false, true);
			Class46.smethod_9(Keys.D, null, false, true);
		}

		// Token: 0x0600024A RID: 586 RVA: 0x0001D648 File Offset: 0x0001B848
		private static bool smethod_40()
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			while (!Class26.cancellationToken_0.IsCancellationRequested && stopwatch.Elapsed.TotalSeconds <= 5.0)
			{
				using (Bitmap bitmap = Class40.smethod_2(Class26.class76_0))
				{
					Point[] array;
					if (Class40.smethod_20(6, 1, Class26.bitmap_0, -1, out array, Class26.rectangle_0, 25, 90, bitmap) || Class40.smethod_20(6, 1, Class26.bitmap_3, -1, out array, Class26.rectangle_4, 15, 90, bitmap))
					{
						stopwatch.Restart();
						while (!Class26.cancellationToken_0.IsCancellationRequested && stopwatch.Elapsed.TotalSeconds <= 2.0)
						{
							if (!Class40.smethod_18(6, 1, Class26.bitmap_3, -1, out array, Class26.rectangle_4, 15, 90, Class26.class76_0))
							{
								Class26.smethod_48(100.0, 0.0);
							}
							else
							{
								Class26.CatchType catchType = Class26.smethod_42();
								if (catchType == Class26.CatchType.None)
								{
									return false;
								}
								if (Class26.bool_1)
								{
									Class56.smethod_6(Class26.class76_0, FormFishing.Main.SpeedClick.Value, Class26.random_0.Next(10, 30), Class26.point_1, new Size(25, 5));
									return true;
								}
								bool flag;
								if (Class26.dictionary_0.TryGetValue(string.Format("{0}Catch", catchType), out flag) && flag)
								{
									Class26.Class28 @class = new Class26.Class28();
									@class.string_0 = Class26.smethod_41();
									double num;
									@class.string_0 = Class72.smethod_1(@class.string_0, Class26.dictionary_1, out num);
									@class.string_0 = Class26.dictionary_1.FirstOrDefault(new Func<KeyValuePair<string, string>, bool>(@class.method_0)).Key;
									if (Class26.dictionary_0.TryGetValue(@class.string_0, out flag) && flag)
									{
										Class56.smethod_6(Class26.class76_0, FormFishing.Main.SpeedClick.Value, Class26.random_0.Next(10, 30), Class26.point_0, new Size(25, 5));
									}
									else
									{
										Class56.smethod_6(Class26.class76_0, FormFishing.Main.SpeedClick.Value, Class26.random_0.Next(10, 30), Class26.point_1, new Size(25, 5));
									}
									return true;
								}
								Class56.smethod_6(Class26.class76_0, FormFishing.Main.SpeedClick.Value, Class26.random_0.Next(10, 30), Class26.point_1, new Size(25, 5));
								return true;
							}
						}
						return false;
					}
					Class26.smethod_48(100.0, 0.0);
				}
			}
			if (!Class26.smethod_17())
			{
				Class26.smethod_8();
				Class26.smethod_16();
				if (!FormFishing.IsTrunk)
				{
					Class26.smethod_48(1000.0, 0.0);
				}
				Class26.smethod_6();
				if (!Class26.smethod_17())
				{
					throw new Form1.GException0("Персонаж не находится в интерфейсе рыбалки.");
				}
				Class46.smethod_6(Keys.E, null, false);
				Class26.int_2 = 0;
			}
			return false;
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0001D970 File Offset: 0x0001BB70
		public static string smethod_41()
		{
			Bitmap bitmap = Class40.smethod_5(Class26.class76_0, Class26.rectangle_6);
			Bitmap bitmap2 = null;
			List<Line> list = new List<Line>();
			string text;
			try
			{
				text = ReadText.SymbolsToString(ReadText.Recognize(bitmap, Class26.dictionary_2[Class26.class76_0.Resolution], 30, 59, 11, 0, 5, 4, 180, 0, 50, 0, 50, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 5, 5, 50, 70, 1, 0, 1, 0, 1, 0, new Color[0], new Color[0], new int[0], new int[0], Class26.list_1, false, 5, ref list, ref bitmap2, false, new Size(0, 0), 0, 0, 166, 166, 166, 0, 1, 0, new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, new char[0]), 40, list, true).Replace(" ", "");
			}
			finally
			{
				if (bitmap2 != null)
				{
					bitmap2.Dispose();
				}
			}
			return text;
		}

		// Token: 0x0600024C RID: 588 RVA: 0x0001DA6C File Offset: 0x0001BC6C
		private static Class26.CatchType smethod_42()
		{
			Point[] array;
			return (Class26.CatchType)Class40.smethod_25(6, 1, 0, Class26.bitmap_6.Length, Class26.bitmap_6, -1, out array, Class26.rectangle_5, 25, 90, Class26.class76_0);
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0001DAA0 File Offset: 0x0001BCA0
		private static void smethod_43()
		{
			try
			{
				Rectangle rectangle = new Rectangle
				{
					Width = Class26.size_0.Width,
					Height = Class26.size_0.Height
				};
				while (!Class26.cancellationToken_0.IsCancellationRequested)
				{
					using (Bitmap bitmap = Class40.smethod_0(Class26.class76_0, default(Rectangle)))
					{
						using (Mat mat = BitmapConverter.ToMat(bitmap))
						{
							Point point;
							if (Class40.smethod_16(Class26.mat_10, Class26.rect_8, 0.85, false, out point, mat))
							{
								rectangle.X = Class26.rect_8.X + point.X + Class26.mat_10.Width + 3;
								rectangle.Y = Class26.rect_8.Y + point.Y - 4;
								string text;
								using (Bitmap bitmap2 = bitmap.Clone(rectangle, bitmap.PixelFormat))
								{
									text = Class4.smethod_2(bitmap2, Class26.list_0);
								}
								text = Regex.Replace(text, "[^а-я]", "");
								if (Class72.smethod_0(text, "вам срочно нужно выпить воды вы теряете силы".Replace(" ", "")) >= 0.5 || Class72.smethod_0(text, "вам срочно нужно поесть вы теряете силы".Replace(" ", "")) >= 0.5)
								{
									Class26.bool_4 = true;
									break;
								}
								Class26.smethod_48(100.0, 0.0);
							}
							else
							{
								Class26.smethod_48(100.0, 0.0);
							}
						}
					}
				}
			}
			catch (Form1.GException0)
			{
			}
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0001DCAC File Offset: 0x0001BEAC
		private static void smethod_44()
		{
			Rectangle rectangle = new Rectangle
			{
				Width = Class26.size_0.Width,
				Height = Class26.size_0.Height
			};
			bool flag = false;
			Stopwatch stopwatch = Stopwatch.StartNew();
			int num = 0;
			while (!Class26.cancellationToken_0.IsCancellationRequested && stopwatch.Elapsed.TotalSeconds <= 2.0)
			{
				using (Bitmap bitmap = Class40.smethod_2(Class26.class76_0))
				{
					using (Mat mat = BitmapConverter.ToMat(bitmap))
					{
						Point point;
						if (Class40.smethod_16(Class26.mat_10, Class26.rect_8, 0.85, false, out point, mat))
						{
							flag = true;
							rectangle.X = Class26.rect_8.X + point.X + Class26.mat_10.Width + 3;
							rectangle.Y = Class26.rect_8.Y + point.Y - 4;
							string text;
							using (Bitmap bitmap2 = bitmap.Clone(rectangle, bitmap.PixelFormat))
							{
								text = Class4.smethod_2(bitmap2, Class26.list_0);
							}
							Class26.smethod_46(text);
						}
						if (Class40.smethod_16(Class26.mat_9, Class26.rect_8, 0.85, false, out point, mat))
						{
							flag = true;
							rectangle.X = Class26.rect_8.X + point.X + Class26.mat_9.Width + 3;
							rectangle.Y = Class26.rect_8.Y + point.Y - 4;
							string text;
							using (Bitmap bitmap3 = bitmap.Clone(rectangle, bitmap.PixelFormat))
							{
								text = Class4.smethod_2(bitmap3, Class26.list_0);
							}
							Class26.smethod_46(text);
						}
						if (Class40.smethod_16(Class26.mat_8, Class26.rect_8, 0.85, false, out point, mat))
						{
							if (num < 1)
							{
								num++;
								Class26.smethod_48(1000.0, 0.0);
								continue;
							}
							flag = true;
							rectangle.X = Class26.rect_8.X + point.X + Class26.mat_8.Width + 3;
							rectangle.Y = Class26.rect_8.Y + point.Y - 4;
							string text;
							using (Bitmap bitmap4 = bitmap.Clone(rectangle, bitmap.PixelFormat))
							{
								text = Class4.smethod_2(bitmap4, Class26.list_0);
							}
							Class26.smethod_46(text);
						}
						if (flag)
						{
							break;
						}
					}
				}
				Class26.smethod_48(100.0, 0.0);
			}
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0001DFD0 File Offset: 0x0001C1D0
		[return: TupleElementNames(new string[] { "Start", "End" })]
		private static ValueTuple<double, double> smethod_45(int int_3)
		{
			if (int_3 >= 0 && int_3 <= 100)
			{
				double num = 2000.0 - 20.0 * (double)int_3;
				double num2 = 3000.0 - 28.0 * (double)int_3;
				return new ValueTuple<double, double>(num, num2);
			}
			return new ValueTuple<double, double>(0.0, 200.0);
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0001E034 File Offset: 0x0001C234
		private static void smethod_46(string string_1)
		{
			string_1 = Regex.Replace(string_1, "[^а-я]", "");
			if ((!(FormFishing.Main.comboBox2.SelectedItem != "отпускать рыбу") && FormFishing.IsOverWeight) || (Class72.smethod_0(string_1, "предмет не вмещается по весу".Replace(" ", "")) < 0.5 && Class72.smethod_0(string_1, "у вас нет свободного места в инвентаре".Replace(" ", "")) < 0.5))
			{
				if (Class72.smethod_0(string_1, "пора менять приманку рыба не проявляет к неи".Replace(" ", "")) >= 0.5)
				{
					Class26.int_2 = 7;
					return;
				}
				if (Class72.smethod_0(string_1, "для начала рыбалки купите наживку".Replace(" ", "")) >= 0.5)
				{
					Class26.smethod_9();
					throw new Form1.GException0("У вас нет наживки.");
				}
				ValueTuple<double, double> valueTuple = Class26.smethod_45(FormFishing.Main.SpeedCast.Value);
				double item = valueTuple.Item1;
				double item2 = valueTuple.Item2;
				Class26.smethod_48(item, item2);
				return;
			}
			else
			{
				Class26.smethod_9();
				string selectedItem = FormFishing.Main.comboBox2.SelectedItem;
				if (selectedItem == "закрыть игру")
				{
					Class26.smethod_10();
					throw new Form1.GException0("Инвентарь переполнен.");
				}
				if (!(selectedItem == "выключить компьютер"))
				{
					throw new Form1.GException0("Инвентарь переполнен.");
				}
				Class26.smethod_10();
				Form1.bool_10 = true;
				Form1.Main.Close();
				return;
			}
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0001E1B0 File Offset: 0x0001C3B0
		private static void smethod_47()
		{
			using (Mat mat = BitmapConverter.ToMat(Class40.smethod_6(Class26.class76_0, Class26.rect_4)))
			{
				Point point;
				if (FormFishing.IsOverWeight && !Class26.bool_1 && Class40.smethod_17(Class26.mat_1, 0.9, false, out point, mat))
				{
					string selectedItem = FormFishing.Main.comboBox2.SelectedItem;
					if (!(selectedItem == "отпускать рыбу"))
					{
						if (!(selectedItem == "остановиться"))
						{
							if (!(selectedItem == "закрыть игру"))
							{
								if (selectedItem == "выключить компьютер")
								{
									Class26.smethod_48(1000.0, 1500.0);
									if (Class26.cancellationToken_0.IsCancellationRequested)
									{
										return;
									}
									Class46.smethod_6(Keys.Escape, Class26.class76_0, false);
									if (Class26.cancellationToken_0.IsCancellationRequested)
									{
										return;
									}
									Class26.smethod_48(3000.0, 3500.0);
									if (Class26.cancellationToken_0.IsCancellationRequested)
									{
										return;
									}
									Class46.smethod_6(Keys.Escape, Class26.class76_0, false);
									if (Class26.cancellationToken_0.IsCancellationRequested)
									{
										return;
									}
									Class26.smethod_48(3000.0, 3500.0);
									if (Class26.cancellationToken_0.IsCancellationRequested)
									{
										return;
									}
									Class46.smethod_8(Keys.LMenu, null, false);
									if (Class26.cancellationToken_0.IsCancellationRequested)
									{
										return;
									}
									Class26.smethod_48(500.0, 1000.0);
									if (Class26.cancellationToken_0.IsCancellationRequested)
									{
										return;
									}
									Class46.smethod_6(Keys.F4, null, false);
									if (Class26.cancellationToken_0.IsCancellationRequested)
									{
										return;
									}
									Class26.smethod_48(500.0, 1000.0);
									if (Class26.cancellationToken_0.IsCancellationRequested)
									{
										return;
									}
									Class46.smethod_9(Keys.LMenu, null, false, true);
									if (Class26.cancellationToken_0.IsCancellationRequested)
									{
										return;
									}
									Class26.smethod_48(1500.0, 2454.0);
									if (Class26.cancellationToken_0.IsCancellationRequested)
									{
										return;
									}
									Class46.smethod_6(Keys.Return, null, false);
									if (Class26.cancellationToken_0.IsCancellationRequested)
									{
										return;
									}
									Form1.bool_10 = true;
									Form1.Main.Close();
								}
							}
							else
							{
								Class26.smethod_48(1000.0, 1500.0);
								if (Class26.cancellationToken_0.IsCancellationRequested)
								{
									return;
								}
								Class46.smethod_6(Keys.Escape, Class26.class76_0, false);
								if (Class26.cancellationToken_0.IsCancellationRequested)
								{
									return;
								}
								Class26.smethod_48(3000.0, 3500.0);
								if (Class26.cancellationToken_0.IsCancellationRequested)
								{
									return;
								}
								Class46.smethod_6(Keys.Escape, Class26.class76_0, false);
								if (Class26.cancellationToken_0.IsCancellationRequested)
								{
									return;
								}
								Class26.smethod_48(3000.0, 3500.0);
								if (Class26.cancellationToken_0.IsCancellationRequested)
								{
									return;
								}
								Class46.smethod_8(Keys.LMenu, null, false);
								if (Class26.cancellationToken_0.IsCancellationRequested)
								{
									return;
								}
								Class26.smethod_48(500.0, 1000.0);
								if (Class26.cancellationToken_0.IsCancellationRequested)
								{
									return;
								}
								Class46.smethod_6(Keys.F4, null, false);
								if (Class26.cancellationToken_0.IsCancellationRequested)
								{
									return;
								}
								Class26.smethod_48(500.0, 1000.0);
								if (Class26.cancellationToken_0.IsCancellationRequested)
								{
									return;
								}
								Class46.smethod_9(Keys.LMenu, null, false, true);
								if (Class26.cancellationToken_0.IsCancellationRequested)
								{
									return;
								}
								Class26.smethod_48(1500.0, 2454.0);
								if (Class26.cancellationToken_0.IsCancellationRequested)
								{
									return;
								}
								Class46.smethod_6(Keys.Return, null, false);
								throw new Form1.GException0("У вас избыточный вес в инвентаре, окно игры закрыто.");
							}
						}
						else
						{
							Class26.smethod_48(1000.0, 1500.0);
							Class46.smethod_6(Keys.Escape, Class26.class76_0, false);
							if (Class26.cancellationToken_0.IsCancellationRequested)
							{
								return;
							}
							Class26.smethod_48(3000.0, 3500.0);
							if (Class26.cancellationToken_0.IsCancellationRequested)
							{
								return;
							}
							Class46.smethod_6(Keys.Escape, Class26.class76_0, false);
							if (Class26.cancellationToken_0.IsCancellationRequested)
							{
								return;
							}
							Class26.smethod_48(3000.0, 3500.0);
							if (Class26.cancellationToken_0.IsCancellationRequested)
							{
								return;
							}
							throw new Form1.GException0("У вас избыточный вес в инвентаре, работа бота остановлена.");
						}
					}
					else
					{
						Class26.bool_1 = true;
					}
				}
				if (FormFishing.IsHandleNeeds && Class26.bool_0 && (Class40.smethod_17(Class26.mat_2, 0.8, false, out point, mat) || Class40.smethod_17(Class26.mat_3, 0.8, false, out point, mat)))
				{
					Class26.smethod_48(1000.0, 1500.0);
					if (!Class26.smethod_17())
					{
						throw new Form1.GException0();
					}
					Class46.smethod_6(Keys.Escape, Class26.class76_0, false);
					Class26.smethod_48(3000.0, 3500.0);
					if (Class26.smethod_17())
					{
						Class46.smethod_6(Keys.Escape, Class26.class76_0, false);
					}
					Class26.smethod_48(5000.0, 6000.0);
					using (Class20 @class = new Class20(Class26.class76_0, Class26.cancellationToken_0))
					{
						Class26.bool_0 = @class.method_2();
					}
					Class26.smethod_48(2000.0, 3000.0);
					if (!Class26.smethod_17())
					{
						Class46.smethod_6(Keys.E, Class26.class76_0, false);
					}
					Class26.smethod_48(3000.0, 3500.0);
					if (Class26.smethod_17())
					{
						Class26.smethod_20();
					}
					Class26.smethod_48(1000.0, 1500.0);
					if (Class26.smethod_17())
					{
						Class46.smethod_6(Keys.E, Class26.class76_0, false);
					}
				}
			}
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0001E7F0 File Offset: 0x0001C9F0
		private static void smethod_48(double double_1, double double_2 = 0.0)
		{
			double num3;
			if (double_2 > 0.0)
			{
				double num = Math.Min(double_1, double_2);
				double num2 = Math.Max(double_1, double_2);
				num3 = num + Class26.random_0.NextDouble() * (num2 - num);
			}
			else
			{
				num3 = double_1;
			}
			int num4 = (int)Math.Floor(num3);
			double num5 = num3 - (double)num4;
			if (num4 > 0)
			{
				Thread.Sleep(num4);
			}
			if (num5 > 0.0)
			{
				Stopwatch stopwatch = Stopwatch.StartNew();
				double num6 = num5 / 1000.0 * (double)Stopwatch.Frequency;
				while ((double)stopwatch.ElapsedTicks < num6)
				{
					if (Class26.cancellationToken_0.IsCancellationRequested)
					{
						throw new Form1.GException0();
					}
					Thread.SpinWait(10);
				}
			}
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0001E898 File Offset: 0x0001CA98
		// Note: this type is marked as 'beforefieldinit'.
		static Class26()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary["Albula"] = "альбула";
			dictionary["Barrakuda"] = "барракуда";
			dictionary["Vobla"] = "вобла";
			dictionary["Golavl"] = "голавль";
			dictionary["DrevnyayaGineriya"] = "древняягинерия";
			dictionary["Jereh"] = "жерех";
			dictionary["ZerkalniyKarp"] = "зеркальныикарп";
			dictionary["KorichneviySom"] = "коричневыисом";
			dictionary["Krasnoperka"] = "красноперка";
			dictionary["KrasniyGorbil"] = "красныигорбыль";
			dictionary["KrugliyTrahinot"] = "круглыитрахинот";
			dictionary["Lesh"] = "лещ";
			dictionary["Marlin"] = "марлин";
			dictionary["ObiknovennayaShuka"] = "обыкновеннаящука";
			dictionary["Plotva"] = "плотва";
			dictionary["PolosatiyLavrak"] = "полосатыилаврак";
			dictionary["PribrejniyBass"] = "прибрежныибасс";
			dictionary["RadujnayaForel"] = "радужнаяфорель";
			dictionary["RechnoyOkun"] = "речноиокунь";
			dictionary["Ruster"] = "рустер";
			dictionary["Sazan"] = "сазан";
			dictionary["SerebryaniyKaras"] = "серебряныикарась";
			dictionary["Seriola"] = "сериола";
			dictionary["SnukObiknovenniy"] = "снукобыкновенныи";
			dictionary["SomObiknovenniy"] = "сомобыкновенныи";
			dictionary["StalnogoloviyLosos"] = "стальноголовыилосось";
			dictionary["Sterlyad"] = "стерлядь";
			dictionary["SudakObiknovenniy"] = "судакобыкновенныи";
			dictionary["Tarpon"] = "тарпон";
			dictionary["TemniyGorbil"] = "темныигорбыль";
			dictionary["ToksichniyOkun"] = "токсичныиокунь";
			Class26.dictionary_1 = dictionary;
			Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
			dictionary2["1280x720"] = 98;
			dictionary2["1280x800"] = 109;
			dictionary2["1280x1024"] = 101;
			dictionary2["1360x768"] = 107;
			dictionary2["1366x768"] = 107;
			dictionary2["1440x900"] = 120;
			dictionary2["1600x900"] = 120;
			dictionary2["1680x1050"] = 126;
			dictionary2["1920x1080"] = 114;
			dictionary2["1920x1200"] = 114;
			dictionary2["2560x1440"] = 113;
			Class26.dictionary_2 = dictionary2;
		}

		// Token: 0x0400025C RID: 604
		private static CancellationToken cancellationToken_0;

		// Token: 0x0400025D RID: 605
		private static Class76 class76_0;

		// Token: 0x0400025E RID: 606
		private static Rectangle rectangle_0;

		// Token: 0x0400025F RID: 607
		private static Rectangle rectangle_1;

		// Token: 0x04000260 RID: 608
		private static Rectangle rectangle_2;

		// Token: 0x04000261 RID: 609
		private static Rectangle rectangle_3;

		// Token: 0x04000262 RID: 610
		private static Rectangle rectangle_4;

		// Token: 0x04000263 RID: 611
		private static Rectangle rectangle_5;

		// Token: 0x04000264 RID: 612
		private static Rectangle rectangle_6;

		// Token: 0x04000265 RID: 613
		private static Rectangle rectangle_7;

		// Token: 0x04000266 RID: 614
		private static Rectangle rectangle_8;

		// Token: 0x04000267 RID: 615
		private static Rectangle rectangle_9;

		// Token: 0x04000268 RID: 616
		private static Rectangle rectangle_10;

		// Token: 0x04000269 RID: 617
		private static Rect rect_0;

		// Token: 0x0400026A RID: 618
		private static Rect rect_1;

		// Token: 0x0400026B RID: 619
		private static Rect rect_2;

		// Token: 0x0400026C RID: 620
		private static Rect rect_3;

		// Token: 0x0400026D RID: 621
		private static Rect rect_4;

		// Token: 0x0400026E RID: 622
		private static Rect rect_5;

		// Token: 0x0400026F RID: 623
		private static Rect rect_6;

		// Token: 0x04000270 RID: 624
		private static Rect rect_7;

		// Token: 0x04000271 RID: 625
		private static Rect rect_8;

		// Token: 0x04000272 RID: 626
		private static Rect rect_9;

		// Token: 0x04000273 RID: 627
		private static Size size_0;

		// Token: 0x04000274 RID: 628
		private static Point point_0;

		// Token: 0x04000275 RID: 629
		private static Point point_1;

		// Token: 0x04000276 RID: 630
		private static Bitmap bitmap_0;

		// Token: 0x04000277 RID: 631
		private static Bitmap bitmap_1;

		// Token: 0x04000278 RID: 632
		private static Bitmap bitmap_2;

		// Token: 0x04000279 RID: 633
		private static Bitmap bitmap_3;

		// Token: 0x0400027A RID: 634
		private static Bitmap bitmap_4;

		// Token: 0x0400027B RID: 635
		private static Bitmap[] bitmap_5 = new Bitmap[2];

		// Token: 0x0400027C RID: 636
		private static Bitmap[] bitmap_6 = new Bitmap[4];

		// Token: 0x0400027D RID: 637
		private static Mat mat_0;

		// Token: 0x0400027E RID: 638
		private static Mat mat_1;

		// Token: 0x0400027F RID: 639
		private static Mat mat_2;

		// Token: 0x04000280 RID: 640
		private static Mat mat_3;

		// Token: 0x04000281 RID: 641
		private static Mat mat_4;

		// Token: 0x04000282 RID: 642
		private static Mat mat_5;

		// Token: 0x04000283 RID: 643
		private static Mat mat_6;

		// Token: 0x04000284 RID: 644
		private static Mat mat_7;

		// Token: 0x04000285 RID: 645
		private static Mat mat_8;

		// Token: 0x04000286 RID: 646
		private static Mat mat_9;

		// Token: 0x04000287 RID: 647
		private static Mat mat_10;

		// Token: 0x04000288 RID: 648
		private static Mat mat_11;

		// Token: 0x04000289 RID: 649
		private static Mat[] mat_12 = new Mat[3];

		// Token: 0x0400028A RID: 650
		private static Mat[] mat_13 = new Mat[24];

		// Token: 0x0400028B RID: 651
		private static Mat[] mat_14 = new Mat[31];

		// Token: 0x0400028C RID: 652
		private static Mat mat_15;

		// Token: 0x0400028D RID: 653
		private static List<BaseSymbolStruct> list_0;

		// Token: 0x0400028E RID: 654
		private static List<BaseSymbolStruct> list_1;

		// Token: 0x0400028F RID: 655
		private static int int_0 = 0;

		// Token: 0x04000290 RID: 656
		private static int int_1 = 1;

		// Token: 0x04000291 RID: 657
		private static int int_2;

		// Token: 0x04000292 RID: 658
		private static readonly Random random_0 = Class26.smethod_0();

		// Token: 0x04000293 RID: 659
		private static bool bool_0;

		// Token: 0x04000294 RID: 660
		private static bool bool_1;

		// Token: 0x04000295 RID: 661
		private static Dictionary<string, bool> dictionary_0;

		// Token: 0x04000296 RID: 662
		private static bool bool_2;

		// Token: 0x04000297 RID: 663
		private static bool bool_3;

		// Token: 0x04000298 RID: 664
		private static bool bool_4;

		// Token: 0x04000299 RID: 665
		private static readonly string[] string_0 = new string[]
		{
			"f25", "f30", "f31", "f32", "f33", "f35", "f37", "f38", "f40", "f45",
			"f50", "f55", "f60", "f65", "f70", "f75", "f80", "f84", "f85", "f90",
			"f91", "f92", "f95", "f100"
		};

		// Token: 0x0400029A RID: 666
		private static readonly double[] double_0 = new double[]
		{
			0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8,
			0.8, 0.8, 0.8, 0.9, 0.9, 0.9, 0.9, 0.9, 0.9, 0.9,
			0.9, 0.9, 0.9, 0.9
		};

		// Token: 0x0400029B RID: 667
		private static Class26.Enum2 enum2_0;

		// Token: 0x0400029C RID: 668
		private static Class26.Enum3 enum3_0;

		// Token: 0x0400029D RID: 669
		private static readonly Dictionary<string, string> dictionary_1;

		// Token: 0x0400029E RID: 670
		private static readonly Dictionary<string, int> dictionary_2;

		// Token: 0x02000048 RID: 72
		private enum Enum2
		{
			// Token: 0x040002A0 RID: 672
			const_0,
			// Token: 0x040002A1 RID: 673
			const_1,
			// Token: 0x040002A2 RID: 674
			const_2,
			// Token: 0x040002A3 RID: 675
			const_3
		}

		// Token: 0x02000049 RID: 73
		private enum Enum3
		{
			// Token: 0x040002A5 RID: 677
			const_0,
			// Token: 0x040002A6 RID: 678
			const_1
		}

		// Token: 0x0200004A RID: 74
		private enum CatchType
		{
			// Token: 0x040002A8 RID: 680
			None = -1,
			// Token: 0x040002A9 RID: 681
			Modest,
			// Token: 0x040002AA RID: 682
			Good,
			// Token: 0x040002AB RID: 683
			Record,
			// Token: 0x040002AC RID: 684
			Trophy
		}

		// Token: 0x0200004B RID: 75
		private enum Enum4
		{
			// Token: 0x040002AE RID: 686
			const_0 = -1,
			// Token: 0x040002AF RID: 687
			const_1,
			// Token: 0x040002B0 RID: 688
			const_2,
			// Token: 0x040002B1 RID: 689
			const_3,
			// Token: 0x040002B2 RID: 690
			const_4,
			// Token: 0x040002B3 RID: 691
			const_5,
			// Token: 0x040002B4 RID: 692
			const_6,
			// Token: 0x040002B5 RID: 693
			const_7,
			// Token: 0x040002B6 RID: 694
			const_8,
			// Token: 0x040002B7 RID: 695
			const_9,
			// Token: 0x040002B8 RID: 696
			const_10,
			// Token: 0x040002B9 RID: 697
			const_11,
			// Token: 0x040002BA RID: 698
			const_12,
			// Token: 0x040002BB RID: 699
			const_13,
			// Token: 0x040002BC RID: 700
			const_14,
			// Token: 0x040002BD RID: 701
			const_15,
			// Token: 0x040002BE RID: 702
			const_16,
			// Token: 0x040002BF RID: 703
			const_17,
			// Token: 0x040002C0 RID: 704
			const_18,
			// Token: 0x040002C1 RID: 705
			const_19,
			// Token: 0x040002C2 RID: 706
			const_20,
			// Token: 0x040002C3 RID: 707
			const_21,
			// Token: 0x040002C4 RID: 708
			const_22,
			// Token: 0x040002C5 RID: 709
			const_23,
			// Token: 0x040002C6 RID: 710
			const_24,
			// Token: 0x040002C7 RID: 711
			const_25,
			// Token: 0x040002C8 RID: 712
			const_26,
			// Token: 0x040002C9 RID: 713
			const_27,
			// Token: 0x040002CA RID: 714
			const_28,
			// Token: 0x040002CB RID: 715
			const_29,
			// Token: 0x040002CC RID: 716
			const_30,
			// Token: 0x040002CD RID: 717
			const_31
		}

		// Token: 0x0200004C RID: 76
		[CompilerGenerated]
		[Serializable]
		private sealed class Class27
		{
			// Token: 0x06000256 RID: 598 RVA: 0x0001EC7C File Offset: 0x0001CE7C
			internal void method_0()
			{
				Bitmap bitmap_ = Class26.bitmap_0;
				if (bitmap_ != null)
				{
					bitmap_.Dispose();
				}
				Bitmap bitmap_2 = Class26.bitmap_1;
				if (bitmap_2 != null)
				{
					bitmap_2.Dispose();
				}
				Bitmap bitmap_3 = Class26.bitmap_2;
				if (bitmap_3 != null)
				{
					bitmap_3.Dispose();
				}
				Bitmap bitmap_4 = Class26.bitmap_3;
				if (bitmap_4 != null)
				{
					bitmap_4.Dispose();
				}
				Mat mat_ = Class26.mat_1;
				if (mat_ != null)
				{
					mat_.Dispose();
				}
				Mat mat_2 = Class26.mat_8;
				if (mat_2 != null)
				{
					mat_2.Dispose();
				}
				Mat mat_3 = Class26.mat_10;
				if (mat_3 != null)
				{
					mat_3.Dispose();
				}
				Mat mat_4 = Class26.mat_9;
				if (mat_4 != null)
				{
					mat_4.Dispose();
				}
				foreach (Mat mat in Class26.mat_12)
				{
					if (mat != null)
					{
						mat.Dispose();
					}
				}
				foreach (Mat mat2 in Class26.mat_14)
				{
					if (mat2 != null)
					{
						mat2.Dispose();
					}
				}
				foreach (Bitmap bitmap in Class26.bitmap_5)
				{
					if (bitmap != null)
					{
						bitmap.Dispose();
					}
				}
				foreach (Mat mat3 in Class26.mat_13)
				{
					if (mat3 != null)
					{
						mat3.Dispose();
					}
				}
				Class46.smethod_9(Keys.Space, null, false, true);
				Class46.smethod_9(Keys.A, null, false, true);
				Class46.smethod_9(Keys.D, null, false, true);
			}

			// Token: 0x040002CE RID: 718
			public static readonly Class26.Class27 class27_0 = new Class26.Class27();

			// Token: 0x040002CF RID: 719
			public static Action action_0;
		}

		// Token: 0x0200004D RID: 77
		[CompilerGenerated]
		private sealed class Class28
		{
			// Token: 0x06000258 RID: 600 RVA: 0x000040DD File Offset: 0x000022DD
			internal bool method_0(KeyValuePair<string, string> keyValuePair_0)
			{
				return keyValuePair_0.Value == this.string_0;
			}

			// Token: 0x040002D0 RID: 720
			public string string_0;
		}
	}
}
