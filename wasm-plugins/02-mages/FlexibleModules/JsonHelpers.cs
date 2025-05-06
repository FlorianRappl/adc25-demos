using System.Text.Json;

namespace FlexibleModules;

public static class JsonHelpers
{
    public static async Task<IDictionary<string, object?>> ReadJsonBodyAsDictionaryAsync(this HttpContext context)
    {
        var jsonElement = await context.Request.ReadFromJsonAsync<JsonElement>();
        return JsonElementToDictionary(jsonElement);
    }

    private static IDictionary<string, object?> JsonElementToDictionary(JsonElement element)
    {
        var dict = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);
        foreach (var property in element.EnumerateObject())
        {
            dict[property.Name] = ExtractValue(property.Value);
        }
        return dict;
    }

    private static object? ExtractValue(JsonElement element)
    {
        return element.ValueKind switch
        {
            JsonValueKind.Object => JsonElementToDictionary(element),
            JsonValueKind.Array => element.EnumerateArray().Select(ExtractValue).ToList(),
            JsonValueKind.String => element.GetString(),
            JsonValueKind.Number => element.TryGetInt64(out long l) ? (object)l : element.GetDouble(),
            JsonValueKind.True => true,
            JsonValueKind.False => false,
            JsonValueKind.Null => null,
            _ => null
        };
    }
}
