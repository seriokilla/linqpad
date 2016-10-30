<Query Kind="Program" />

void Main()
{
	var rc = isAnagram("cinema", "iceman");
	Console.WriteLine(rc);
}

// Define other methods and classes here
bool isAnagram(string s1, string s2)
{
	var ss1 = s1.ToCharArray();
	var ss2 = s2.ToCharArray();
	
	Array.Sort(ss1);
	Array.Sort(ss2);
		
	return new string(ss1) == new string(ss2);
}