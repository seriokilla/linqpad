<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
</Query>

void Main()
{
	fib2(7).Dump();
	//fib(40).Dump();
}

// Define other methods and classes here
long fib(int n)
{
	if (n <= 1) return n;
	return fib(n-1) + fib(n-2);
}

long fib2(int n)
{
	if (n<=1) return n;
	
	long ans = 0;
	long f1 = 1;
	long f2 = 1;
	
	for(int i=2; i<n; i++)
	{
		ans = f1 + f2;
		f1 = f2;
		f2 = ans;
	}
	return ans;
}