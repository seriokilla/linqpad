<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
</Query>

//static string ffmpegexec = @"C:\ffmpeg-20140501-git-feaa31d-win32-static\bin\ffmpeg.exe";
static string ffmpegexec = @"C:\Program Files (x86)\i-Funbox DevTeam\ffmpeg.exe";
static string ffmpegcmd = "-i \"{0}\" -acodec libmp3lame -ac 2 -ab 160000 \"{1}\"";
//static string inputdir = @"C:\jlai\aac\";
static string inputdir = @"C:\Users\laijj\Music\Pandora";
static string outputdir = @"C:\jlai\_mp3\";

void Main()
{
	ConvertFilesThreaded(inputdir);
	return;

//	var dirs = Directory.GetDirectories(inputdir);
//	Console.WriteLine("START: " + DateTime.Now.ToString());
//	foreach(var d in dirs)
//	{
//		ConvertFilesInDir(d);
//	}
//	Console.WriteLine("END: " + DateTime.Now.ToString());
}

void ConvertFilesThreaded(string root)
{
	var bag = new System.Collections.Concurrent.ConcurrentBag<string>();
	
	var dirs = Directory.EnumerateDirectories(root);
	var dirlist = new List<string>(dirs);
	if (dirlist.Count() == 0)
	{
		dirlist.Add(root);
	}

	
	// fill bag
	foreach(var dir in dirlist)
	{
		var outdir = dir.Replace(inputdir, outputdir);
		if (!Directory.Exists(outdir))
			Directory.CreateDirectory(outdir);
			
		var files = Directory.GetFiles(dir);
		foreach(var file in files)
		{
			bag.Add(file);
		}
	}
	
	var MAX_THREADS = 4;
	var threads = new List<System.Threading.Tasks.Task>();
	for(int i=0; i<MAX_THREADS; i++)
	{
		threads.Add(System.Threading.Tasks.Task.Factory.StartNew(() => {ThreadFunction(bag);}));
	}
	
	System.Threading.Tasks.Task.WaitAll(threads.ToArray());
}

void ThreadFunction(System.Collections.Concurrent.ConcurrentBag<string> bag)
{
	while(!bag.IsEmpty)
	{
		string infile;
		bag.TryTake(out infile);
		
		var outfile = infile.Replace(inputdir, outputdir);
		if (File.Exists(outfile))
			continue;
			
		var ffmpegarg = String.Format(ffmpegcmd, infile, outfile);
		ProcessFile(ffmpegexec, ffmpegarg);
	}
	Console.WriteLine("Thread done. " + System.Threading.Thread.CurrentThread.ManagedThreadId);
}

void ConvertFilesInDir(string dir)
{
	var files = Directory.GetFiles(dir);
	foreach (var infile in files)
	{
		var outdir = dir.Replace(inputdir, outputdir);
		
		if (!Directory.Exists(outdir))
			Directory.CreateDirectory(outdir);
			
		var outfile = infile.Replace(inputdir, outputdir);
		if (File.Exists(outfile)) 
			continue;
		
		var ffmpegarg = String.Format(ffmpegcmd, infile, outfile);
		
		ProcessFile(ffmpegexec, ffmpegarg);
	}
}

void ConvertFilesInDirThreadedBatch(string dir)
{
	var files = Directory.GetFiles(dir);
	foreach(var batchfiles in Batch<string>(files.ToList(), 4))
	{
		var tasklist = new List<System.Threading.Tasks.Task>();
		foreach(var infile in batchfiles)
		{
			var outdir = dir.Replace(inputdir, outputdir);
			
			if (!Directory.Exists(outdir))
				Directory.CreateDirectory(outdir);
				
			var outfile = infile.Replace(inputdir, outputdir);
			if (File.Exists(outfile))
				continue;
			
			var ffmpegarg = String.Format(ffmpegcmd, infile, outfile);
			
			var t = System.Threading.Tasks.Task.Run(() => {ProcessFile(ffmpegexec, ffmpegarg);});
			tasklist.Add(t);
		}
		System.Threading.Tasks.Task.WaitAll(tasklist.ToArray());
	}
}

IEnumerable<IEnumerable<T>> Batch<T>(List<T> source, int batchSize)
{
	for(int i=0; i<source.Count; i+=batchSize)
	{
		yield return source.Skip(i).Take(batchSize);
	}
}

void ProcessFile(string ffmpegexec, string ffmpegarg)
{
	var process = new Process();
	process.StartInfo = new ProcessStartInfo()
	{
		WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
		FileName = ffmpegexec,
		Arguments = ffmpegarg,
	};
	
	process.Start();
	Console.WriteLine(ffmpegarg);
	process.WaitForExit();
}