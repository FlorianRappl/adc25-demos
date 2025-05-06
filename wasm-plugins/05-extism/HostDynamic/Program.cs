using System.Net.Http.Json;
using Extism.Sdk;

var client = new HttpClient();
var response = await client.GetFromJsonAsync<ServiceResponse>("https://feed.dev.piral.cloud/api/v1/pilet/extism-demo");
var plugins = new List<Plugin>();

foreach (var item in response?.Items ?? Enumerable.Empty<ServiceResponseItem>())
{
    if (item.Link is not null)
    {
        Console.WriteLine("Loading {0} from {1}", item.Name, item.Link);
        var manifest = new Manifest(new UrlWasmSource(item.Link));
        var plugin = new Plugin(manifest, [], withWasi: true);
        plugins.Add(plugin);
    }
}

if (args.Length > 0)
{
    var name = args[0];
    var rest = args[1..];

    foreach (var plugin in plugins)
    {
        try
        {
            var output = plugin.Call(name, string.Join(" ", rest));
            Console.WriteLine(output);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Could not run in {0} due to {1}", plugin.Id, ex.Message);
        }
    }
}
else
{
    Console.WriteLine("No function provided.");
}
