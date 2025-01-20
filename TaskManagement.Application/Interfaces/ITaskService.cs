using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities; 

namespace TaskManagement.Application.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskItem>> GetAllTasksAsync();
        Task<TaskItem?> GetTaskByIdAsync(string taskId);
        Task AddTaskAsync(TaskItem task);

        Task<List<TaskItem>> GetTasksByStatusAsync(TaskManagement.Domain.Entities.TaskStatus status);

        Task UpdateTaskAsync(string taskId, TaskItem updatedTask);
        Task DeleteTaskAsync(string taskId);
    }
}
