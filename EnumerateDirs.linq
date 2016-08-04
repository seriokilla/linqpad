<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
</Query>

void Main()
{
	var pids = Directory.EnumerateDirectories(@"\\dev-share-01\D2\CADS\Profiles");
	int i=1;
	foreach(var p in pids)
	{
		Console.WriteLine("Count {0}", i++);
		var reportdir = Path.Combine(p, @"CE\Reports");
	
		if (Directory.Exists(reportdir))
		{
			var files = Directory.GetFiles(reportdir);
			foreach(var f in files)
			{
				if (f.IndexOf("2015-04-01") > 0)
				{
					//File.Delete(f);					
					Console.WriteLine("Deleted " + f);
				}
			}
		}
	}
}

// Define other methods and classes here
