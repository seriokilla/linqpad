<Query Kind="Program" />

void Main()
{
	var l = new List<MyObj>();
	l.Add(new MyObj(1,100));
	l.Add(new MyObj(1,100));
	l.Add(new MyObj(1,100));
	l.Add(new MyObj(1,100));
	l.Add(new MyObj(1,100));
	l.Add(new MyObj(2,200));
	l.Add(new MyObj(2,200));
	l.Add(new MyObj(2,200));
	l.Add(new MyObj(2,200));
	l.Add(new MyObj(2,200));
	
	var a = l.ToArray();
	var p = a.GroupBy (x => x.Index).ToArray();
	p.Dump();
	
	p[0].Sum(f => f.Value).Dump();
	p[1].Sum(f => f.Value).Dump();
	
	LinqGroupByDate();
}

public void LinqGroupByDate()
{
	var l = new List<stuff>();
	
	l.Add(new stuff{ d = new DateTime(2015,1,1), v=101});
	l.Add(new stuff{ d = new DateTime(2015,1,1), v=101});
	l.Add(new stuff{ d = new DateTime(2015,1,1), v=101});
	l.Add(new stuff{ d = new DateTime(2015,1,1), v=101});
	l.Add(new stuff{ d = new DateTime(2015,1,1), v=101});
	l.Add(new stuff{ d = new DateTime(2015,1,2), v=201});
	l.Add(new stuff{ d = new DateTime(2015,1,2), v=201});
	l.Add(new stuff{ d = new DateTime(2015,1,2), v=201});
	
	var a = l.ToArray();
	var parts = a.GroupBy (x => x.d).ToArray();
	parts[0].Sum(f => f.v).Dump();
	parts[1].Sum(f => f.v).Dump();
}

public class stuff
{
	public DateTime d;
	public int v;
}

// Define other methods and classes here
public class MyObj
{
	public int Index;
	public int Value;
	
	public MyObj(int idx, int val)
	{
		Index = idx;
		Value = val;
	}
}