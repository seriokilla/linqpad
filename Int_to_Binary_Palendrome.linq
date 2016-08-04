<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var val = 2;
	var binary_string = ToBinaryString(val);
	var isPalendrome = IsPalendrome(binary_string);
	Console.WriteLine("binary_string: " + binary_string);
	Console.WriteLine("isPalendrome: " + isPalendrome);
}

// Define other methods and classes here

string ToBinaryString(int number)
{
	if (number == 0) return "0";
	
	var stack = new Stack<int>();
	var numerator = number;
	while(numerator > 0)
	{
		var rem = numerator % 2;
		stack.Push(rem);
		numerator = numerator / 2;
	}
	
	var str = "";
	while(stack.Count > 0)
	{
		str = str + stack.Pop().ToString();
	}
	
	return str;
}

bool IsPalendrome(string str)
{
	var start = 0;
	int end = str.Length-1;
	
	while(start < end)
	{
		if (str[start] == str[end])
		{
			start++;
			end--;
		}
		else
		{
			return false;
		}
	}
	return true;
}