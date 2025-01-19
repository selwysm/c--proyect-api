using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace TaskManagement.Domain.Entities
{
    public class TaskItem
    {   
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] 
        public string? Id { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public string? Status { get; set; }
    }
}
