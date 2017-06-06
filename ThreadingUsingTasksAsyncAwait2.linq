<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>


internal class Program
	{
		private static readonly Random rand = new Random();

		private static void Main()
		{
			var list = new List<Task<int>>();
			for (int i = 0; i < 25; i++)
			{
				var t = ThreadFunction1(i);
				list.Add(t);
			}

			Console.WriteLine("<End>");
			
			foreach(var l in list)
			{
				Console.WriteLine("done: " + l.Result);
			}
		}
		

		private static async Task<int> ThreadFunction1(int i)
		{
			int sleepSecs = 0;
			lock(rand)
			{
				sleepSecs = rand.Next(5, 10);
			}
			
			Console.WriteLine("{3:000} {0:000} 1 {1} sleep {2}", System.Threading.Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString("H:mm:ss.fff"), sleepSecs, i);
			
			var rc = await LongRunningProcess(sleepSecs, i);

			Console.WriteLine("{3:000} {0:000} 3 {1} sleep {2}", System.Threading.Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString("H:mm:ss fff"), sleepSecs, i);
			return rc;
		}

		private static Task<int> LongRunningProcess(int sleepSecs, int i)
		{
			return Task<int>.Run(() => { Thread.Sleep(sleepSecs*1000); return i;});
		}
	}

// Define other methods and classes here