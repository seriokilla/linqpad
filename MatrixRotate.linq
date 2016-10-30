<Query Kind="Program" />

void Main()
{
//	var m = new [,] 
//	{
//		{11,12,13,14,15},
//		{21,22,23,24,25},
//		{31,32,33,34,35},
//		{41,42,43,44,45},
//		{51,52,53,54,55},
//	};

	var m = new [,]{
		{11, 12, 13},
		{21, 22, 23},
		{31, 32, 33},
	};
	
	m.Dump();
	Rotate(m);
	m.Dump();
}

// Define other methods and classes here

void Rotate(int[,] matrix)
{
	int n = matrix.GetLength(0);
	for(int i=0; i < n/2; i++)
	{
		int last = n-1-i;
		for(int j=i; j<last; j++)
		{
			int start = j-i;
			
			int temp = matrix[i,j];
			matrix[i,j] = matrix[last-start, i];
			matrix[last-start, i] = matrix[last, last-start];
			matrix[last, last-start] = matrix[j, last];
			matrix[j, last] = temp;
			
			matrix.Dump();
		}
		Console.WriteLine("next");
	}
}