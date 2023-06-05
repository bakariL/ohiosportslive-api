using FluxLiveCore.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FluxLiveCore.Data.Base
{
    public class EntityEditableRecord : IEntityEditable
    {
        [ConcurrencyCheck]
        public DateTimeOffset LastModified { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [NotMapped]
        [JsonIgnore]
        public bool IsUnintialized => Id == default;
    }
}
