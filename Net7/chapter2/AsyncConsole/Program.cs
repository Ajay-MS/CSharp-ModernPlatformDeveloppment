// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

HttpClient client = new();
HttpResponseMessage response = await client.GetAsync("http://www.apple.com");
WriteLine($"Apple homepage has {response.Content.Headers.ContentLength} bytes");