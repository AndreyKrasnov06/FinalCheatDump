using System;
using System.Threading;
using System.Threading.Tasks;

namespace System
{
	// Token: 0x02000029 RID: 41
	internal class TaskRunner
	{
		// Token: 0x0600017A RID: 378 RVA: 0x00014E84 File Offset: 0x00013084
		public async Task Run(Func<CancellationToken, Task> taskFactory, CancellationToken externalToken = default(CancellationToken))
		{
			object obj = this._lock;
			lock (obj)
			{
				this._cts.Cancel();
			}
			if (this._currentTask != null)
			{
				try
				{
					await this._currentTask;
				}
				catch (OperationCanceledException)
				{
				}
				catch (Exception)
				{
				}
			}
			obj = this._lock;
			lock (obj)
			{
				if (externalToken != default(CancellationToken))
				{
					this._cts = CancellationTokenSource.CreateLinkedTokenSource(new CancellationToken[] { externalToken });
				}
				else
				{
					this._cts = new CancellationTokenSource();
				}
				this._currentTask = taskFactory(this._cts.Token);
			}
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00014ED8 File Offset: 0x000130D8
		public void Cancel()
		{
			object @lock = this._lock;
			lock (@lock)
			{
				this._cts.Cancel();
			}
		}

		// Token: 0x040001CB RID: 459
		private Task _currentTask;

		// Token: 0x040001CC RID: 460
		private CancellationTokenSource _cts = new CancellationTokenSource();

		// Token: 0x040001CD RID: 461
		private readonly object _lock = new object();
	}
}
