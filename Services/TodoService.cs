using Mongo2Go;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListBlazor.Shared;

namespace ToDoListBlazor.Services
{
    public class TodoService
    {
        private readonly IMongoCollection<TodoItem> _todos;
        private readonly MongoDbRunner _runner;

        public TodoService()
        {
            _runner = MongoDbRunner.Start();
            var client = new MongoClient(_runner.ConnectionString);
            var database = client.GetDatabase("TodoDb");
            _todos = database.GetCollection<TodoItem>("Todos");
        }

        public async Task<List<TodoItem>> GetAsync() => await _todos.Find(todo => true).ToListAsync();

        public async Task<TodoItem> GetAsync(string id) => await _todos.Find(todo => todo.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(TodoItem todo) => await _todos.InsertOneAsync(todo);

        public async Task UpdateAsync(string id, TodoItem todo) => await _todos.ReplaceOneAsync(todo => todo.Id == id, todo);

        public async Task DeleteAsync(string id) => await _todos.DeleteOneAsync(todo => todo.Id == id);

        public void Dispose() => _runner.Dispose();
    }
}
