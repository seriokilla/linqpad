<Query Kind="Program" />

void Main()
{
	var l = new List<Stuff>();
	l.Add(new Stuff(1, "one", 1, "nc"));
	l.Add(new Stuff(2, "two", 1, "fl"));
	l.Add(new Stuff(3, "three", 2, "ga"));
	l.Add(new Stuff(4, "four", 2, "ca"));
	l.Add(new Stuff(5, "five", 2, null));
	
	GetStuffLoop(l, 2).Dump();
	GetStuffLinq(l, 2).Dump();
	GetStuffYieldReturn(l, 2).Dump();
	
	var s = l.Where (x => x.age >= 2).Select (x => new {Name = x.name, State = x.state, Source = "UNKNOWN"});
	s.Dump();
	
	var s1 = (from x in l
				where x.age >= 2
				orderby x.id
				select new {Name = x.name, ID = x.id, Source = "UNK"});
				
	s1.Dump();
}
public IEnumerable<Stuff> GetStuffLoop(List<Stuff> l,int age)
{
	var res = new List<Stuff>();
	foreach(var s in l)
	{
		if (s.age == age && s.state != null)
				res.Add(s);
	}
	return res;
}

public IEnumerable<Stuff> GetStuffLinq(List<Stuff> l, int age)
{
	return l
		.Where (x => x.age == age && x.state != null)
		.Select (x => x);
}

public IEnumerable<Stuff> GetStuffYieldReturn(List<Stuff> l, int age)
{
	foreach(var s in l)
	{
		if (s.age == age && s.state != null)
			yield return s;
	}
}

// Define other methods and classes here
public class Stuff
{
	public Stuff(int i, string n, int a, string s)
	{
		id = i; name = n; age = a; state = s;
	}
	public int id;
	public string name;
	public int age;
	public string state;
}