<Query Kind="Program" />

void Main()
{
	var t1 = new Timekeeper(){
		firstname = "first",
		middlename = "middle",
	};
	
	IsTimekeeperValid(t1).Dump();
	
	var t2 = new Timekeeper(){
		firstname = "first",
		middlename = "middle",
		lastname = "last"
	};
	
	IsTimekeeperValid(t2).Dump();
}

// Define other methods and classes here

public class Timekeeper
{
	public string firstname {get;set;}
	public string middlename {get;set;}
	public string lastname {get;set;}
}

public bool IsTimekeeperValid(Timekeeper t)
{
	var properties = t.GetType().GetProperties();
	bool hasNullProperty = properties.Any(p => p.GetValue(t) == null);
	var val0 = properties[0].GetValue(t);
	var val1 = properties[1].GetValue(t);
	var val2 = properties[2].GetValue(t);
	return !hasNullProperty;
}