<Query Kind="Program">
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft SDKs\Azure\.NET SDK\v2.9\bin\plugins\Diagnostics\Newtonsoft.Json.dll</Reference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	var s = GetProperties<Matter>();	
	s.Dump();
}

string[] GetProperties<T>()
{
	var list = new List<string>();
	var props = typeof(T).GetProperties();
	var pp = props.SelectMany(f => f.GetCustomAttributes());
	foreach(var p in pp)
	{
		var j = p as JsonPropertyAttribute;
		list.Add(j.PropertyName);
	}
	return list.ToArray();
}
// Define other methods and classes here
public class Matter
	{
		[JsonProperty("Matter Number")]
		public string MatterNumber { get; set; }
		[JsonProperty("Matter Title")]
		public string MatterTitle { get; set; }
		[JsonProperty("Matter Description")]
		public string MatterDescription { get; set; }
		[JsonProperty("Contact Office")]
		public string ContactOffice { get; set; }
		[JsonProperty("Invoice Contact")]
		public string InvoiceContact { get; set; }
		[JsonProperty("Matter Contact")]
		public string MatterContact { get; set; }
		[JsonProperty("Matter Type")]
		public string MatterType { get; set; }
		[JsonProperty("Matter Status")]
		public string MatterStatus { get; set; }
		[JsonProperty("Historical Billed Fees")]
		public string HistoricalBilledFees { get; set; }
		[JsonProperty("Historical Billed Expenses")]
		public string HistoricalBilledExpenses { get; set; }
		[JsonProperty("Matter Currency")]
		public string MatterCurrency { get; set; }
		[JsonProperty("Created Date")]
		public string CreatedDate { get; set; }
		[JsonProperty("Closed Date")]
		public string ClosedDate { get; set; }
		[JsonProperty("Matter_SubType")]
		public string MatterSubType { get; set; }
	}