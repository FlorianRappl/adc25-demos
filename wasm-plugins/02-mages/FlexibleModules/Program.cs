using FlexibleModules;
using Mages.Core;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var endpoints = new List<EndpointDef>();

app.MapGet("/", () => "Hello World!");

var pluginDir = app.Configuration.GetValue<string>("PluginDir")!;
var files = Directory.EnumerateFiles(pluginDir);

void IntegratePlugin(string file)
{
    var source = File.ReadAllText(file);
    var engine = new Engine();

    engine.SetFunction("log", (string content) => Console.WriteLine(content));

    engine.SetFunction("registerGet", (string path, Function handler) =>
    {
        endpoints.Add(new EndpointDef
        {
            Handler = handler,
            Method = "GET",
            Path = path,
        });
    });
    engine.SetFunction("registerPost", (string path, Function handler) =>
    {
        endpoints.Add(new EndpointDef
        {
            Handler = handler,
            Method = "POST",
            Path = path,
        });
    });
    engine.SetFunction("registerPut", (string path, Function handler) =>
    {
        endpoints.Add(new EndpointDef
        {
            Handler = handler,
            Method = "PUT",
            Path = path,
        });
    });
    engine.SetFunction("registerDelete", (string path, Function handler) =>
    {
        endpoints.Add(new EndpointDef
        {
            Handler = handler,
            Method = "DELETE",
            Path = path,
        });
    });

    engine.Interpret(source);
}

foreach (var file in files)
{
    IntegratePlugin(file);
}

var fsw = new FileSystemWatcher(pluginDir)
{
    EnableRaisingEvents = true
};
fsw.Created += (sender, e) =>
{
    IntegratePlugin(e.FullPath);
};

app.MapFallback(async context =>
{
    var path = context.Request.Path.Value?.TrimEnd('/');
    var method = context.Request.Method;
    var endpoint = endpoints.FirstOrDefault(ep => ep.Method == method && ep.Path == path);

    if (endpoint is not null)
    {
        if (method == "POST" || method == "PUT")
        {
            var body = await context.ReadJsonBodyAsDictionaryAsync();
            await context.Response.WriteAsync(endpoint.Handler([context, body]).ToString()!);
        }
        else
        {
            await context.Response.WriteAsync(endpoint.Handler([context]).ToString()!);
        }
    }
    else
    {
        context.Response.StatusCode = 404;
    }
});

app.Run();
