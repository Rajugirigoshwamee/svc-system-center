using svc.system.center.migration.DbContexts;

namespace svc.system.center.business.layer.Handler;

public class TransactionCommandHandler<TCommand, TResponse> : ICommandHandler<TCommand, TResponse>
{
    public ICommandHandler<TCommand, TResponse> _decorated { get; set; }
    public MasterDbContext _mastersDbContext { get; set; }

    public TransactionCommandHandler(ICommandHandler<TCommand, TResponse> decorated, MasterDbContext mastersDbContext)
    {
        _decorated = decorated;
        _mastersDbContext = mastersDbContext;
    }

    public async Task<TResponse> Handle(TCommand command)
    {
        TResponse response;
        using var transaction = _mastersDbContext.Database.BeginTransaction();
        try
        {
            TResponse result = await _decorated.Handle(command: command);
            transaction.Commit();
            response = result;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw;
        }
        return response;
    }
}