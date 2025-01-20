using MongoDB.Driver;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

using DomainTaskStatus = TaskManagement.Domain.Entities.TaskStatus;

namespace TaskManagement.Infrastructure.Persistence
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IMongoCollection<TaskItem> _taskCollection;

        public TaskRepository(IMongoDatabase database)
        {
            _taskCollection = database.GetCollection<TaskItem>("Tasks");
        }

        public async Task<List<TaskItem>> GetAllTasksAsync()
        {
            return await _taskCollection.Find(_ => true).ToListAsync();
        }

        public async Task<TaskItem?> GetTaskByIdAsync(string taskId)
        {
            var filter = Builders<TaskItem>.Filter.Eq(t => t.Id, taskId);
            return await _taskCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddTaskAsync(TaskItem task)
        {
            await _taskCollection.InsertOneAsync(task);
        }

        public async Task<List<TaskItem>> GetTasksByStatusAsync(string status)
        {
            if (!Enum.TryParse(status, out DomainTaskStatus enumStatus))
                throw new ArgumentException($"Estado inválido: {status}");

            return await _taskCollection.Find(task => task.Status == enumStatus).ToListAsync();
        }

        public async Task UpdateTaskStatusAsync(string taskId, string newStatus)
        {
            if (!Enum.TryParse(newStatus, out DomainTaskStatus enumStatus))
                throw new ArgumentException($"Estado inválido: {newStatus}");

            var filter = Builders<TaskItem>.Filter.Eq(t => t.Id, taskId);
            var update = Builders<TaskItem>.Update.Set(t => t.Status, enumStatus);
            await _taskCollection.UpdateOneAsync(filter, update);
        }

        public async Task UpdateTaskAsync(string taskId, TaskItem updatedTask)
        {
            var filter = Builders<TaskItem>.Filter.Eq(t => t.Id, taskId);
            var update = Builders<TaskItem>.Update
                .Set(t => t.Title, updatedTask.Title)
                .Set(t => t.Description, updatedTask.Description)
                .Set(t => t.DueDate, updatedTask.DueDate)
                .Set(t => t.Status, updatedTask.Status); 

            await _taskCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteTaskAsync(string taskId)
        {
            var filter = Builders<TaskItem>.Filter.Eq(t => t.Id, taskId);
            await _taskCollection.DeleteOneAsync(filter);
        }
    }
}
