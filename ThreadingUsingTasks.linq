<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
</Query>

static System.Random rand = new System.Random();

void Main()
{
	var tasks = new List<System.Threading.Tasks.Task<int>>();
	for(int i=0; i<20; i++)
	{
		var f = new System.Func<int>(ThreadFunction);
		//tasks.Add(System.Threading.Tasks.Task.Run(f));
		//var action = new System.Func<int,int>(ThreadFunction);
		tasks.Add(System.Threading.Tasks.Task.Run(f));
	}
	System.Threading.Tasks.Task.WaitAll(tasks.ToArray());
	
	Console.WriteLine("<End>");
	Console.Read();
	foreach(var t in tasks)
	{
		t.Result.Dump();
	}
}

int ThreadFunction()
{
	int secs = rand.Next(5)+1;
	Console.WriteLine("{0:000} 1 {1} sleep {2}", System.Threading.Tasks.Task.CurrentId, DateTime.Now.ToString("H:mm:ss.fff"), secs);
	Sleep(secs);
	Console.WriteLine("{0:000} 0 {1} sleep {2}", System.Threading.Tasks.Task.CurrentId, DateTime.Now.ToString("H:mm:ss fff"), secs);
	return secs;
}

void Sleep(int secs)
{
	System.Threading.Thread.Sleep(secs * 1000);
}

// Define other methods and classes here