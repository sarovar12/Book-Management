using System.Text.Json.Serialization;

namespace BookManagement.Domain.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StaffType
    {
        Administrator =0,
        LibraryStaff =1

    }
}
