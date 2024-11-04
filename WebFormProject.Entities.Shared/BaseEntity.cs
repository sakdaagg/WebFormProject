namespace WebFormProject.Entities.Shared
{
    // This can be modified to BaseEntity<TId> to support multiple key types (e.g. Guid)
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
