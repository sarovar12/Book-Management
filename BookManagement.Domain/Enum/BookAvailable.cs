

using System.Text.Json.Serialization;

namespace BookManagement.Domain.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BookAvailable
    {
        Available,
        NotAvailable
    }
}
