<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
</Query>

void Main()
{
	int e = 2, f = 100;
	int d = eggDrop(e, f);
    Console.WriteLine("Minimum number of trials in worst case with {0} eggs and {1} floors is {2} \n", e, f, d);
}

// Define other methods and classes here
int eggDrop(int n, int k)
{
    /* A 2D table where entery eggFloor[i][j] will represent minimum
       number of trials needed for i eggs and j floors. */
    int[,] eggFloor = new int[n+1,k+1];
    int res;
    int i, j, x;
 
    // We need one trial for one floor and0 trials for 0 floors
    for (i = 1; i <= n; i++)
    {
        eggFloor[i,1] = 1;
        eggFloor[i,0] = 0;
    }
 
    // We always need j trials for one egg and j floors.
    for (j = 1; j <= k; j++)
        eggFloor[1,j] = j;
 
    // Fill rest of the entries in table using optimal substructure
    // property
    for (i = 2; i <= n; i++)
    {
        for (j = 2; j <= k; j++)
        {
            eggFloor[i,j] = Int32.MaxValue;
            for (x = 1; x <= j; x++)
            {
                res = 1 + max(eggFloor[i-1,x-1], eggFloor[i,j-x]);
                if (res < eggFloor[i,j])
                    eggFloor[i,j] = res;
            }
        }
    }
 
    // eggFloor[n,k] holds the result
    return eggFloor[n,k];
}

int max(int a, int b) { return (a > b)? a: b; }