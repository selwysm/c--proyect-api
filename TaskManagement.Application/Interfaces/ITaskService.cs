using TaskManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManagement.Application.Services
{
    public interface ITaskService
    {
        Task<List<TaskItem>> GetAllTasksAsync();
        Task<TaskItem?> GetTaskByIdAsync(string taskId);
        Task AddTaskAsync(TaskItem task);
        Task<List<TaskItem>> GetTasksByStatusAsync(string status);
        Task UpdateTaskAsync(string taskId, TaskItem updatedTask);
        Task DeleteTaskAsync(string taskId);
    }
}
