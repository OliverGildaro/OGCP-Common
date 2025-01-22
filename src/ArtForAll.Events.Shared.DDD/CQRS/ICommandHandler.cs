namespace ArtForAll.Shared.Contracts.CQRS
{
    public interface ICommandHandler<TCommand, TResult>
    {
        public Task<TResult> HandleAsync(TCommand command);
    }
}

