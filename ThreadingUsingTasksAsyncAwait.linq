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
<<<<<<< HEAD
			for (int i = 0; i < 25; i++)
=======
			for (int i = 0; i < 20; i++)
>>>>>>> c249adade0d953b3cf6c95ad8bbab11089179051
			{
				ThreadFunction(i);
			}

			Console.WriteLine("<End>");
<<<<<<< HEAD
=======
			//Task.WaitAll();
>>>>>>> c249adade0d953b3cf6c95ad8bbab11089179051
		}

		private static async void ThreadFunction(int i)
		{
			int sleepSecs = 0;
			lock(rand)
			{
				sleepSecs = rand.Next(5, 10);
			}
			
			Console.WriteLine("{3:000} - {0:000} 1 {1} sleep {2}", System.Threading.Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString("H:mm:ss.fff"), sleepSecs, i);
			
			await LongRunningProcess(sleepSecs);
			
			Console.WriteLine("{3:000} - {0:000} 0 {1} sleep {2}", System.Threading.Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString("H:mm:ss fff"), sleepSecs, i);
		}

		private static Task LongRunningProcess(int secs)
		{
			return Task.Run(() => { Thread.Sleep(secs*1000); });
		}
	}

// Define other methods and classes here