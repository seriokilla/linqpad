<Query Kind="Program" />

void Main()
{
	SieveOfEratosthenes(100);
}

// Define other methods and classes here
void SieveOfEratosthenes(int n)
{
    // Create a boolean array "prime[0..n]" and initialize
    // all entries it as true. A value in prime[i] will
    // finally be false if i is Not a prime, else true.
    var prime = new bool[n+1];
     
    for (int p=2; p*p<=n; p++)
    {
        // If prime[p] is not changed, then it is a prime
        if (prime[p] == false)
        {
            // Update all multiples of p
            for (int i=p*2; i<=n; i += p)
                prime[i] = true;
        }
    }
 
    // Print all prime numbers
    for (int p=2; p<=n; p++)
       if (prime[p] == false)
	   	Console.WriteLine(p);
          //cout << p << " ";
}
