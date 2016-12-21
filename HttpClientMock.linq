<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

void Main()
{
	var fakeResponseHandler = new FakeResponseHandler();
	var msg = new HttpResponseMessage(HttpStatusCode.OK);
	msg.Content = new StringContent("{ 'value': 666 }");
	
	fakeResponseHandler.AddFakeResponse(new Uri("http://example.org/test"), msg);
	
	var httpClient = new HttpClient(fakeResponseHandler);
	
	var response1 = httpClient.GetAsync("http://example.org/notthere");
	var response2 = httpClient.GetAsync("http://example.org/test");
	
	Console.WriteLine("code1: " + response1.Result.StatusCode);
	//Console.WriteLine("code2: " + response2.Result.StatusCode);
	
	var data = response2.Result.Content.ReadAsStringAsync().Result;
	Console.WriteLine(data);
}

// Define other methods and classes here
public class FakeResponseHandler : DelegatingHandler
{
   private readonly Dictionary<Uri, HttpResponseMessage> _FakeResponses = new Dictionary<Uri, HttpResponseMessage>(); 

   public void AddFakeResponse(Uri uri, HttpResponseMessage responseMessage)
   {
           _FakeResponses.Add(uri,responseMessage);
   }

   protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
   {
       if (_FakeResponses.ContainsKey(request.RequestUri))
       {
           return _FakeResponses[request.RequestUri];
       }
       else
       {
           return new HttpResponseMessage(HttpStatusCode.NotFound) { RequestMessage = request};
       }

   }
}