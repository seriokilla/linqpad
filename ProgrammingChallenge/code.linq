<Query Kind="Program" />

void Main()
{
	var path = @"C:\jlai\Github\linqpad\ProgrammingChallenge\Files";
	var searchPattern = "pattern";
	
	var files = Directory.GetFiles(path);
	var tasks = new List<System.Threading.Tasks.Task<FileStats>>();
	foreach(var file in files)
	{
		var proc = new FileProcessor();
		proc._FilePath = file;
		proc._Pattern = searchPattern;
		
		var f = new System.Func<FileStats>(proc.GetCounts);
		tasks.Add(System.Threading.Tasks.Task.Run(f));
	}
	
	var finalStats = new FileStats();
	System.Threading.Tasks.Task.WaitAll(tasks.ToArray());
	foreach(var t in tasks)
	{
		finalStats.NumLines += t.Result.NumLines;
		finalStats.NumOccurrences += t.Result.NumOccurrences;
	}
	
	Console.WriteLine("Files: " + files.Length);
	Console.WriteLine("Lines: " + finalStats.NumLines);
	Console.WriteLine("Occurrences: " + finalStats.NumOccurrences);
}


// Define other methods and classes here
struct FileStats
{
	public int NumLines;
	public int NumOccurrences;
}

class FileProcessor
{
	public string _Pattern;
	public string _FilePath;

	public FileStats GetCounts()
	{
		var _stats = new FileStats();
		using (var sr = new StreamReader(_FilePath))
		{
			string line;
			while((line = sr.ReadLine()) != null)
			{
				int count = OccurrencesInLine(line);
				if (count > 0)
				{
					_stats.NumOccurrences += count;
					_stats.NumLines++;
				}
			}
		}
		
		return _stats;
	}
	
	public int OccurrencesInLine(string line)
	{
		int count = 0;
		int start = 0;
		while(start <line.Length)
		{
			var parts = line.IndexOf(_Pattern, start);
			if (parts >= 0){
				count++;
				start = parts + _Pattern.Length;
			}
			else
				break;
		}
		return count;
	}
}