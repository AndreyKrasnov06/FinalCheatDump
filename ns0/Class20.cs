using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace ns0
{
	// Token: 0x0200003F RID: 63
	internal class Class20 : IDisposable
	{
		// Token: 0x060001F5 RID: 501 RVA: 0x00015108 File Offset: 0x00013308
		private static Random smethod_0()
		{
			byte[] array = new byte[4];
			using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
			{
				randomNumberGenerator.GetBytes(array);
			}
			return new Random(BitConverter.ToInt32(array, 0));
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00019084 File Offset: 0x00017284
		public Class20(Class76 class76_1, CancellationToken cancellationToken_1)
		{
			Class20.cancellationToken_0 = cancellationToken_1;
			this.class76_0 = class76_1;
			this.class42_0 = new Class42(class76_1, cancellationToken_1);
			this.method_0();
			this.method_1((class76_1.Width == 1360) ? "1366x768" : class76_1.Resolution);
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x000190D8 File Offset: 0x000172D8
		private void method_0()
		{
			this.dictionary_0 = new Dictionary<Class20.Enum1, Rectangle>
			{
				{
					Class20.Enum1.const_0,
					Class50.smethod_3(this.class76_0, "regionHunger")
				},
				{
					Class20.Enum1.const_1,
					Class50.smethod_3(this.class76_0, "regionThirst")
				},
				{
					Class20.Enum1.const_2,
					Class50.smethod_3(this.class76_0, "regionHealth")
				}
			};
			this.rect_0 = Class50.smethod_4(this.class76_0, "regionInventory");
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0001914C File Offset: 0x0001734C
		private void method_1(string string_0)
		{
			this.list_0 = new List<Class20.Class21>
			{
				new Class20.Class21("Steak", Class50.smethod_2(string_0, "steak"), 75, -10, 0, 6000),
				new Class20.Class21("Pizza", Class50.smethod_2(string_0, "pizza"), 50, -15, 0, 6000),
				new Class20.Class21("Donuts", Class50.smethod_2(string_0, "donuts"), 20, -20, 0, 6000),
				new Class20.Class21("Burger", Class50.smethod_2(string_0, "burger"), 45, -15, 0, 6000),
				new Class20.Class21("MRE", Class50.smethod_2(string_0, "mre"), 100, 100, 0, 6000),
				new Class20.Class21("FriedFish", Class50.smethod_2(string_0, "fried_fish"), 75, -20, 0, 6000),
				new Class20.Class21("Tandoori", Class50.smethod_2(string_0, "tandoori"), 70, 70, 10, 6000),
				new Class20.Class21("Salad", Class50.smethod_2(string_0, "salad"), 25, 10, 0, 6000),
				new Class20.Class21("Cocktail", Class50.smethod_2(string_0, "cocktail"), 5, 50, 0, 6000),
				new Class20.Class21("Cola", Class50.smethod_2(string_0, "cola"), 0, 40, 0, 6000),
				new Class20.Class21("Biolink", Class50.smethod_2(string_0, "biolink"), 100, 100, 0, 6000),
				new Class20.Class21("Flask", Class50.smethod_2(string_0, "flask"), 0, 100, 0, 6000),
				new Class20.Class21("Churrasco", Class50.smethod_2(string_0, "churrasco"), 70, 70, 10, 6000),
				new Class20.Class21("Pie", Class50.smethod_2(string_0, "pie"), 25, -10, 0, 6000),
				new Class20.Class21("Tost", Class50.smethod_2(string_0, "tost"), 20, -10, 0, 6000),
				new Class20.Class21("Pancakes", Class50.smethod_2(string_0, "pancakes"), 15, -10, 0, 6000),
				new Class20.Class21("Shawarma", Class50.smethod_2(string_0, "shawarma"), 45, -10, 0, 6000),
				new Class20.Class21("EgoChaser", Class50.smethod_2(string_0, "ego_chaser"), 30, -10, 5, 6000),
				new Class20.Class21("Meteorite", Class50.smethod_2(string_0, "meteorite"), 40, -10, 5, 6000),
				new Class20.Class21("Coffe", Class50.smethod_2(string_0, "coffe"), 0, 25, 0, 6000),
				new Class20.Class21("Milk", Class50.smethod_2(string_0, "milk"), 4, 20, 0, 6000),
				new Class20.Class21("Bandage", Class50.smethod_2(string_0, "bandage"), 0, 0, 25, 10000),
				new Class20.Class21("FirstAidKit", Class50.smethod_2(string_0, "first_aid_kit"), 0, 0, 50, 10000),
				new Class20.Class21("GrandCola", Class50.smethod_2(string_0, "grand_cola"), -20, -20, 50, 10000)
			};
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x000194D8 File Offset: 0x000176D8
		public bool method_2()
		{
			this.class42_0.method_0();
			Class20.smethod_1(2000.0, 2250.0);
			this.method_11();
			int num = this.dictionary_1[Class20.Enum1.const_0];
			int num2 = this.dictionary_1[Class20.Enum1.const_1];
			this.method_3(Class20.Enum1.const_0);
			this.method_3(Class20.Enum1.const_1);
			this.method_3(Class20.Enum1.const_2);
			this.method_11();
			this.class42_0.method_1();
			Class20.smethod_1(2000.0, 2250.0);
			return num > this.dictionary_1[Class20.Enum1.const_0] || num2 > this.dictionary_1[Class20.Enum1.const_1];
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00019584 File Offset: 0x00017784
		private void method_3(Class20.Enum1 enum1_0)
		{
			foreach (Class20.Class21 @class in this.method_7(enum1_0))
			{
				while (this.method_5(@class))
				{
					Class20.smethod_1((double)this.int_0, 0.0);
					if (!this.method_6(@class))
					{
						break;
					}
				}
			}
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00002C1B File Offset: 0x00000E1B
		private void method_4()
		{
		}

		// Token: 0x060001FC RID: 508 RVA: 0x000195FC File Offset: 0x000177FC
		private bool method_5(Class20.Class21 class21_0)
		{
			if ((class21_0.Name == "Tandoori" || class21_0.Name == "Churrasco" || class21_0.Name == "Salad") && class21_0.ThirstRestore > 0)
			{
				return this.dictionary_1[Class20.Enum1.const_0] != 100;
			}
			if (class21_0.IsMRE || class21_0.IsBiolink)
			{
				return this.dictionary_1[Class20.Enum1.const_0] == 0 || this.dictionary_1[Class20.Enum1.const_1] == 0;
			}
			if (class21_0.HungerRestore > 0 && this.dictionary_1[Class20.Enum1.const_0] + class21_0.HungerRestore > 90 && (class21_0.Name != "Cocktail" || class21_0.Name != "Milk"))
			{
				return false;
			}
			if (class21_0.ThirstRestore > 0 && this.dictionary_1[Class20.Enum1.const_1] + class21_0.ThirstRestore > 100)
			{
				return false;
			}
			if (class21_0.HealthRestore > 0)
			{
				return this.dictionary_1[Class20.Enum1.const_2] + class21_0.HealthRestore <= 100;
			}
			return class21_0.HungerRestore > 0 || class21_0.ThirstRestore > 0 || class21_0.HealthRestore > 0;
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0001973C File Offset: 0x0001793C
		private bool method_6(Class20.Class21 class21_0)
		{
			if (!this.method_9(class21_0))
			{
				return false;
			}
			if (class21_0.HungerRestore != 0)
			{
				int num = Math.Max(0, Math.Min(100, this.dictionary_1[Class20.Enum1.const_0] + class21_0.HungerRestore));
				this.dictionary_1[Class20.Enum1.const_0] = num;
			}
			if (class21_0.ThirstRestore != 0)
			{
				int num2 = Math.Max(0, Math.Min(100, this.dictionary_1[Class20.Enum1.const_1] + class21_0.ThirstRestore));
				this.dictionary_1[Class20.Enum1.const_1] = num2;
			}
			if (class21_0.HealthRestore > 0)
			{
				int num3 = Math.Min(100, this.dictionary_1[Class20.Enum1.const_2] + class21_0.HealthRestore);
				this.dictionary_1[Class20.Enum1.const_2] = num3;
			}
			return true;
		}

		// Token: 0x060001FE RID: 510 RVA: 0x000197F4 File Offset: 0x000179F4
		private List<Class20.Class21> method_7(Class20.Enum1 enum1_0)
		{
			Class20.Class22 @class = new Class20.Class22();
			@class.class20_0 = this;
			@class.enum1_0 = enum1_0;
			return this.list_0.Where(new Func<Class20.Class21, bool>(@class.method_0)).OrderByDescending(new Func<Class20.Class21, int>(@class.method_1)).ToList<Class20.Class21>();
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00003E7B File Offset: 0x0000207B
		private int method_8(Class20.Enum1 enum1_0, Class20.Class21 class21_0)
		{
			switch (enum1_0)
			{
			case Class20.Enum1.const_0:
				return class21_0.HungerRestore;
			case Class20.Enum1.const_1:
				return class21_0.ThirstRestore;
			case Class20.Enum1.const_2:
				return class21_0.HealthRestore;
			default:
				return 0;
			}
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00019844 File Offset: 0x00017A44
		private bool method_9(Class20.Class21 class21_0)
		{
			bool flag;
			try
			{
				Point point;
				if (Class40.smethod_13(class21_0.Image, this.rect_0, 0.8, false, out point, this.class76_0))
				{
					Point point2 = new Point
					{
						X = this.rect_0.X + point.X + class21_0.Image.Width / 2 + Class20.random_0.Next(-10, 11),
						Y = this.rect_0.Y + point.Y + class21_0.Image.Height / 2 + Class20.random_0.Next(-10, 11)
					};
					this.class42_0.method_2(point2);
					this.int_0 = class21_0.Pause;
					flag = true;
				}
				else
				{
					this.int_0 = 0;
					flag = false;
				}
			}
			catch (Exception)
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00019930 File Offset: 0x00017B30
		private void method_10()
		{
			Mat mat = BitmapConverter.ToMat(Class40.smethod_2(this.class76_0));
			foreach (Class20.Class21 @class in this.list_0)
			{
				Point point;
				if (Class40.smethod_16(@class.Image, this.rect_0, 0.8, false, out point, mat))
				{
					Point point2 = default(Point);
					point2.X = this.rect_0.X + point.X + @class.Image.Width / 2 + Class20.random_0.Next(-10, 11);
					point2.Y = this.rect_0.Y + point.Y + @class.Image.Height / 2 + Class20.random_0.Next(-10, 11);
				}
				Class20.smethod_1(10000.0, 0.0);
			}
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00003EA5 File Offset: 0x000020A5
		private void method_11()
		{
			this.dictionary_1 = new Dictionary<Class20.Enum1, int>
			{
				{
					Class20.Enum1.const_0,
					this.method_12(Class20.Enum1.const_0)
				},
				{
					Class20.Enum1.const_1,
					this.method_12(Class20.Enum1.const_1)
				},
				{
					Class20.Enum1.const_2,
					this.method_12(Class20.Enum1.const_2)
				}
			};
		}

		// Token: 0x06000203 RID: 515 RVA: 0x00019A44 File Offset: 0x00017C44
		private int method_12(Class20.Enum1 enum1_0)
		{
			return (int)Math.Round((double)Class40.smethod_26(new Dictionary<Class20.Enum1, Color>
			{
				{
					Class20.Enum1.const_0,
					Color.FromArgb(255, 198, 64)
				},
				{
					Class20.Enum1.const_1,
					Color.FromArgb(64, 182, 255)
				},
				{
					Class20.Enum1.const_2,
					Color.FromArgb(255, 64, 64)
				}
			}[enum1_0], 25, this.dictionary_0[enum1_0], this.class76_0) / (double)(this.dictionary_0[enum1_0].Width - 1) * 100.0) / this.dictionary_0[enum1_0].Height;
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00003EDC File Offset: 0x000020DC
		public void Dispose()
		{
			if (this.bool_0)
			{
				return;
			}
			this.bool_0 = true;
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000205 RID: 517 RVA: 0x00019AF8 File Offset: 0x00017CF8
		private static void smethod_1(double double_0, double double_1 = 0.0)
		{
			if (Class20.cancellationToken_0.IsCancellationRequested)
			{
				throw new Form1.GException0();
			}
			double num3;
			if (double_1 > 0.0)
			{
				double num = Math.Min(double_0, double_1);
				double num2 = Math.Max(double_0, double_1);
				num3 = num + Class20.random_0.NextDouble() * (num2 - num);
			}
			else
			{
				num3 = double_0;
			}
			int i = (int)Math.Floor(num3);
			double num4 = num3 - (double)i;
			int num5 = 50;
			while (i > 0)
			{
				if (Class20.cancellationToken_0.IsCancellationRequested)
				{
					throw new Form1.GException0();
				}
				int num6 = Math.Min(num5, i);
				Thread.Sleep(num6);
				i -= num6;
			}
			if (num4 > 0.0)
			{
				Stopwatch stopwatch = Stopwatch.StartNew();
				double num7 = num4 / 1000.0 * (double)Stopwatch.Frequency;
				while ((double)stopwatch.ElapsedTicks < num7)
				{
					if (Class20.cancellationToken_0.IsCancellationRequested)
					{
						throw new Form1.GException0();
					}
					Thread.SpinWait(10);
				}
			}
		}

		// Token: 0x04000237 RID: 567
		private bool bool_0;

		// Token: 0x04000238 RID: 568
		private static CancellationToken cancellationToken_0;

		// Token: 0x04000239 RID: 569
		private readonly Class76 class76_0;

		// Token: 0x0400023A RID: 570
		private Dictionary<Class20.Enum1, Rectangle> dictionary_0;

		// Token: 0x0400023B RID: 571
		private Dictionary<Class20.Enum1, int> dictionary_1;

		// Token: 0x0400023C RID: 572
		private List<Class20.Class21> list_0;

		// Token: 0x0400023D RID: 573
		private Rect rect_0;

		// Token: 0x0400023E RID: 574
		private static readonly Random random_0 = Class20.smethod_0();

		// Token: 0x0400023F RID: 575
		private readonly Class42 class42_0;

		// Token: 0x04000240 RID: 576
		private int int_0;

		// Token: 0x02000040 RID: 64
		private class Exception0 : Exception
		{
		}

		// Token: 0x02000041 RID: 65
		private class Class21 : IDisposable
		{
			// Token: 0x17000065 RID: 101
			// (get) Token: 0x06000208 RID: 520 RVA: 0x00003F08 File Offset: 0x00002108
			public string Name { get; }

			// Token: 0x17000066 RID: 102
			// (get) Token: 0x06000209 RID: 521 RVA: 0x00003F10 File Offset: 0x00002110
			public Mat Image { get; }

			// Token: 0x17000067 RID: 103
			// (get) Token: 0x0600020A RID: 522 RVA: 0x00003F18 File Offset: 0x00002118
			public int HungerRestore { get; }

			// Token: 0x17000068 RID: 104
			// (get) Token: 0x0600020B RID: 523 RVA: 0x00003F20 File Offset: 0x00002120
			public int ThirstRestore { get; }

			// Token: 0x17000069 RID: 105
			// (get) Token: 0x0600020C RID: 524 RVA: 0x00003F28 File Offset: 0x00002128
			public int HealthRestore { get; }

			// Token: 0x1700006A RID: 106
			// (get) Token: 0x0600020D RID: 525 RVA: 0x00003F30 File Offset: 0x00002130
			public int Pause { get; }

			// Token: 0x1700006B RID: 107
			// (get) Token: 0x0600020E RID: 526 RVA: 0x00003F38 File Offset: 0x00002138
			public bool IsMRE
			{
				get
				{
					return this.Name == "MRE";
				}
			}

			// Token: 0x1700006C RID: 108
			// (get) Token: 0x0600020F RID: 527 RVA: 0x00003F4A File Offset: 0x0000214A
			public bool IsBiolink
			{
				get
				{
					return this.Name == "Biolink";
				}
			}

			// Token: 0x06000210 RID: 528 RVA: 0x00003F5C File Offset: 0x0000215C
			public Class21(string string_1, Mat mat_1, int int_4 = 0, int int_5 = 0, int int_6 = 0, int int_7 = 6000)
			{
				this.Name = string_1;
				this.Image = mat_1;
				this.HungerRestore = int_4;
				this.ThirstRestore = int_5;
				this.HealthRestore = int_6;
				this.Pause = int_7;
			}

			// Token: 0x06000211 RID: 529 RVA: 0x00003F91 File Offset: 0x00002191
			public void Dispose()
			{
				Mat image = this.Image;
				if (image == null)
				{
					return;
				}
				image.Dispose();
			}

			// Token: 0x04000241 RID: 577
			[CompilerGenerated]
			private readonly string string_0;

			// Token: 0x04000242 RID: 578
			[CompilerGenerated]
			private readonly Mat mat_0;

			// Token: 0x04000243 RID: 579
			[CompilerGenerated]
			private readonly int int_0;

			// Token: 0x04000244 RID: 580
			[CompilerGenerated]
			private readonly int int_1;

			// Token: 0x04000245 RID: 581
			[CompilerGenerated]
			private readonly int int_2;

			// Token: 0x04000246 RID: 582
			[CompilerGenerated]
			private readonly int int_3;
		}

		// Token: 0x02000042 RID: 66
		private enum Enum1
		{
			// Token: 0x04000248 RID: 584
			const_0,
			// Token: 0x04000249 RID: 585
			const_1,
			// Token: 0x0400024A RID: 586
			const_2
		}

		// Token: 0x02000043 RID: 67
		[CompilerGenerated]
		private sealed class Class22
		{
			// Token: 0x06000213 RID: 531 RVA: 0x00003FA3 File Offset: 0x000021A3
			internal bool method_0(Class20.Class21 class21_0)
			{
				return this.class20_0.method_8(this.enum1_0, class21_0) > 0;
			}

			// Token: 0x06000214 RID: 532 RVA: 0x00003FBA File Offset: 0x000021BA
			internal int method_1(Class20.Class21 class21_0)
			{
				return this.class20_0.method_8(this.enum1_0, class21_0);
			}

			// Token: 0x0400024B RID: 587
			public Class20 class20_0;

			// Token: 0x0400024C RID: 588
			public Class20.Enum1 enum1_0;
		}
	}
}
