using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ToDoListBlazor.Shared
{
    public class TodoItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }

}
