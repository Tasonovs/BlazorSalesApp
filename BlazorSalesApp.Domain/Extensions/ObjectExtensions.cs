using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorSalesApp.Domain.Extensions;

public static class ObjectExtensions
{
    private static readonly JsonSerializerOptions Options = new JsonSerializerOptions()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        WriteIndented = false,
        Converters =
        {
            new JsonStringEnumConverter()
        },
        IncludeFields = true
    };
    
    public static T? DeepCopy<T>(this T? source) where T : class
    {
        if (source is null)
        {
            return null;
        }

        var serialized = JsonSerializer.Serialize(source, Options);

        return JsonSerializer.Deserialize<T>(serialized);
    }
}