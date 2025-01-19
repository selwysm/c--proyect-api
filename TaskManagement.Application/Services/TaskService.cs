using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManagement.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<TaskItem>> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllTasksAsync();
        }

        public async Task<TaskItem?> GetTaskByIdAsync(string taskId)
        {
            return await _taskRepository.GetTaskByIdAsync(taskId);
        }

        public async Task AddTaskAsync(TaskItem task)
        {
            if (string.IsNullOrEmpty(task.Title))
                throw new ArgumentException("El título de la tarea no puede estar vacío.");

            if (string.IsNullOrEmpty(task.Status))
                task.Status = "Pendiente";

            await _taskRepository.AddTaskAsync(task);
        }

        public async Task<List<TaskItem>> GetTasksByStatusAsync(string status)
        {
            return await _taskRepository.GetTasksByStatusAsync(status);
        }

        public async Task UpdateTaskAsync(string taskId, TaskItem updatedTask)
        {
            if (string.IsNullOrEmpty(updatedTask.Title))
                throw new ArgumentException("El título de la tarea no puede estar vacío.");

            await _taskRepository.UpdateTaskAsync(taskId, updatedTask);
        }

        public async Task DeleteTaskAsync(string taskId)
        {
            await _taskRepository.DeleteTaskAsync(taskId);
        }
    }
}
