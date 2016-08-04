<Query Kind="Program" />

void Main()
{
	var ans = GetLeft() & GetRight(); // no short circuit
	ans.Dump();
	
	ans = GetLeft() && GetRight();  // short circuits
	ans.Dump();
}

bool GetLeft() { return false;}
bool GetRight() { return true;}

// Define other methods and classes here
