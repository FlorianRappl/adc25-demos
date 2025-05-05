using Mages.Core;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var engine = new Engine();
engine.SetConstant("db", new Database());

app.MapGet("/", () => "Hello World!");

app.MapPost("/", (ExternalCode source) => engine.Interpret(source.Code));

app.Run();

