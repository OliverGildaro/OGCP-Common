namespace ArtForAll.Shared.Interfaces
{
    using ArtForAll.Shared.ErrorHandler;
    public interface IMutationsRepository<TEntity, TError, TEntityId>
        where TEntity : class
        where TError : class
    {
        Result Insert(TEntity entity);
        Task<Result<TEntity, TError>> FindAsync(TEntityId entityId);
        Task<Result> SaveChangesAsync();
    }
}
