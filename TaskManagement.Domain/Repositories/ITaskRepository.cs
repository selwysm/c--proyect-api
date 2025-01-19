using TaskManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Repositories
{
    public interface ITaskRepository
    {
        Task<List<TaskItem>> GetAllTasksAsync();
        Task<TaskItem?> GetTaskByIdAsync(string taskId);
        Task AddTaskAsync(TaskItem task);
        Task<List<TaskItem>> GetTasksByStatusAsync(string status);
        Task UpdateTaskStatusAsync(string taskId, string newStatus);
        Task UpdateTaskAsync(string taskId, TaskItem updatedTask);
        Task DeleteTaskAsync(string taskId);
    }
}
