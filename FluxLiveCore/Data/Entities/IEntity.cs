using System.Text.Json.Serialization;

namespace FluxLiveCore.Data.Entities
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
