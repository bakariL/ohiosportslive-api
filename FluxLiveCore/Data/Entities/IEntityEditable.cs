namespace FluxLiveCore.Data.Entities
{
    public interface IEntityEditable : IEntity
    {
        DateTimeOffset LastModified { get; }
    }
}
