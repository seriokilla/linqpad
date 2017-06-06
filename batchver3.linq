<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
</Query>

void Main()
{
//	var listNeedsBatching = new []
//	{
//		1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16
//	};

	var listNeedsBatching = "abcdefghijklmnopq".ToCharArray();

	int batchsize = 3;
	int num = 1;
	
	foreach(var batch in Batch(listNeedsBatching, batchsize))
	{
		PrintStuff(num++, batch);
	}
}

public IEnumerable<IEnumerable<T>> Batch<T>(IEnumerable<T> source, int batchSize)
{
	for(int i=0; i<source.Count(); i+=batchSize)
	{
		yield return source.Skip(i).Take(batchSize);
	}
}

public void PrintStuff<T>(int set, IEnumerable<T> stuff)
{
	Console.WriteLine("--------------------------------" + set);
	foreach(var s in stuff)
	{
		Console.WriteLine(s);
	}
	Console.WriteLine("");
}