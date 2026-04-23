using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using psClick;

namespace ns0
{
	// Token: 0x0200006F RID: 111
	internal class Class40
	{
		// Token: 0x0600037A RID: 890
		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr intptr_0);

		// Token: 0x0600037B RID: 891
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateCompatibleDC(IntPtr intptr_0);

		// Token: 0x0600037C RID: 892
		[DllImport("gdi32.dll")]
		private static extern bool BitBlt(IntPtr intptr_0, int int_2, int int_3, int int_4, int int_5, IntPtr intptr_1, int int_6, int int_7, uint uint_0);

		// Token: 0x0600037D RID: 893
		[DllImport("user32.dll")]
		private static extern int ReleaseDC(IntPtr intptr_0, IntPtr intptr_1);

		// Token: 0x0600037E RID: 894
		[DllImport("gdi32.dll")]
		private static extern bool DeleteDC(IntPtr intptr_0);

		// Token: 0x0600037F RID: 895 RVA: 0x0002F780 File Offset: 0x0002D980
		public static Bitmap smethod_0(Class76 class76_0, Rectangle rectangle_0 = default(Rectangle))
		{
			Bitmap bitmap;
			try
			{
				if (!class76_0.IsActive)
				{
					if (class76_0.method_4() == Class76.Enum5.const_0)
					{
						bitmap = Class40.smethod_8(class76_0, rectangle_0);
					}
					else
					{
						bitmap = null;
					}
				}
				else
				{
					class76_0.method_1();
					rectangle_0.X += class76_0.Left;
					rectangle_0.Y += class76_0.Top;
					int width = class76_0.Width;
					int height = class76_0.Height;
					int num = ((rectangle_0.Width > 0) ? rectangle_0.Width : width);
					int num2 = ((rectangle_0.Height > 0) ? rectangle_0.Height : height);
					if (num > 0 && num2 > 0)
					{
						using (Bitmap bitmap2 = new Bitmap(num, num2, PixelFormat.Format32bppArgb))
						{
							using (Graphics graphics = Graphics.FromImage(bitmap2))
							{
								Rectangle rectangle = new Rectangle(rectangle_0.X, rectangle_0.Y, num, num2);
								graphics.CopyFromScreen(rectangle.Location, Point.Empty, rectangle.Size);
							}
							return new Bitmap(bitmap2);
						}
					}
					bitmap = null;
				}
			}
			catch (Form1.GException0)
			{
				throw;
			}
			catch (Exception)
			{
				bitmap = null;
			}
			return bitmap;
		}

		// Token: 0x06000380 RID: 896 RVA: 0x0002F904 File Offset: 0x0002DB04
		public static Bitmap smethod_1(Class76 class76_0, Rectangle rectangle_0 = default(Rectangle))
		{
			Bitmap bitmap;
			try
			{
				if (!class76_0.IsActive)
				{
					if (class76_0.method_4() == Class76.Enum5.const_0)
					{
						bitmap = Class40.smethod_8(class76_0, rectangle_0);
					}
					else
					{
						bitmap = null;
					}
				}
				else
				{
					class76_0.method_1();
					rectangle_0.X += class76_0.Left;
					rectangle_0.Y += class76_0.Top;
					int width = class76_0.Width;
					int height = class76_0.Height;
					int num = ((rectangle_0.Width > 0) ? rectangle_0.Width : width);
					int num2 = ((rectangle_0.Height > 0) ? rectangle_0.Height : height);
					if (num > 0 && num2 > 0)
					{
						using (Bitmap bitmap2 = new Bitmap(num, num2, PixelFormat.Format32bppArgb))
						{
							using (Graphics graphics = Graphics.FromImage(bitmap2))
							{
								Rectangle rectangle = new Rectangle(rectangle_0.X, rectangle_0.Y, num, num2);
								graphics.CopyFromScreen(rectangle.Location, Point.Empty, rectangle.Size);
							}
							return new Bitmap(bitmap2);
						}
					}
					bitmap = null;
				}
			}
			catch (Form1.GException0)
			{
				throw;
			}
			catch
			{
				bitmap = null;
			}
			return bitmap;
		}

		// Token: 0x06000381 RID: 897 RVA: 0x0002FA88 File Offset: 0x0002DC88
		public static Bitmap smethod_2(Class76 class76_0)
		{
			Bitmap bitmap;
			try
			{
				Rectangle rectangle = default(Rectangle);
				if (!class76_0.IsActive)
				{
					if (class76_0.method_4() == Class76.Enum5.const_0)
					{
						bitmap = Class40.smethod_8(class76_0, rectangle);
					}
					else
					{
						bitmap = null;
					}
				}
				else
				{
					class76_0.method_1();
					int num = ((rectangle.Width > 0) ? rectangle.Width : class76_0.Width);
					int num2 = ((rectangle.Height > 0) ? rectangle.Height : class76_0.Height);
					if (Class40.bitmap_0 == null || num != Class40.int_0 || num2 != Class40.int_1)
					{
						Class40.smethod_7();
						Class40.bitmap_0 = new Bitmap(num, num2, PixelFormat.Format32bppArgb);
						Class40.graphics_0 = Graphics.FromImage(Class40.bitmap_0);
						Class40.int_0 = num;
						Class40.int_1 = num2;
					}
					Rectangle rectangle2 = new Rectangle(rectangle.X + class76_0.Left, rectangle.Y + class76_0.Top, num, num2);
					Class40.graphics_0.CopyFromScreen(rectangle2.Location, Point.Empty, new Size(num, num2));
					bitmap = (Bitmap)Class40.bitmap_0.Clone();
				}
			}
			catch (Form1.GException0)
			{
				throw;
			}
			catch
			{
				bitmap = null;
			}
			return bitmap;
		}

		// Token: 0x06000382 RID: 898 RVA: 0x0002FBDC File Offset: 0x0002DDDC
		public static Mat smethod_3(Class76 class76_0)
		{
			Mat mat;
			try
			{
				Rectangle rectangle = default(Rectangle);
				if (!class76_0.IsActive)
				{
					if (class76_0.method_4() == Class76.Enum5.const_0)
					{
						mat = BitmapConverter.ToMat(Class40.smethod_8(class76_0, rectangle));
					}
					else
					{
						mat = null;
					}
				}
				else
				{
					class76_0.method_1();
					int num = ((rectangle.Width > 0) ? rectangle.Width : class76_0.Width);
					int num2 = ((rectangle.Height > 0) ? rectangle.Height : class76_0.Height);
					if (Class40.bitmap_0 == null || num != Class40.int_0 || num2 != Class40.int_1)
					{
						Class40.smethod_7();
						Class40.bitmap_0 = new Bitmap(num, num2, PixelFormat.Format32bppArgb);
						Class40.graphics_0 = Graphics.FromImage(Class40.bitmap_0);
						Class40.int_0 = num;
						Class40.int_1 = num2;
					}
					Rectangle rectangle2 = new Rectangle(rectangle.X + class76_0.Left, rectangle.Y + class76_0.Top, num, num2);
					Class40.graphics_0.CopyFromScreen(rectangle2.Location, Point.Empty, new Size(num, num2));
					mat = BitmapConverter.ToMat((Bitmap)Class40.bitmap_0.Clone());
				}
			}
			catch (Form1.GException0)
			{
				throw;
			}
			catch
			{
				mat = null;
			}
			return mat;
		}

		// Token: 0x06000383 RID: 899 RVA: 0x0002FD38 File Offset: 0x0002DF38
		public static Mat smethod_4(Class76 class76_0, Rect rect_0 = default(Rect))
		{
			Mat mat;
			try
			{
				if (!class76_0.IsActive)
				{
					if (class76_0.method_4() == Class76.Enum5.const_0)
					{
						mat = BitmapConverter.ToMat(Class40.smethod_9(class76_0, rect_0));
					}
					else
					{
						mat = null;
					}
				}
				else
				{
					class76_0.method_1();
					int num = ((rect_0.Width > 0) ? rect_0.Width : class76_0.Width);
					int num2 = ((rect_0.Height > 0) ? rect_0.Height : class76_0.Height);
					if (Class40.bitmap_0 == null || num != Class40.int_0 || num2 != Class40.int_1)
					{
						Class40.smethod_7();
						Class40.bitmap_0 = new Bitmap(num, num2, PixelFormat.Format32bppArgb);
						Class40.graphics_0 = Graphics.FromImage(Class40.bitmap_0);
						Class40.int_0 = num;
						Class40.int_1 = num2;
					}
					Rectangle rectangle = new Rectangle(rect_0.X + class76_0.Left, rect_0.Y + class76_0.Top, num, num2);
					Class40.graphics_0.CopyFromScreen(rectangle.Location, Point.Empty, new Size(num, num2));
					mat = BitmapConverter.ToMat((Bitmap)Class40.bitmap_0.Clone());
				}
			}
			catch (Form1.GException0)
			{
				throw;
			}
			catch
			{
				mat = null;
			}
			return mat;
		}

		// Token: 0x06000384 RID: 900 RVA: 0x0002FE6C File Offset: 0x0002E06C
		public static Bitmap smethod_5(Class76 class76_0, Rectangle rectangle_0 = default(Rectangle))
		{
			Bitmap bitmap;
			try
			{
				if (!class76_0.IsActive)
				{
					if (class76_0.method_4() == Class76.Enum5.const_0)
					{
						bitmap = Class40.smethod_8(class76_0, rectangle_0);
					}
					else
					{
						bitmap = null;
					}
				}
				else
				{
					class76_0.method_1();
					int num = ((rectangle_0.Width > 0) ? rectangle_0.Width : class76_0.Width);
					int num2 = ((rectangle_0.Height > 0) ? rectangle_0.Height : class76_0.Height);
					if (Class40.bitmap_0 == null || num != Class40.int_0 || num2 != Class40.int_1)
					{
						Class40.smethod_7();
						Class40.bitmap_0 = new Bitmap(num, num2, PixelFormat.Format32bppArgb);
						Class40.graphics_0 = Graphics.FromImage(Class40.bitmap_0);
						Class40.int_0 = num;
						Class40.int_1 = num2;
					}
					Rectangle rectangle = new Rectangle(rectangle_0.X + class76_0.Left, rectangle_0.Y + class76_0.Top, num, num2);
					Class40.graphics_0.CopyFromScreen(rectangle.Location, Point.Empty, new Size(num, num2));
					bitmap = (Bitmap)Class40.bitmap_0.Clone();
				}
			}
			catch (Form1.GException0)
			{
				throw;
			}
			catch
			{
				bitmap = null;
			}
			return bitmap;
		}

		// Token: 0x06000385 RID: 901 RVA: 0x0002FF9C File Offset: 0x0002E19C
		public static Bitmap smethod_6(Class76 class76_0, Rect rect_0 = default(Rect))
		{
			Bitmap bitmap;
			try
			{
				if (!class76_0.IsActive)
				{
					if (class76_0.method_4() == Class76.Enum5.const_0)
					{
						bitmap = Class40.smethod_9(class76_0, rect_0);
					}
					else
					{
						bitmap = null;
					}
				}
				else
				{
					class76_0.method_1();
					int num = ((rect_0.Width > 0) ? rect_0.Width : class76_0.Width);
					int num2 = ((rect_0.Height > 0) ? rect_0.Height : class76_0.Height);
					if (Class40.bitmap_0 == null || num != Class40.int_0 || num2 != Class40.int_1)
					{
						Class40.smethod_7();
						Class40.bitmap_0 = new Bitmap(num, num2, PixelFormat.Format32bppArgb);
						Class40.graphics_0 = Graphics.FromImage(Class40.bitmap_0);
						Class40.int_0 = num;
						Class40.int_1 = num2;
					}
					Rectangle rectangle = new Rectangle(rect_0.X + class76_0.Left, rect_0.Y + class76_0.Top, num, num2);
					Class40.graphics_0.CopyFromScreen(rectangle.Location, Point.Empty, new Size(num, num2));
					bitmap = (Bitmap)Class40.bitmap_0.Clone();
				}
			}
			catch (Form1.GException0)
			{
				throw;
			}
			catch
			{
				bitmap = null;
			}
			return bitmap;
		}

		// Token: 0x06000386 RID: 902 RVA: 0x00004D40 File Offset: 0x00002F40
		public static void smethod_7()
		{
			Graphics graphics = Class40.graphics_0;
			if (graphics != null)
			{
				graphics.Dispose();
			}
			Bitmap bitmap = Class40.bitmap_0;
			if (bitmap != null)
			{
				bitmap.Dispose();
			}
			Class40.graphics_0 = null;
			Class40.bitmap_0 = null;
			Class40.int_0 = 0;
			Class40.int_1 = 0;
		}

		// Token: 0x06000387 RID: 903 RVA: 0x000300C4 File Offset: 0x0002E2C4
		public static Bitmap smethod_8(Class76 class76_0, Rectangle rectangle_0 = default(Rectangle))
		{
			Bitmap bitmap;
			try
			{
				class76_0.method_1();
				int num = ((rectangle_0.Width > 0) ? rectangle_0.Width : class76_0.Width);
				int num2 = ((rectangle_0.Height > 0) ? rectangle_0.Height : class76_0.Height);
				IntPtr handle = class76_0.Handle;
				IntPtr dc = Class40.GetDC(handle);
				if (dc == IntPtr.Zero)
				{
					bitmap = null;
				}
				else
				{
					IntPtr intPtr = Class40.CreateCompatibleDC(dc);
					if (intPtr == IntPtr.Zero)
					{
						Class40.ReleaseDC(handle, dc);
						bitmap = null;
					}
					else
					{
						Bitmap bitmap2 = new Bitmap(num, num2, PixelFormat.Format32bppArgb);
						using (Graphics graphics = Graphics.FromImage(bitmap2))
						{
							IntPtr hdc = graphics.GetHdc();
							if (!Class40.BitBlt(hdc, 0, 0, num, num2, dc, rectangle_0.X, rectangle_0.Y, 13369376U))
							{
								Class40.ReleaseDC(handle, dc);
								Class40.DeleteDC(intPtr);
								return null;
							}
							graphics.ReleaseHdc(hdc);
						}
						Class40.ReleaseDC(handle, dc);
						Class40.DeleteDC(intPtr);
						bitmap = bitmap2;
					}
				}
			}
			catch (Form1.GException0)
			{
				throw;
			}
			catch
			{
				bitmap = null;
			}
			return bitmap;
		}

		// Token: 0x06000388 RID: 904 RVA: 0x00030230 File Offset: 0x0002E430
		public static Bitmap smethod_9(Class76 class76_0, Rect rect_0 = default(Rect))
		{
			Bitmap bitmap;
			try
			{
				class76_0.method_1();
				int num = ((rect_0.Width > 0) ? rect_0.Width : class76_0.Width);
				int num2 = ((rect_0.Height > 0) ? rect_0.Height : class76_0.Height);
				IntPtr handle = class76_0.Handle;
				IntPtr dc = Class40.GetDC(handle);
				if (dc == IntPtr.Zero)
				{
					bitmap = null;
				}
				else
				{
					IntPtr intPtr = Class40.CreateCompatibleDC(dc);
					if (intPtr == IntPtr.Zero)
					{
						Class40.ReleaseDC(handle, dc);
						bitmap = null;
					}
					else
					{
						Bitmap bitmap2 = new Bitmap(num, num2, PixelFormat.Format32bppArgb);
						using (Graphics graphics = Graphics.FromImage(bitmap2))
						{
							IntPtr hdc = graphics.GetHdc();
							if (!Class40.BitBlt(hdc, 0, 0, num, num2, dc, rect_0.X, rect_0.Y, 13369376U))
							{
								Class40.ReleaseDC(handle, dc);
								Class40.DeleteDC(intPtr);
								return null;
							}
							graphics.ReleaseHdc(hdc);
						}
						Class40.ReleaseDC(handle, dc);
						Class40.DeleteDC(intPtr);
						bitmap = bitmap2;
					}
				}
			}
			catch
			{
				bitmap = null;
			}
			return bitmap;
		}

		// Token: 0x06000389 RID: 905 RVA: 0x0003037C File Offset: 0x0002E57C
		public static bool smethod_10(Mat[] mat_0, Rect rect_0, double double_0, bool bool_0, out Point point_0, Class76 class76_0)
		{
			point_0 = new Point(-1, -1);
			bool flag;
			try
			{
				if (mat_0 != null && mat_0.Length != 0)
				{
					using (Bitmap bitmap = Class40.smethod_5(class76_0, Class16.smethod_4(rect_0)))
					{
						if (bitmap == null)
						{
							return false;
						}
						using (Mat mat = BitmapConverter.ToMat(bitmap))
						{
							using (Mat mat2 = new Mat())
							{
								Cv2.CvtColor(mat, mat2, 6, 0);
								foreach (Mat mat3 in mat_0)
								{
									if (mat3 != null && !mat3.Empty())
									{
										using (Mat mat4 = new Mat())
										{
											using (Mat mat5 = new Mat())
											{
												Cv2.CvtColor(mat3, mat4, 6, 0);
												if (bool_0)
												{
													using (Mat mat6 = Class40.smethod_12(mat3, new Scalar(255.0, 242.0, 0.0)))
													{
														Cv2.MatchTemplate(mat2, mat4, mat5, 5, mat6);
														goto IL_0111;
													}
												}
												Cv2.MatchTemplate(mat2, mat4, mat5, 5, null);
												IL_0111:
												double num;
												double num2;
												Point point;
												Point point2;
												Cv2.MinMaxLoc(mat5, ref num, ref num2, ref point, ref point2, null);
												if (num2 >= double_0)
												{
													point_0 = new Point(point2.X, point2.Y);
													return true;
												}
											}
										}
									}
								}
							}
						}
						goto IL_01AA;
					}
					goto IL_019A;
					IL_01AA:
					return false;
				}
				IL_019A:
				throw new ArgumentException("Templates array cannot be null or empty.", "templates");
			}
			catch
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600038A RID: 906 RVA: 0x000305EC File Offset: 0x0002E7EC
		public static int smethod_11(Mat[] mat_0, Rect rect_0, double double_0, bool bool_0, out Point point_0, Class76 class76_0)
		{
			point_0 = new Point(-1, -1);
			int num3;
			try
			{
				if (mat_0 != null && mat_0.Length != 0)
				{
					using (Bitmap bitmap = Class40.smethod_5(class76_0, Class16.smethod_4(rect_0)))
					{
						if (bitmap == null)
						{
							return -1;
						}
						using (Mat mat = BitmapConverter.ToMat(bitmap))
						{
							using (Mat mat2 = new Mat())
							{
								Cv2.CvtColor(mat, mat2, 6, 0);
								for (int i = 0; i < mat_0.Length; i++)
								{
									Mat mat3 = mat_0[i];
									if (mat3 != null && !mat3.Empty())
									{
										using (Mat mat4 = new Mat())
										{
											using (Mat mat5 = new Mat())
											{
												Cv2.CvtColor(mat3, mat4, 6, 0);
												if (bool_0)
												{
													using (Mat mat6 = Class40.smethod_12(mat3, new Scalar(255.0, 242.0, 0.0)))
													{
														Cv2.MatchTemplate(mat2, mat4, mat5, 5, mat6);
														goto IL_010D;
													}
												}
												Cv2.MatchTemplate(mat2, mat4, mat5, 5, null);
												IL_010D:
												double num;
												double num2;
												Point point;
												Point point2;
												Cv2.MinMaxLoc(mat5, ref num, ref num2, ref point, ref point2, null);
												if (num2 >= double_0)
												{
													point_0 = new Point(point2.X, point2.Y);
													return i;
												}
											}
										}
									}
								}
							}
						}
						goto IL_01A6;
					}
					goto IL_0196;
					IL_01A6:
					return -1;
				}
				IL_0196:
				throw new ArgumentException("Templates array cannot be null or empty.", "templates");
			}
			catch
			{
				num3 = -1;
			}
			return num3;
		}

		// Token: 0x0600038B RID: 907 RVA: 0x00030858 File Offset: 0x0002EA58
		private static Mat smethod_12(Mat mat_0, Scalar scalar_0)
		{
			Mat mat = new Mat(mat_0.Size(), MatType.CV_8UC1, Scalar.All(255.0));
			using (Mat mat2 = new Mat())
			{
				Cv2.CvtColor(mat_0, mat2, 8, 0);
				for (int i = 0; i < mat2.Rows; i++)
				{
					for (int j = 0; j < mat2.Cols; j++)
					{
						Vec3b vec3b = mat2.Get<Vec3b>(i, j);
						if ((double)vec3b.Item0 == scalar_0.Val0 && (double)vec3b.Item1 == scalar_0.Val1 && (double)vec3b.Item2 == scalar_0.Val2)
						{
							mat.Set<int>(i, j, 0);
						}
					}
				}
			}
			return mat;
		}

		// Token: 0x0600038C RID: 908 RVA: 0x00030920 File Offset: 0x0002EB20
		public static bool smethod_13(Mat mat_0, Rect rect_0, double double_0, bool bool_0, out Point point_0, Class76 class76_0)
		{
			bool flag;
			try
			{
				Bitmap bitmap = Class40.smethod_5(class76_0, Class16.smethod_4(rect_0));
				if (bitmap != null)
				{
					Mat mat = BitmapConverter.ToMat(bitmap);
					Mat mat2 = new Mat();
					Mat mat3 = new Mat();
					Mat mat4 = new Mat();
					point_0 = new Point(-1, -1);
					try
					{
						Cv2.CvtColor(mat, mat2, 6, 0);
						Cv2.CvtColor(mat_0, mat3, 6, 0);
						if (bool_0)
						{
							Mat mat5 = new Mat(mat3.Size(), MatType.CV_8UC1, Scalar.All(255.0));
							Mat mat6 = new Mat();
							Cv2.CvtColor(mat3, mat6, 4, 0);
							for (int i = 0; i < mat6.Rows; i++)
							{
								for (int j = 0; j < mat6.Cols; j++)
								{
									Vec3b vec3b = mat6.Get<Vec3b>(i, j);
									if (vec3b.Item0 == 255 && vec3b.Item1 == 242 && vec3b.Item2 == 0)
									{
										mat5.Set<int>(i, j, 0);
									}
								}
							}
							Cv2.MatchTemplate(mat2, mat3, mat4, 5, mat5);
						}
						else
						{
							Cv2.MatchTemplate(mat2, mat3, mat4, 5, null);
						}
						double num;
						double num2;
						Point point;
						Point point2;
						Cv2.MinMaxLoc(mat4, ref num, ref num2, ref point, ref point2, null);
						if (num2 >= double_0)
						{
							point_0 = new Point(point2.X, point2.Y);
							return true;
						}
						return false;
					}
					finally
					{
						bitmap.Dispose();
						mat.Dispose();
						mat2.Dispose();
						mat3.Dispose();
						mat4.Dispose();
					}
				}
				point_0 = new Point(-1, -1);
				flag = false;
			}
			catch
			{
				point_0 = new Point(-1, -1);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600038D RID: 909 RVA: 0x00030B34 File Offset: 0x0002ED34
		public static bool smethod_14(Mat mat_0, Rect rect_0, double double_0, bool bool_0, out Point point_0, Class76 class76_0, CancellationToken cancellationToken_0, int int_2 = 5000, int int_3 = 100, bool bool_1 = false)
		{
			bool flag;
			try
			{
				DateTime now = DateTime.Now;
				point_0 = new Point(-1, -1);
				while ((DateTime.Now - now).TotalMilliseconds < (double)int_2 && !cancellationToken_0.IsCancellationRequested)
				{
					if (cancellationToken_0.IsCancellationRequested)
					{
						throw new Form1.GException0();
					}
					Bitmap bitmap = Class40.smethod_5(class76_0, Class16.smethod_4(rect_0));
					if (bitmap == null)
					{
						point_0 = new Point(-1, -1);
						return false;
					}
					Mat mat = BitmapConverter.ToMat(bitmap);
					Mat mat2 = new Mat();
					Mat mat3 = new Mat();
					Mat mat4 = new Mat();
					try
					{
						Cv2.CvtColor(mat, mat2, 6, 0);
						Cv2.CvtColor(mat_0, mat3, 6, 0);
						if (bool_0)
						{
							Mat mat5 = new Mat(mat3.Size(), MatType.CV_8UC1, Scalar.All(255.0));
							Mat mat6 = new Mat();
							Cv2.CvtColor(mat3, mat6, 4, 0);
							for (int i = 0; i < mat6.Rows; i++)
							{
								for (int j = 0; j < mat6.Cols; j++)
								{
									Vec3b vec3b = mat6.Get<Vec3b>(i, j);
									if (vec3b.Item0 == 255 && vec3b.Item1 == 242 && vec3b.Item2 == 0)
									{
										mat5.Set<int>(i, j, 0);
									}
								}
							}
							Cv2.MatchTemplate(mat2, mat3, mat4, 5, mat5);
						}
						else
						{
							Cv2.MatchTemplate(mat2, mat3, mat4, 5, null);
						}
						double num;
						double num2;
						Point point;
						Point point2;
						Cv2.MinMaxLoc(mat4, ref num, ref num2, ref point, ref point2, null);
						if (num2 >= double_0)
						{
							if (!bool_1)
							{
								point_0 = new Point(point2.X, point2.Y);
								return true;
							}
						}
						else if (bool_1)
						{
							return true;
						}
					}
					finally
					{
						bitmap.Dispose();
						mat.Dispose();
						mat2.Dispose();
						mat3.Dispose();
						mat4.Dispose();
					}
					Thread.Sleep(int_3);
				}
				flag = false;
			}
			catch
			{
				point_0 = new Point(-1, -1);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600038E RID: 910 RVA: 0x00030DAC File Offset: 0x0002EFAC
		public static bool smethod_15(Mat[] mat_0, Rect rect_0, double double_0, bool bool_0, out Point point_0, Class76 class76_0, CancellationToken cancellationToken_0, int int_2 = 5000, int int_3 = 100, bool bool_1 = false)
		{
			point_0 = new Point(-1, -1);
			bool flag2;
			try
			{
				if (mat_0 == null || mat_0.Length == 0)
				{
					throw new ArgumentException("Templates array cannot be null or empty.", "templates");
				}
				Stopwatch stopwatch = Stopwatch.StartNew();
				while (stopwatch.ElapsedMilliseconds < (long)int_2 && !cancellationToken_0.IsCancellationRequested)
				{
					if (cancellationToken_0.IsCancellationRequested)
					{
						throw new Form1.GException0();
					}
					using (Bitmap bitmap = Class40.smethod_5(class76_0, Class16.smethod_4(rect_0)))
					{
						if (bitmap == null)
						{
							return false;
						}
						using (Mat mat = BitmapConverter.ToMat(bitmap))
						{
							using (Mat mat2 = new Mat())
							{
								Cv2.CvtColor(mat, mat2, 6, 0);
								bool flag = false;
								foreach (Mat mat3 in mat_0)
								{
									if (cancellationToken_0.IsCancellationRequested)
									{
										return false;
									}
									if (mat3 != null && !mat3.Empty())
									{
										using (Mat mat4 = new Mat())
										{
											using (Mat mat5 = new Mat())
											{
												Cv2.CvtColor(mat3, mat4, 6, 0);
												if (bool_0)
												{
													using (Mat mat6 = Class40.smethod_12(mat3, new Scalar(255.0, 242.0, 0.0)))
													{
														Cv2.MatchTemplate(mat2, mat4, mat5, 5, mat6);
														goto IL_0147;
													}
												}
												Cv2.MatchTemplate(mat2, mat4, mat5, 5, null);
												IL_0147:
												double num;
												double num2;
												Point point;
												Point point2;
												Cv2.MinMaxLoc(mat5, ref num, ref num2, ref point, ref point2, null);
												if (num2 >= double_0)
												{
													flag = true;
													if (!bool_1)
													{
														point_0 = new Point(point2.X, point2.Y);
														return true;
													}
													break;
												}
											}
										}
										goto IL_01A7;
										IL_01BE:
										if (bool_1 && !flag)
										{
											return true;
										}
										goto IL_01D8;
									}
									IL_01A7:;
								}
								goto IL_01BE;
							}
							IL_01D8:;
						}
					}
					if (cancellationToken_0.IsCancellationRequested)
					{
						return false;
					}
					Thread.Sleep(int_3);
				}
				flag2 = false;
			}
			catch
			{
				flag2 = false;
			}
			return flag2;
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0003109C File Offset: 0x0002F29C
		public static bool smethod_16(Mat mat_0, Rect rect_0, double double_0, bool bool_0, out Point point_0, Mat mat_1)
		{
			if (mat_1 == null)
			{
				point_0 = new Point(-1, -1);
				return false;
			}
			bool flag;
			try
			{
				mat_1 = mat_1.Clone(rect_0);
				Mat mat = new Mat();
				Mat mat2 = new Mat();
				Mat mat3 = new Mat();
				point_0 = new Point(-1, -1);
				try
				{
					Cv2.CvtColor(mat_1, mat, 6, 0);
					Cv2.CvtColor(mat_0, mat2, 6, 0);
					if (bool_0)
					{
						Mat mat4 = new Mat(mat2.Size(), MatType.CV_8UC1, Scalar.All(255.0));
						Mat mat5 = new Mat();
						Cv2.CvtColor(mat2, mat5, 4, 0);
						for (int i = 0; i < mat5.Rows; i++)
						{
							for (int j = 0; j < mat5.Cols; j++)
							{
								Vec3b vec3b = mat5.Get<Vec3b>(i, j);
								if (vec3b.Item0 == 255 && vec3b.Item1 == 242 && vec3b.Item2 == 0)
								{
									mat4.Set<int>(i, j, 0);
								}
							}
						}
						Cv2.MatchTemplate(mat, mat2, mat3, 5, mat4);
					}
					else
					{
						Cv2.MatchTemplate(mat, mat2, mat3, 5, null);
					}
					double num;
					double num2;
					Point point;
					Point point2;
					Cv2.MinMaxLoc(mat3, ref num, ref num2, ref point, ref point2, null);
					if (num2 >= double_0)
					{
						point_0 = new Point(point2.X, point2.Y);
						flag = true;
					}
					else
					{
						flag = false;
					}
				}
				finally
				{
					mat.Dispose();
					mat2.Dispose();
					mat3.Dispose();
				}
			}
			catch
			{
				point_0 = new Point(-1, -1);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000390 RID: 912 RVA: 0x00031290 File Offset: 0x0002F490
		public static bool smethod_17(Mat mat_0, double double_0, bool bool_0, out Point point_0, Mat mat_1)
		{
			point_0 = new Point(-1, -1);
			if (mat_1 == null)
			{
				return false;
			}
			Mat mat = new Mat();
			Mat mat2 = new Mat();
			Mat mat3 = new Mat();
			bool flag;
			try
			{
				Cv2.CvtColor(mat_1, mat, 6, 0);
				Cv2.CvtColor(mat_0, mat2, 6, 0);
				if (bool_0)
				{
					Mat mat4 = new Mat(mat2.Size(), MatType.CV_8UC1, Scalar.All(255.0));
					Mat mat5 = new Mat();
					Cv2.CvtColor(mat2, mat5, 4, 0);
					for (int i = 0; i < mat5.Rows; i++)
					{
						for (int j = 0; j < mat5.Cols; j++)
						{
							Vec3b vec3b = mat5.Get<Vec3b>(i, j);
							if (vec3b.Item0 == 255 && vec3b.Item1 == 242 && vec3b.Item2 == 0)
							{
								mat4.Set<int>(i, j, 0);
							}
						}
					}
					Cv2.MatchTemplate(mat, mat2, mat3, 5, mat4);
				}
				else
				{
					Cv2.MatchTemplate(mat, mat2, mat3, 5, null);
				}
				double num;
				double num2;
				Point point;
				Point point2;
				Cv2.MinMaxLoc(mat3, ref num, ref num2, ref point, ref point2, null);
				if (num2 >= double_0)
				{
					point_0 = new Point(point2.X, point2.Y);
					flag = true;
				}
				else
				{
					flag = false;
				}
			}
			finally
			{
				mat.Dispose();
				mat2.Dispose();
				mat3.Dispose();
			}
			return flag;
		}

		// Token: 0x06000391 RID: 913 RVA: 0x0003143C File Offset: 0x0002F63C
		public static bool smethod_18(int int_2, int int_3, Bitmap bitmap_1, int int_4, out Point[] point_0, Rectangle rectangle_0, int int_5, int int_6, Class76 class76_0)
		{
			bool flag;
			try
			{
				using (Bitmap bitmap = Class40.smethod_5(class76_0, rectangle_0))
				{
					if (bitmap == null)
					{
						point_0 = null;
						flag = false;
					}
					else
					{
						if (int_4 == -2)
						{
							int_4 = 62207;
						}
						List<Hashtable> list = FindImage.FindBitmap(bitmap_1, bitmap, int_3, int_6, int_5, int_2, int_4, false);
						if (list.Count > 0)
						{
							point_0 = new Point[list.Count];
							for (int i = 0; i < list.Count; i++)
							{
								point_0[i] = (Point)list[i]["location"];
							}
							flag = true;
						}
						else
						{
							point_0 = null;
							flag = false;
						}
					}
				}
			}
			catch
			{
				point_0 = null;
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00031504 File Offset: 0x0002F704
		public static bool smethod_19(int int_2, int int_3, Bitmap bitmap_1, int int_4, out Point[] point_0, Rectangle rectangle_0, int int_5, int int_6, Class76 class76_0, CancellationToken cancellationToken_0, int int_7 = 5000, int int_8 = 100, bool bool_0 = false)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			point_0 = null;
			bool flag;
			try
			{
				while (stopwatch.ElapsedMilliseconds < (long)int_7)
				{
					if (cancellationToken_0.IsCancellationRequested)
					{
						return false;
					}
					if (Class40.smethod_18(int_2, int_3, bitmap_1, int_4, out point_0, rectangle_0, int_5, int_6, class76_0))
					{
						return true;
					}
					if (bool_0)
					{
						return true;
					}
					if (cancellationToken_0.IsCancellationRequested)
					{
						return false;
					}
					Thread.Sleep(int_8);
				}
				flag = false;
			}
			catch
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00031588 File Offset: 0x0002F788
		public static bool smethod_20(int int_2, int int_3, Bitmap bitmap_1, int int_4, out Point[] point_0, Rectangle rectangle_0, int int_5, int int_6, Bitmap bitmap_2)
		{
			bool flag;
			try
			{
				if (int_4 == -2)
				{
					int_4 = 62207;
				}
				if (bitmap_2 != null)
				{
					using (Bitmap bitmap = bitmap_2.Clone(rectangle_0, bitmap_2.PixelFormat))
					{
						List<Hashtable> list = FindImage.FindBitmap(bitmap_1, bitmap, int_3, int_6, int_5, int_2, int_4, false);
						if (list.Count > 0)
						{
							point_0 = new Point[list.Count];
							for (int i = 0; i < list.Count; i++)
							{
								point_0[i] = (Point)list[i]["location"];
							}
							return true;
						}
						point_0 = null;
						return false;
					}
				}
				point_0 = null;
				flag = false;
			}
			catch
			{
				point_0 = null;
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00031654 File Offset: 0x0002F854
		public static bool smethod_21(int int_2, int int_3, Bitmap bitmap_1, int int_4, out Point[] point_0, int int_5, int int_6, Bitmap bitmap_2)
		{
			bool flag;
			try
			{
				if (bitmap_2 == null)
				{
					point_0 = null;
					flag = false;
				}
				else
				{
					if (int_4 == -2)
					{
						int_4 = 62207;
					}
					List<Hashtable> list = FindImage.FindBitmap(bitmap_1, bitmap_2, int_3, int_6, int_5, int_2, int_4, false);
					if (list.Count > 0)
					{
						point_0 = new Point[list.Count];
						for (int i = 0; i < list.Count; i++)
						{
							point_0[i] = (Point)list[i]["location"];
						}
						flag = true;
					}
					else
					{
						point_0 = null;
						flag = false;
					}
				}
			}
			catch
			{
				point_0 = null;
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000395 RID: 917 RVA: 0x000316FC File Offset: 0x0002F8FC
		public static bool smethod_22(int int_2, int int_3, int int_4, int int_5, Bitmap[] bitmap_1, int int_6, out Point[] point_0, Rectangle rectangle_0, int int_7, int int_8, Bitmap bitmap_2)
		{
			bool flag;
			try
			{
				if (bitmap_2 != null)
				{
					if (int_4 < 0)
					{
						int_4 = 0;
					}
					if (int_5 < 1)
					{
						int_5 = bitmap_1.Length;
					}
					if (int_6 == -2)
					{
						int_6 = 62207;
					}
					using (Bitmap bitmap = bitmap_2.Clone(rectangle_0, bitmap_2.PixelFormat))
					{
						List<Point> list = new List<Point>();
						for (int i = int_4; i < int_4 + int_5; i++)
						{
							List<Hashtable> list2 = FindImage.FindBitmap(bitmap_1[i], bitmap, int_3, int_8, int_7, int_2, int_6, false);
							if (list2.Count > 0)
							{
								foreach (Hashtable hashtable in list2)
								{
									list.Add((Point)hashtable["location"]);
								}
							}
						}
						point_0 = list.ToArray();
						return point_0.Length != 0;
					}
				}
				point_0 = null;
				flag = false;
			}
			catch
			{
				point_0 = null;
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000396 RID: 918 RVA: 0x00031814 File Offset: 0x0002FA14
		public static bool smethod_23(int int_2, int int_3, int int_4, int int_5, Bitmap[] bitmap_1, int int_6, out Point[] point_0, int int_7, int int_8, Bitmap bitmap_2)
		{
			bool flag;
			try
			{
				if (bitmap_2 == null)
				{
					point_0 = null;
					flag = false;
				}
				else
				{
					if (int_4 < 0)
					{
						int_4 = 0;
					}
					if (int_5 < 1)
					{
						int_5 = bitmap_1.Length;
					}
					if (int_6 == -2)
					{
						int_6 = 62207;
					}
					List<Point> list = new List<Point>();
					for (int i = int_4; i < int_4 + int_5; i++)
					{
						List<Hashtable> list2 = FindImage.FindBitmap(bitmap_1[i], bitmap_2, int_3, int_8, int_7, int_2, int_6, false);
						if (list2.Count > 0)
						{
							foreach (Hashtable hashtable in list2)
							{
								list.Add((Point)hashtable["location"]);
							}
						}
					}
					point_0 = list.ToArray();
					flag = point_0.Length != 0;
				}
			}
			catch
			{
				point_0 = null;
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000397 RID: 919 RVA: 0x00031904 File Offset: 0x0002FB04
		public static bool smethod_24(int int_2, int int_3, int int_4, int int_5, Bitmap[] bitmap_1, int int_6, out Point[] point_0, Rectangle rectangle_0, int int_7, int int_8, Class76 class76_0)
		{
			bool flag;
			try
			{
				using (Bitmap bitmap = Class40.smethod_5(class76_0, rectangle_0))
				{
					if (bitmap == null)
					{
						point_0 = null;
						flag = false;
					}
					else
					{
						if (int_4 < 0)
						{
							int_4 = 0;
						}
						if (int_5 < 1)
						{
							int_5 = bitmap_1.Length;
						}
						if (int_6 == -2)
						{
							int_6 = 62207;
						}
						List<Point> list = new List<Point>();
						for (int i = int_4; i < int_4 + int_5; i++)
						{
							List<Hashtable> list2 = FindImage.FindBitmap(bitmap_1[i], bitmap, int_3, int_8, int_7, int_2, int_6, false);
							if (list2.Count > 0)
							{
								foreach (Hashtable hashtable in list2)
								{
									list.Add((Point)hashtable["location"]);
								}
							}
						}
						point_0 = list.ToArray();
						flag = point_0.Length != 0;
					}
				}
			}
			catch (Exception)
			{
				point_0 = null;
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000398 RID: 920 RVA: 0x00031A14 File Offset: 0x0002FC14
		public static int smethod_25(int int_2, int int_3, int int_4, int int_5, Bitmap[] bitmap_1, int int_6, out Point[] point_0, Rectangle rectangle_0, int int_7, int int_8, Class76 class76_0)
		{
			int num;
			try
			{
				using (Bitmap bitmap = Class40.smethod_5(class76_0, rectangle_0))
				{
					if (bitmap == null)
					{
						point_0 = null;
						num = -1;
					}
					else
					{
						if (int_4 < 0)
						{
							int_4 = 0;
						}
						if (int_5 < 1)
						{
							int_5 = bitmap_1.Length;
						}
						if (int_6 == -2)
						{
							int_6 = 62207;
						}
						List<Point> list = new List<Point>();
						for (int i = int_4; i < int_4 + int_5; i++)
						{
							List<Hashtable> list2 = FindImage.FindBitmap(bitmap_1[i], bitmap, int_3, int_8, int_7, int_2, int_6, false);
							if (list2.Count > 0)
							{
								using (List<Hashtable>.Enumerator enumerator = list2.GetEnumerator())
								{
									if (enumerator.MoveNext())
									{
										Hashtable hashtable = enumerator.Current;
										list.Add((Point)hashtable["location"]);
										point_0 = list.ToArray();
										return i;
									}
								}
							}
						}
						point_0 = null;
						num = -1;
					}
				}
			}
			catch
			{
				point_0 = null;
				num = -1;
			}
			return num;
		}

		// Token: 0x06000399 RID: 921 RVA: 0x00031B24 File Offset: 0x0002FD24
		public unsafe static int smethod_26(Color color_0, int int_2, Rectangle rectangle_0, Class76 class76_0)
		{
			if (int_2 >= 0 && int_2 <= 255)
			{
				try
				{
					using (Bitmap bitmap = Class40.smethod_5(class76_0, rectangle_0))
					{
						if (bitmap != null)
						{
							Bitmap bitmap2 = ((bitmap.PixelFormat == PixelFormat.Format32bppArgb) ? ((Bitmap)bitmap.Clone()) : bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), PixelFormat.Format32bppArgb));
							BitmapData bitmapData = null;
							try
							{
								int num = 0;
								Rectangle rectangle = new Rectangle(0, 0, bitmap2.Width, bitmap2.Height);
								bitmapData = bitmap2.LockBits(rectangle, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
								byte* ptr = (byte*)(void*)bitmapData.Scan0;
								int stride = bitmapData.Stride;
								int width = bitmapData.Width;
								int height = bitmapData.Height;
								byte r = color_0.R;
								byte g = color_0.G;
								byte b = color_0.B;
								for (int i = 0; i < height; i++)
								{
									byte* ptr2 = ptr + i * stride;
									for (int j = 0; j < width; j++)
									{
										int num2 = j * 4;
										byte b2 = ptr2[num2];
										byte b3 = ptr2[num2 + 1];
										if (Math.Abs((int)(ptr2[num2 + 2] - r)) <= int_2 && Math.Abs((int)(b3 - g)) <= int_2 && Math.Abs((int)(b2 - b)) <= int_2)
										{
											num++;
										}
									}
								}
								return num;
							}
							finally
							{
								if (bitmapData != null)
								{
									bitmap2.UnlockBits(bitmapData);
								}
								bitmap2.Dispose();
							}
						}
						return -1;
					}
				}
				catch
				{
					return -1;
				}
			}
			throw new ArgumentOutOfRangeException("colorThreshold", "Color tolerance must be between 0 and 255.");
		}

		// Token: 0x0600039A RID: 922 RVA: 0x00031CF8 File Offset: 0x0002FEF8
		public static int smethod_27(int int_2, List<Color> list_0, List<int> list_1, int int_3, out Point[] point_0, int int_4, int int_5, int int_6, int int_7, int int_8, Rectangle rectangle_0, int int_9, int int_10, int int_11, Class76 class76_0)
		{
			int num;
			try
			{
				Size size = new Size(int_5, int_6);
				Size size2 = new Size(int_7, int_8);
				using (Bitmap bitmap = Class40.smethod_5(class76_0, rectangle_0))
				{
					if (bitmap == null)
					{
						point_0 = null;
						num = -1;
					}
					else
					{
						List<Hashtable> list = Imaging.FindHeapColor(bitmap, list_0, list_1, int_9, int_3, size, size2, int_10, int_11, int_2);
						int num2 = ((list != null) ? list.Count : 0);
						if (num2 > 0)
						{
							point_0 = new Point[num2];
							string text = ((int_4 == 5) ? "LocationAverage" : "FirstPixel");
							for (int i = 0; i < num2; i++)
							{
								point_0[i] = (Point)list[i][text];
							}
							num = num2;
						}
						else
						{
							point_0 = null;
							num = 0;
						}
					}
				}
			}
			catch
			{
				point_0 = null;
				num = -1;
			}
			return num;
		}

		// Token: 0x0600039B RID: 923 RVA: 0x00004D7A File Offset: 0x00002F7A
		private static bool smethod_28(byte byte_0, byte byte_1, byte byte_2, Color color_0, int int_2)
		{
			return Math.Abs((int)(byte_0 - color_0.R)) <= int_2 && Math.Abs((int)(byte_1 - color_0.G)) <= int_2 && Math.Abs((int)(byte_2 - color_0.B)) <= int_2;
		}

		// Token: 0x0600039C RID: 924 RVA: 0x00031DE8 File Offset: 0x0002FFE8
		public static bool smethod_29(int int_2, List<Color> list_0, List<int> list_1, int int_3, out Point[] point_0, int int_4, int int_5, int int_6, int int_7, int int_8, Rectangle rectangle_0, int int_9, int int_10, int int_11, Class76 class76_0)
		{
			bool flag;
			try
			{
				Size size = new Size(int_5, int_6);
				Size size2 = new Size(int_7, int_8);
				using (Bitmap bitmap = Class40.smethod_5(class76_0, rectangle_0))
				{
					if (bitmap == null)
					{
						point_0 = null;
						flag = false;
					}
					else
					{
						List<Hashtable> list = Imaging.FindHeapColor(bitmap, list_0, list_1, int_9, int_3, size, size2, int_10, int_11, int_2);
						if (list.Count > 0)
						{
							point_0 = new Point[list.Count];
							string text = "FirstPixel";
							if (int_4 == 5)
							{
								text = "LocationAverage";
							}
							for (int i = 0; i < list.Count; i++)
							{
								point_0[i] = (Point)list[i][text];
							}
							flag = true;
						}
						else
						{
							point_0 = null;
							flag = false;
						}
					}
				}
			}
			catch
			{
				point_0 = null;
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600039D RID: 925 RVA: 0x00031ED4 File Offset: 0x000300D4
		public static int smethod_30(int int_2, List<Color> list_0, List<int> list_1, int int_3, out Point[] point_0, int int_4, int int_5, int int_6, int int_7, int int_8, int int_9, int int_10, int int_11, Bitmap bitmap_1)
		{
			point_0 = null;
			int num;
			try
			{
				if (bitmap_1 == null)
				{
					num = -1;
				}
				else
				{
					Size size = new Size(int_5, int_6);
					Size size2 = new Size(int_7, int_8);
					List<Hashtable> list = Imaging.FindHeapColor(bitmap_1, list_0, list_1, int_9, int_3, size, size2, int_10, int_11, int_2);
					if (list != null && list.Count != 0)
					{
						point_0 = new Point[list.Count];
						string text = ((int_4 == 5) ? "LocationAverage" : "FirstPixel");
						for (int i = 0; i < list.Count; i++)
						{
							point_0[i] = (Point)list[i][text];
						}
						int num2 = 0;
						for (int j = 0; j < list.Count; j++)
						{
							OrderedDictionary orderedDictionary = list[j]["FoundColors"] as OrderedDictionary;
							if (orderedDictionary != null)
							{
								foreach (object obj in orderedDictionary)
								{
									object value = ((DictionaryEntry)obj).Value;
									if (value is int)
									{
										int num3 = (int)value;
										num2 += num3;
									}
								}
							}
						}
						num = num2;
					}
					else
					{
						num = 0;
					}
				}
			}
			catch
			{
				point_0 = null;
				num = -1;
			}
			return num;
		}

		// Token: 0x0600039E RID: 926 RVA: 0x00032060 File Offset: 0x00030260
		public static bool smethod_31(int int_2, List<Color> list_0, List<int> list_1, int int_3, out Point[] point_0, int int_4, int int_5, int int_6, int int_7, int int_8, int int_9, int int_10, int int_11, Bitmap bitmap_1)
		{
			bool flag;
			try
			{
				point_0 = null;
				if (bitmap_1 == null)
				{
					flag = false;
				}
				else
				{
					Size size = new Size(int_5, int_6);
					Size size2 = new Size(int_7, int_8);
					List<Hashtable> list = Imaging.FindHeapColor(bitmap_1, list_0, list_1, int_9, int_3, size, size2, int_10, int_11, int_2);
					if (list != null && list.Count > 0)
					{
						point_0 = new Point[list.Count];
						string text = ((int_4 == 5) ? "LocationAverage" : "FirstPixel");
						for (int i = 0; i < list.Count; i++)
						{
							point_0[i] = (Point)list[i][text];
						}
						flag = true;
					}
					else
					{
						flag = false;
					}
				}
			}
			catch
			{
				point_0 = null;
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600039F RID: 927 RVA: 0x00032128 File Offset: 0x00030328
		public static bool smethod_32(int int_2, List<Color> list_0, List<int> list_1, int int_3, out Point[] point_0, int int_4, int int_5, int int_6, int int_7, int int_8, Rectangle rectangle_0, int int_9, int int_10, int int_11, Bitmap bitmap_1)
		{
			bool flag;
			try
			{
				if (bitmap_1 != null)
				{
					Size size = new Size(int_5, int_6);
					Size size2 = new Size(int_7, int_8);
					using (Bitmap bitmap = bitmap_1.Clone(rectangle_0, bitmap_1.PixelFormat))
					{
						List<Hashtable> list = Imaging.FindHeapColor(bitmap, list_0, list_1, int_9, int_3, size, size2, int_10, int_11, int_2);
						if (list.Count > 0)
						{
							point_0 = new Point[list.Count];
							string text = "FirstPixel";
							if (int_4 == 5)
							{
								text = "LocationAverage";
							}
							for (int i = 0; i < list.Count; i++)
							{
								point_0[i] = (Point)list[i][text];
							}
							return true;
						}
						point_0 = null;
						return false;
					}
				}
				point_0 = null;
				flag = false;
			}
			catch
			{
				point_0 = null;
				flag = false;
			}
			return flag;
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x0003221C File Offset: 0x0003041C
		public static List<Point> smethod_33(Bitmap bitmap_1, Bitmap bitmap_2, int int_2, int int_3, int int_4, int int_5, int int_6, int int_7)
		{
			List<Point> list = new List<Point>();
			for (int i = int_3; i < int_5 - int_6; i += int_6)
			{
				for (int j = int_2; j < int_4 - int_6; j += int_6)
				{
					Color pixel = bitmap_1.GetPixel(j, i);
					Color pixel2 = bitmap_2.GetPixel(j, i);
					int num = Math.Abs((int)(pixel.R - pixel2.R));
					int num2 = Math.Abs((int)(pixel.G - pixel2.G));
					int num3 = Math.Abs((int)(pixel.B - pixel2.B));
					if (num + num2 + num3 > int_7)
					{
						Class40.Class41 @class = new Class40.Class41();
						@class.point_0 = new Point(j + int_6 / 2, i + int_6 / 2);
						if (!list.Any(new Func<Point, bool>(@class.method_0)))
						{
							list.Add(@class.point_0);
							j += 15;
						}
					}
				}
			}
			return list;
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x00032304 File Offset: 0x00030504
		public static Point[] smethod_34(Bitmap bitmap_1, Bitmap bitmap_2, int int_2, int int_3, int int_4, int int_5, int int_6, int int_7)
		{
			Point[] array = new Point[0];
			for (int i = int_3; i < int_5; i += int_6)
			{
				int num = int_2;
				while (num < int_4 && num + int_6 < int_4 && i + int_6 < int_5)
				{
					Color pixel = bitmap_1.GetPixel(num, i);
					Color pixel2 = bitmap_2.GetPixel(num, i);
					int num2 = Math.Abs((int)(pixel.R - pixel2.R));
					int num3 = Math.Abs((int)(pixel.G - pixel2.G));
					int num4 = Math.Abs((int)(pixel.B - pixel2.B));
					if (num2 + num3 + num4 > int_7)
					{
						Point point = new Point(num + int_6 / 2, i + int_6 / 2);
						bool flag = false;
						Point[] array2 = array;
						int j = 0;
						while (j < array2.Length)
						{
							Point point2 = array2[j];
							if (Math.Abs(point2.X - point.X) >= 15 || Math.Abs(point2.Y - point.Y) >= 15)
							{
								j++;
							}
							else
							{
								flag = true;
								IL_00F7:
								if (!flag)
								{
									Array.Resize<Point>(ref array, array.Length + 1);
									array[array.Length - 1] = point;
									num += 15;
									goto IL_0119;
								}
								goto IL_0119;
							}
						}
						goto IL_00F7;
					}
					IL_0119:
					num += int_6;
				}
			}
			return array;
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x00032448 File Offset: 0x00030648
		public static bool smethod_35(Bitmap bitmap_1, Bitmap[] bitmap_2, Color color_0, double double_0, int int_2, int int_3, int int_4, int int_5, int int_6, out Point point_0)
		{
			bool flag2;
			try
			{
				foreach (Bitmap bitmap in bitmap_2)
				{
					int width = bitmap.Width;
					int height = bitmap.Height;
					int_5 = int_5 - width + 1;
					int_6 = int_6 - height + 1;
					for (int j = int_4; j < int_6; j++)
					{
						for (int k = int_3; k < int_5; k++)
						{
							bool flag = true;
							int num = 0;
							int l = 0;
							IL_0112:
							while (l < height)
							{
								for (int m = 0; m < width; m++)
								{
									Color pixel = bitmap.GetPixel(m, l);
									Color pixel2 = bitmap_1.GetPixel(k + m, j + l);
									if (pixel == color_0)
									{
										num++;
									}
									else if (Math.Sqrt(Math.Pow((double)(pixel.R - pixel2.R), 2.0) + Math.Pow((double)(pixel.G - pixel2.G), 2.0) + Math.Pow((double)(pixel.B - pixel2.B), 2.0)) <= (double)int_2)
									{
										num++;
									}
									else
									{
										flag = false;
										IL_0108:
										if (flag)
										{
											l++;
											goto IL_0112;
										}
										goto IL_011B;
									}
								}
								goto IL_0108;
							}
							IL_011B:
							if ((double)num / (double)(width * height) >= double_0)
							{
								point_0 = new Point(k, j);
								return true;
							}
						}
					}
				}
				point_0 = Point.Empty;
				flag2 = false;
			}
			catch
			{
				point_0 = Point.Empty;
				flag2 = false;
			}
			return flag2;
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x00032600 File Offset: 0x00030800
		public static Bitmap smethod_36(Bitmap bitmap_1, Class76 class76_0)
		{
			if (class76_0.Resolution == "2560x1440")
			{
				return bitmap_1;
			}
			int num = (int)((float)bitmap_1.Width / 2560f * (float)class76_0.Width);
			int num2 = (int)((float)bitmap_1.Height / 1440f * (float)class76_0.Height);
			Bitmap bitmap = new Bitmap(num, num2, bitmap_1.PixelFormat);
			Bitmap bitmap2;
			try
			{
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					graphics.DrawImage(bitmap_1, 0, 0, num, num2);
				}
				bitmap2 = new Bitmap(bitmap);
			}
			finally
			{
				bitmap.Dispose();
			}
			return bitmap2;
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x000326AC File Offset: 0x000308AC
		public static string smethod_37(Bitmap bitmap_1, List<BaseSymbolStruct> list_0)
		{
			List<Line> list = new List<Line>();
			Bitmap bitmap = null;
			string text;
			try
			{
				text = ReadText.SymbolsToString(ReadText.Recognize(bitmap_1, 118, 43, 60, 9, 0, 5, 4, 180, 0, 50, 0, 50, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 1, 0, 0, 5, 5, 70, 70, 1, 0, 1, 0, 1, 0, new Color[0], new Color[0], new int[0], new int[0], list_0, false, 0, ref list, ref bitmap, false, new Size(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, new int[0], new char[0]), 40, list, true);
			}
			finally
			{
				bitmap.Dispose();
			}
			return text;
		}

		// Token: 0x04000452 RID: 1106
		private static Bitmap bitmap_0;

		// Token: 0x04000453 RID: 1107
		private static Graphics graphics_0;

		// Token: 0x04000454 RID: 1108
		private static int int_0 = 0;

		// Token: 0x04000455 RID: 1109
		private static int int_1 = 0;

		// Token: 0x04000456 RID: 1110
		private static Random random_0 = new Random();

		// Token: 0x02000070 RID: 112
		[CompilerGenerated]
		private sealed class Class41
		{
			// Token: 0x060003A8 RID: 936 RVA: 0x00004DCF File Offset: 0x00002FCF
			internal bool method_0(Point point_1)
			{
				return Math.Abs(point_1.X - this.point_0.X) < 15 && Math.Abs(point_1.Y - this.point_0.Y) < 15;
			}

			// Token: 0x04000457 RID: 1111
			public Point point_0;
		}
	}
}
