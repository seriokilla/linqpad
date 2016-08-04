<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

internal class Program
	{
		private static readonly Random rand = new Random();

		private static void Main()
		{
			for (int i = 0; i < 6; i++)
			{
				ThreadFunction();
			}

			Console.WriteLine("<End>");
			Task.WaitAll();
		}

		private static async void ThreadFunction()
		{
			int sleepSecs = 0;
			lock(rand)
			{
				sleepSecs = rand.Next(5);
			}
			
			Console.WriteLine("{0:000} 1 {1} sleep {2}", System.Threading.Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString("H:mm:ss.fff"), sleepSecs);
			
			await LongRunningProcess(sleepSecs);
			
			Console.WriteLine("{0:000} 0 {1} sleep {2}", System.Threading.Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString("H:mm:ss fff"), sleepSecs);
		}

		private static Task LongRunningProcess(int secs)
		{
			return Task.Run(() => { Thread.Sleep(secs*1000); });
		}
	}

// Define other methods and classes here