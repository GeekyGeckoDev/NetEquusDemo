using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        Task RollbackAsync();

        Task ExecuteAsync(Func<Task> operation);

        Task BeginTransactionAsync();
    }
}
