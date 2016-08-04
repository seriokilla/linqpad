<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
</Query>

static System.Random rand = new System.Random();

void Main()
{
	var tasks = new List<System.Threading.Tasks.Task>();
	for(int i=0; i<20; i++)
	{
		var action = new System.Action(ThreadFunction);
		tasks.Add(System.Threading.Tasks.Task.Run(action));
	}
	System.Threading.Tasks.Task.WaitAll(tasks.ToArray());
	
	Console.WriteLine("<End>");
	Console.Read();
}

void ThreadFunction()
{
	int secs = rand.Next(5)+1;
	Console.WriteLine("{0:000} 1 {1} sleep {2}", System.Threading.Tasks.Task.CurrentId, DateTime.Now.ToString("H:mm:ss.fff"), secs);
	Sleep(secs);
	Console.WriteLine("{0:000} 0 {1} sleep {2}", System.Threading.Tasks.Task.CurrentId, DateTime.Now.ToString("H:mm:ss fff"), secs);
}

void Sleep(int secs)
{
	System.Threading.Thread.Sleep(secs * 1000);
}

// Define other methods and classes here