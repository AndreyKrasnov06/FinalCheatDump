using System;
using System.Runtime.InteropServices;

namespace System
{
	// Token: 0x02000020 RID: 32
	[Guid("6d5140c1-7436-11ce-8034-00aa006009fa")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IOleServiceProvider
	{
		// Token: 0x060000F0 RID: 240
		void QueryService(ref Guid guidService, ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppvObject);
	}
}
