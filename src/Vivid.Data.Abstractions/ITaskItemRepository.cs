﻿using System.Threading;
using System.Threading.Tasks;
using Vivid.Data.Abstractions.Entities;

namespace Vivid.Data.Abstractions
{
    public interface ITaskItemRepository : IEntityRepository<TaskItem>
    {
        string TaskListName { get; }

        string UserName { get; }
        
        string TaskListId { get; }
        
        string UserId { get; }

        Task SetTaskListAsync(string username, string tasklistName, CancellationToken cancellationToken = default);
        
        Task<TaskItem> GetByNameAsync(string name, bool includeDeletedRecords = false,
            CancellationToken cancellationToken = default);

        Task<TaskItem[]> GetTaskItemsAsync(bool includeDeletedRecords = false,
            CancellationToken cancellationToken = default);
    }
}