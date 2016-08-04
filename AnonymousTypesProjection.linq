<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
</Query>

void Main()
{
	var l = new List<Item>();
	for(int i=0; i<10; i++)
	{
		l.Add(new Item(){Field1 = (100+i).ToString(), Field2 = (200+i).ToString()});
	}
	
	var x = ( from f in l
				where f.Field1.Length > 0
				select f );
	x.Dump();
	
	var anontypes = l.Select(f => new { val1 = f.Field1, val2 = f.Field2, Unknown = "unknown" } );
	anontypes.Dump();
	
	foreach(var a in anontypes)
	{
		Console.WriteLine(a.val1 + " " + a.val2);
	}
}

// Define other methods and classes here


public class Item
{
	public string Field1;
	public string Field2;
}