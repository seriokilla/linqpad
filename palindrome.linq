<Query Kind="Program" />

void Main()
{
	var s = "abcdcba";
	var isAnagram = IsAnagram(s);
	Console.WriteLine(isAnagram);
}

// Define other methods and classes here
bool IsAnagram(string s)
{
	var rc = true;
	
	for(int i=0, j=s.Length-1; i<j; i++, j--)
	{
		if (s[i] != s[j])
		{	
			rc = false;
			break;
		}
	}
	return rc;
}