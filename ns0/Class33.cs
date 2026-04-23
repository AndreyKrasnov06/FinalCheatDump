using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Newtonsoft.Json;

namespace ns0
{
	// Token: 0x02000065 RID: 101
	internal static class Class33
	{
		// Token: 0x0600033A RID: 826 RVA: 0x0002EA74 File Offset: 0x0002CC74
		private static string smethod_0()
		{
			ManagementObject managementObject = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystemProduct").Get().Cast<ManagementObject>().FirstOrDefault<ManagementObject>();
			if (managementObject != null)
			{
				return managementObject["UUID"].ToString();
			}
			return "null";
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0002EAB4 File Offset: 0x0002CCB4
		public static byte[] smethod_1()
		{
			if (Class33.smethod_2())
			{
				Class33.Class34 @class = new Class33.Class34();
				Class33.Class36 class2 = new Class33.Class36();
				Class33.Class35 class3 = new Class33.Class35();
				Class33.Class38 class4 = new Class33.Class38();
				Class33.Class37 class5 = new Class33.Class37();
				try
				{
					Class61 class6 = new Class61
					{
						string_2 = Class33.smethod_0(),
						string_3 = string.Concat(new string[] { @class.Model, "\n", @class.SerialNo, "\n", @class.VolumeID }),
						string_4 = string.Concat(new string[] { class2.Manufacturer, "\n", class2.Product, "\n", class2.SerialNo, "\n", class2.BiosVersion }),
						string_5 = string.Concat(new string[]
						{
							"1) ",
							class3.Name[0],
							", ",
							class3.SerialNo[0],
							"\n2) ",
							class3.Name[1],
							", ",
							class3.SerialNo[1]
						}),
						string_6 = string.Concat(new string[]
						{
							"1) ",
							class5.Manufacturer[0],
							", ",
							class5.Capacity[0],
							", ",
							class5.SerialNo[0],
							"\n2) ",
							class5.Manufacturer[1],
							", ",
							class5.Capacity[1],
							", ",
							class5.SerialNo[1],
							"\n3) ",
							class5.Manufacturer[2],
							", ",
							class5.Capacity[2],
							", ",
							class5.SerialNo[2],
							"\n4) ",
							class5.Manufacturer[3],
							", ",
							class5.Capacity[3],
							", ",
							class5.SerialNo[3]
						}),
						string_7 = string.Concat(new string[]
						{
							"1) ",
							class4.Name[0],
							", ",
							class4.VideoProcessor[0],
							", ",
							class4.AdapterRAM[0],
							"\n2) ",
							class4.Name[1],
							", ",
							class4.VideoProcessor[1],
							", ",
							class4.AdapterRAM[1]
						})
					};
					byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(class6));
					class6.method_0();
					GClass2.smethod_1(ref bytes);
					return bytes;
				}
				catch (Exception ex)
				{
					throw new Exception("При запросе данных WMI произошла ошибка: " + ex.Message);
				}
			}
			throw new Exception("Репозиторий WMI поврежден и процесс восстановления завершился неудачей.");
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0002EE48 File Offset: 0x0002D048
		private static bool smethod_2()
		{
			if (!Class59.smethod_0("Get-Service -Name winmgmt | Select-Object -ExpandProperty Status", false, true, false, true).Trim().Equals("Running", StringComparison.OrdinalIgnoreCase))
			{
				Class59.smethod_0("net start winmgmt", false, true, false, true);
			}
			if (Class59.smethod_0("winmgmt /verifyrepository", true, true, false, true) != "0")
			{
				Class59.smethod_0("winmgmt /salvagerepository", false, true, false, true);
				Class59.smethod_0("winmgmt /resetrepository", false, true, false, true);
				if (Class59.smethod_0("winmgmt /verifyrepository", true, true, false, true) != "0")
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x02000066 RID: 102
		private class Class34
		{
			// Token: 0x0600033D RID: 829
			[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
			private static extern bool GetVolumeInformation(string string_3, StringBuilder stringBuilder_0, uint uint_0, out uint uint_1, out uint uint_2, out uint uint_3, StringBuilder stringBuilder_1, uint uint_4);

			// Token: 0x17000090 RID: 144
			// (get) Token: 0x0600033E RID: 830 RVA: 0x00004B61 File Offset: 0x00002D61
			// (set) Token: 0x0600033F RID: 831 RVA: 0x00004B69 File Offset: 0x00002D69
			public string Model { get; private set; }

			// Token: 0x17000091 RID: 145
			// (get) Token: 0x06000340 RID: 832 RVA: 0x00004B72 File Offset: 0x00002D72
			// (set) Token: 0x06000341 RID: 833 RVA: 0x00004B7A File Offset: 0x00002D7A
			public string SerialNo { get; private set; }

			// Token: 0x17000092 RID: 146
			// (get) Token: 0x06000342 RID: 834 RVA: 0x00004B83 File Offset: 0x00002D83
			// (set) Token: 0x06000343 RID: 835 RVA: 0x00004B8B File Offset: 0x00002D8B
			public string VolumeID { get; private set; }

			// Token: 0x06000344 RID: 836 RVA: 0x00004B94 File Offset: 0x00002D94
			public Class34()
			{
				this.Model = "null";
				this.SerialNo = "null";
				this.VolumeID = "null";
				this.method_0();
			}

			// Token: 0x06000345 RID: 837 RVA: 0x0002EEDC File Offset: 0x0002D0DC
			private void method_0()
			{
				StringBuilder stringBuilder = new StringBuilder(256);
				StringBuilder stringBuilder2 = new StringBuilder(256);
				uint num;
				uint num2;
				uint num3;
				Class33.Class34.GetVolumeInformation(Path.GetPathRoot(Environment.SystemDirectory), stringBuilder, (uint)stringBuilder.Capacity, out num, out num2, out num3, stringBuilder2, (uint)stringBuilder2.Capacity);
				this.VolumeID = num.ToString("X");
				foreach (ManagementObject managementObject in new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem").Get().Cast<ManagementObject>())
				{
					foreach (ManagementObject managementObject2 in new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive").Get().Cast<ManagementObject>())
					{
						foreach (ManagementObject managementObject3 in new ManagementObjectSearcher(string.Format("ASSOCIATORS OF {{Win32_DiskDrive.DeviceID='{0}'}} WHERE AssocClass=Win32_DiskDriveToDiskPartition", managementObject2["DeviceID"])).Get().Cast<ManagementObject>())
						{
							using (IEnumerator<ManagementObject> enumerator4 = new ManagementObjectSearcher(string.Format("ASSOCIATORS OF {{Win32_DiskPartition.DeviceID='{0}'}} WHERE AssocClass=Win32_LogicalDiskToPartition", managementObject3["DeviceID"])).Get().Cast<ManagementObject>().GetEnumerator())
							{
								while (enumerator4.MoveNext())
								{
									if (enumerator4.Current["Name"].ToString() == managementObject["SystemDrive"].ToString())
									{
										this.Model = managementObject2["Model"].ToString();
										object obj = managementObject2["SerialNumber"];
										this.SerialNo = ((obj != null) ? obj.ToString() : null);
										return;
									}
								}
							}
						}
					}
				}
			}

			// Token: 0x04000437 RID: 1079
			[CompilerGenerated]
			private string string_0;

			// Token: 0x04000438 RID: 1080
			[CompilerGenerated]
			private string string_1;

			// Token: 0x04000439 RID: 1081
			[CompilerGenerated]
			private string string_2;
		}

		// Token: 0x02000067 RID: 103
		private class Class35
		{
			// Token: 0x17000093 RID: 147
			// (get) Token: 0x06000346 RID: 838 RVA: 0x00004BC3 File Offset: 0x00002DC3
			// (set) Token: 0x06000347 RID: 839 RVA: 0x00004BCB File Offset: 0x00002DCB
			public List<string> Name { get; private set; }

			// Token: 0x17000094 RID: 148
			// (get) Token: 0x06000348 RID: 840 RVA: 0x00004BD4 File Offset: 0x00002DD4
			// (set) Token: 0x06000349 RID: 841 RVA: 0x00004BDC File Offset: 0x00002DDC
			public List<string> SerialNo { get; private set; }

			// Token: 0x0600034A RID: 842 RVA: 0x0002F124 File Offset: 0x0002D324
			public Class35()
			{
				this.Name = new List<string> { "null", "null" };
				this.SerialNo = new List<string> { "null", "null" };
				this.method_0();
			}

			// Token: 0x0600034B RID: 843 RVA: 0x0002F180 File Offset: 0x0002D380
			private void method_0()
			{
				List<ManagementObject> list = new ManagementObjectSearcher("SELECT * FROM Win32_Processor").Get().Cast<ManagementObject>().Take(2)
					.ToList<ManagementObject>();
				for (int i = 0; i < list.Count; i++)
				{
					List<string> name = this.Name;
					int num = i;
					object obj = list[i]["Name"];
					name[num] = ((obj != null) ? obj.ToString() : null);
					List<string> serialNo = this.SerialNo;
					int num2 = i;
					object obj2 = list[i]["ProcessorId"];
					serialNo[num2] = ((obj2 != null) ? obj2.ToString() : null);
				}
			}

			// Token: 0x0400043A RID: 1082
			[CompilerGenerated]
			private List<string> list_0;

			// Token: 0x0400043B RID: 1083
			[CompilerGenerated]
			private List<string> list_1;
		}

		// Token: 0x02000068 RID: 104
		private class Class36
		{
			// Token: 0x17000095 RID: 149
			// (get) Token: 0x0600034C RID: 844 RVA: 0x00004BE5 File Offset: 0x00002DE5
			// (set) Token: 0x0600034D RID: 845 RVA: 0x00004BED File Offset: 0x00002DED
			public string Manufacturer { get; private set; }

			// Token: 0x17000096 RID: 150
			// (get) Token: 0x0600034E RID: 846 RVA: 0x00004BF6 File Offset: 0x00002DF6
			// (set) Token: 0x0600034F RID: 847 RVA: 0x00004BFE File Offset: 0x00002DFE
			public string Product { get; private set; }

			// Token: 0x17000097 RID: 151
			// (get) Token: 0x06000350 RID: 848 RVA: 0x00004C07 File Offset: 0x00002E07
			// (set) Token: 0x06000351 RID: 849 RVA: 0x00004C0F File Offset: 0x00002E0F
			public string SerialNo { get; private set; }

			// Token: 0x17000098 RID: 152
			// (get) Token: 0x06000352 RID: 850 RVA: 0x00004C18 File Offset: 0x00002E18
			// (set) Token: 0x06000353 RID: 851 RVA: 0x00004C20 File Offset: 0x00002E20
			public string BiosVersion { get; private set; }

			// Token: 0x06000354 RID: 852 RVA: 0x00004C29 File Offset: 0x00002E29
			public Class36()
			{
				this.Manufacturer = "null";
				this.Product = "null";
				this.SerialNo = "null";
				this.BiosVersion = "null";
				this.method_0();
			}

			// Token: 0x06000355 RID: 853 RVA: 0x00004C63 File Offset: 0x00002E63
			private void method_0()
			{
				this.method_1();
				this.method_2();
			}

			// Token: 0x06000356 RID: 854 RVA: 0x0002F210 File Offset: 0x0002D410
			private void method_1()
			{
				ManagementObject managementObject = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard").Get().Cast<ManagementObject>().FirstOrDefault<ManagementObject>();
				if (managementObject != null)
				{
					object obj = managementObject["Manufacturer"];
					this.Manufacturer = ((obj != null) ? obj.ToString() : null);
					object obj2 = managementObject["Product"];
					this.Product = ((obj2 != null) ? obj2.ToString() : null);
					object obj3 = managementObject["SerialNumber"];
					this.SerialNo = ((obj3 != null) ? obj3.ToString() : null);
				}
			}

			// Token: 0x06000357 RID: 855 RVA: 0x0002F294 File Offset: 0x0002D494
			private void method_2()
			{
				ManagementObject managementObject = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS").Get().Cast<ManagementObject>().FirstOrDefault<ManagementObject>();
				if (managementObject != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					string[] array = managementObject["BIOSVersion"] as string[];
					if (array != null)
					{
						stringBuilder.Append(string.Join(", ", array));
					}
					else
					{
						StringBuilder stringBuilder2 = stringBuilder;
						object obj = managementObject["BIOSVersion"];
						stringBuilder2.Append((obj != null) ? obj.ToString() : null);
					}
					this.BiosVersion = stringBuilder.ToString();
				}
			}

			// Token: 0x0400043C RID: 1084
			[CompilerGenerated]
			private string string_0;

			// Token: 0x0400043D RID: 1085
			[CompilerGenerated]
			private string string_1;

			// Token: 0x0400043E RID: 1086
			[CompilerGenerated]
			private string string_2;

			// Token: 0x0400043F RID: 1087
			[CompilerGenerated]
			private string string_3;
		}

		// Token: 0x02000069 RID: 105
		private class Class37
		{
			// Token: 0x17000099 RID: 153
			// (get) Token: 0x06000358 RID: 856 RVA: 0x00004C71 File Offset: 0x00002E71
			// (set) Token: 0x06000359 RID: 857 RVA: 0x00004C79 File Offset: 0x00002E79
			public List<string> Manufacturer { get; private set; }

			// Token: 0x1700009A RID: 154
			// (get) Token: 0x0600035A RID: 858 RVA: 0x00004C82 File Offset: 0x00002E82
			// (set) Token: 0x0600035B RID: 859 RVA: 0x00004C8A File Offset: 0x00002E8A
			public List<string> Capacity { get; private set; }

			// Token: 0x1700009B RID: 155
			// (get) Token: 0x0600035C RID: 860 RVA: 0x00004C93 File Offset: 0x00002E93
			// (set) Token: 0x0600035D RID: 861 RVA: 0x00004C9B File Offset: 0x00002E9B
			public List<string> SerialNo { get; private set; }

			// Token: 0x0600035E RID: 862 RVA: 0x0002F318 File Offset: 0x0002D518
			public Class37()
			{
				this.Manufacturer = new List<string> { "null", "null", "null", "null" };
				this.Capacity = new List<string> { "null", "null", "null", "null" };
				this.SerialNo = new List<string> { "null", "null", "null", "null" };
				this.method_0();
			}

			// Token: 0x0600035F RID: 863 RVA: 0x0002F3D8 File Offset: 0x0002D5D8
			private void method_0()
			{
				List<ManagementObject> list = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory").Get().Cast<ManagementObject>().Take(4)
					.ToList<ManagementObject>();
				for (int i = 0; i < list.Count; i++)
				{
					List<string> manufacturer = this.Manufacturer;
					int num = i;
					object obj = list[i]["Manufacturer"];
					manufacturer[num] = ((obj != null) ? obj.ToString() : null);
					this.Capacity[i] = (Convert.ToUInt64(list[i]["Capacity"]) / 1048576UL).ToString() + " MB";
					List<string> serialNo = this.SerialNo;
					int num2 = i;
					object obj2 = list[i]["SerialNumber"];
					serialNo[num2] = ((obj2 != null) ? obj2.ToString() : null);
				}
			}

			// Token: 0x04000440 RID: 1088
			[CompilerGenerated]
			private List<string> list_0;

			// Token: 0x04000441 RID: 1089
			[CompilerGenerated]
			private List<string> list_1;

			// Token: 0x04000442 RID: 1090
			[CompilerGenerated]
			private List<string> list_2;
		}

		// Token: 0x0200006A RID: 106
		private class Class38
		{
			// Token: 0x1700009C RID: 156
			// (get) Token: 0x06000360 RID: 864 RVA: 0x00004CA4 File Offset: 0x00002EA4
			// (set) Token: 0x06000361 RID: 865 RVA: 0x00004CAC File Offset: 0x00002EAC
			public List<string> Name { get; private set; }

			// Token: 0x1700009D RID: 157
			// (get) Token: 0x06000362 RID: 866 RVA: 0x00004CB5 File Offset: 0x00002EB5
			// (set) Token: 0x06000363 RID: 867 RVA: 0x00004CBD File Offset: 0x00002EBD
			public List<string> VideoProcessor { get; private set; }

			// Token: 0x1700009E RID: 158
			// (get) Token: 0x06000364 RID: 868 RVA: 0x00004CC6 File Offset: 0x00002EC6
			// (set) Token: 0x06000365 RID: 869 RVA: 0x00004CCE File Offset: 0x00002ECE
			public List<string> AdapterRAM { get; private set; }

			// Token: 0x1700009F RID: 159
			// (get) Token: 0x06000366 RID: 870 RVA: 0x00004CD7 File Offset: 0x00002ED7
			// (set) Token: 0x06000367 RID: 871 RVA: 0x00004CDF File Offset: 0x00002EDF
			public List<string> DriverVersion { get; private set; }

			// Token: 0x06000368 RID: 872 RVA: 0x0002F4AC File Offset: 0x0002D6AC
			public Class38()
			{
				this.Name = new List<string> { "null", "null" };
				this.VideoProcessor = new List<string> { "null", "null" };
				this.AdapterRAM = new List<string> { "null", "null" };
				this.DriverVersion = new List<string> { "null", "null" };
				this.method_0();
			}

			// Token: 0x06000369 RID: 873 RVA: 0x0002F54C File Offset: 0x0002D74C
			private void method_0()
			{
				List<ManagementObject> list = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController").Get().Cast<ManagementObject>().Take(2)
					.ToList<ManagementObject>();
				for (int i = 0; i < list.Count; i++)
				{
					List<string> name = this.Name;
					int num = i;
					object obj = list[i]["Name"];
					name[num] = ((obj != null) ? obj.ToString() : null);
					this.AdapterRAM[i] = ((list[i]["AdapterRAM"] != null) ? ((Convert.ToUInt64(list[i]["AdapterRAM"]) / 1048576UL).ToString() + " MB") : "null");
					List<string> driverVersion = this.DriverVersion;
					int num2 = i;
					object obj2 = list[i]["DriverVersion"];
					driverVersion[num2] = ((obj2 != null) ? obj2.ToString() : null);
					List<string> videoProcessor = this.VideoProcessor;
					int num3 = i;
					object obj3 = list[i]["VideoProcessor"];
					videoProcessor[num3] = ((obj3 != null) ? obj3.ToString() : null);
				}
			}

			// Token: 0x04000443 RID: 1091
			[CompilerGenerated]
			private List<string> list_0;

			// Token: 0x04000444 RID: 1092
			[CompilerGenerated]
			private List<string> list_1;

			// Token: 0x04000445 RID: 1093
			[CompilerGenerated]
			private List<string> list_2;

			// Token: 0x04000446 RID: 1094
			[CompilerGenerated]
			private List<string> list_3;
		}
	}
}
