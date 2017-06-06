<Query Kind="Program" />

void Main()
{
	var s = System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffK");
	s.Dump();
	
	var u = System.DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffK");
	u.Dump();
	
	var u2 = System.DateTime.UtcNow.ToString("o", System.Globalization.CultureInfo.InvariantCulture);
	u2.Dump();
	
	var u3 = System.DateTime.UtcNow.ToString("O");
	u3.Dump();
}

// Define other methods and classes here