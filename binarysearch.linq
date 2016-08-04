<Query Kind="Program" />

void Main()
{
	var keys = new List<int>{1,2,3,4,5,6,7,8,9,10};
	var f = 5;
	var found = binsearchloop(f, keys);
	found.Dump();
	
	found = binsearchrec(f, keys, 0, keys.Count-1);
	found.Dump();
	
	rev("ab").Dump();
}

// Define other methods and classes here
bool binsearchrec(int found, List<int> keys, int low, int high)
{
	if (low <= high)
	{
		int mid = (low + high)/2;
		if (keys[mid] == found) return true;
		else if (keys[mid] > found) return binsearchrec(found, keys, low, mid-1);
		else if (keys[mid] < found) return binsearchrec(found, keys, mid+1, high);
	}
	
	return false;
}

bool binsearchloop(int found, List<int> keys)
{
	int low = 0;
	int high = keys.Count - 1;
		
	while(low <= high)
	{
		int mid = (low + high)/2;

		if (keys[mid] == found)
			return true;
		else if (keys[mid] < found)
			low = mid + 1;
		else
			high = mid -1;
	}
	
	return false;
}