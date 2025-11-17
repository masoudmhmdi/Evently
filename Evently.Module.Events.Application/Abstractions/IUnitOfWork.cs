namespace Evently.Module.Events.Application.Abstractions;

public interface IUnitOfWork
{

    Task SaveChangeAsync();
}
