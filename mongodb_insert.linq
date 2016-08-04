<Query Kind="Program">
  <Reference>&lt;ProgramFilesX64&gt;\MongoDB\Server\3.0\lib.net\MongoDB.Bson.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\MongoDB\Server\3.0\lib.net\MongoDB.Driver.Core.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\MongoDB\Server\3.0\lib.net\MongoDB.Driver.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
</Query>

void Main()
{
	var filepath = @"C:\Users\jason.lai\Downloads\plot.list\plot.list";
	var reader = new StreamReader(filepath);
	string line = "";
	string title = "";
	var plot = new System.Text.StringBuilder();
	
	var client = new MongoDB.Driver.MongoClient("mongodb://localhost");
	var db = client.GetDatabase("test");
	
	while( (line = reader.ReadLine()) != null)
	{
		if (line.StartsWith("MV:"))
			title = line.Remove(0, 3);
			
		if (line.StartsWith("PL:"))
			plot.Append(line.Remove(0, 3) + " ");
			
		if (line.StartsWith("------"))
		{
			if (title.Length == 0) continue;
			
			Console.WriteLine("-------------------------------------------------------------------------------");
			Console.WriteLine(title);
			//Console.WriteLine(plot.ToString());
		
			var doc = new MongoDB.Bson.BsonDocument
			{
				{ "Title", title },
				{ "Plot", plot.ToString() }
			};
			
			var collection = db.GetCollection<MongoDB.Bson.BsonDocument>("movie");
			collection.InsertOneAsync(doc);
			
			plot.Clear();
		}
	}
}


