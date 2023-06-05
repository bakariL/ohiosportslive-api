using System.Text.Json.Serialization;

namespace FluxApiData.Data.Entities
{
    public interface IEntity
    {
        Guid Id { get; }

        [JsonIgnore]
        bool IsUnintialized
        {
            get;
        }
    }
}
