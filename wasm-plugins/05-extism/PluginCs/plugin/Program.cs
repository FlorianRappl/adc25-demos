using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using Extism;

namespace Plugin;
public class Program
{
    public static void Main()
    {
        // Note: a `Main` method is required for the app to compile
    }

    [UnmanagedCallersOnly(EntryPoint = "greet")]
    public static int Greet()
    {
        var name = Pdk.GetInputString();
        var greeting = $"Hello, {name}!";
        Pdk.SetOutput(greeting);

        return 0;
    }

    [UnmanagedCallersOnly(EntryPoint = "add")]
    public static int Add()
    {
        var parameters = Pdk.GetInputJson(SourceGenerationContext.Default.Add);
        var sum = new Sum(parameters.a + parameters.b);
        Pdk.SetOutputJson(sum, SourceGenerationContext.Default.Sum);
        return 0;
    }
}

[JsonSerializable(typeof(Add))]
[JsonSerializable(typeof(Sum))]
public partial class SourceGenerationContext : JsonSerializerContext {}

public record Add(int a, int b);
public record Sum(int Result);