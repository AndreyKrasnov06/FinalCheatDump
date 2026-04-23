using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ns0
{
	// Token: 0x02000002 RID: 2
	[CompilerGenerated]
	internal sealed class Class0<T>
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002A54 File Offset: 0x00000C54
		public T job
		{
			get
			{
				return this.gparam_0;
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002A5C File Offset: 0x00000C5C
		[DebuggerHidden]
		public Class0(T gparam_1)
		{
			this.gparam_0 = gparam_1;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00005490 File Offset: 0x00003690
		[DebuggerHidden]
		public override bool Equals(object obj)
		{
			Class0<T> @class = obj as Class0<T>;
			return this == @class || (@class != null && EqualityComparer<T>.Default.Equals(this.gparam_0, @class.gparam_0));
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002A6B File Offset: 0x00000C6B
		[DebuggerHidden]
		public override int GetHashCode()
		{
			return -1222452897 + EqualityComparer<T>.Default.GetHashCode(this.gparam_0);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000054C8 File Offset: 0x000036C8
		[DebuggerHidden]
		public override string ToString()
		{
			IFormatProvider formatProvider = null;
			string text = "{{ job = {0} }}";
			object[] array = new object[1];
			int num = 0;
			T t = this.gparam_0;
			array[num] = ((t != null) ? t.ToString() : null);
			return string.Format(formatProvider, text, array);
		}

		// Token: 0x04000001 RID: 1
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly T gparam_0;
	}
}
