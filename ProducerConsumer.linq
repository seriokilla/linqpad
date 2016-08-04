<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Collections.Concurrent.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <Namespace>System.Collections.Concurrent</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var p = new ProducerConsumer();
	p.Run();
}

public class ProducerConsumer
{
	int MAX_KEYWORDS_IN_POSTING_BATCH = 20;
	protected System.Collections.Concurrent.BlockingCollection<int> PostingQueue = new BlockingCollection<int>(100);
	public void Run()
	{
		var tasks = new List<Task>();

		tasks.Add(Task.Run(() => Consumer()));
		tasks.Add(Task.Run(() => Producer()));

		Task.WaitAll(tasks.ToArray());
		
		Console.WriteLine("Done");
	}
	
	public void Producer()
	{
		var idx = 0;
		do
		{
			Console.WriteLine("Adding: " + idx);
			PostingQueue.Add(idx);
			idx++;
			//Thread.Sleep(500);
		}while(idx < 200);
		PostingQueue.CompleteAdding();
	}
	
	public void Consumer()
	{
		while(!PostingQueue.IsCompleted)	
		{
			var postinglist = new List<int>();
			
//			int counter = 0;
//			foreach(var item in PostingQueue.GetConsumingEnumerable())
//			{
//				if (counter++ < MAX_KEYWORDS_IN_POSTING_BATCH)
//					postinglist.Add(item);
//				else break;
//			}
			lock(PostingQueue){
				for (var i = 0; i < MAX_KEYWORDS_IN_POSTING_BATCH && PostingQueue.Count > 0; i++)
				{
					postinglist.Add(PostingQueue.Take());	
				}
			}
			
			if (postinglist.Count() > 0)
				Console.WriteLine("Posting: " + string.Join(",",postinglist));
			else
				Thread.Sleep(2000);
		}
	}
}

