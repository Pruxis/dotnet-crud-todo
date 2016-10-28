using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_crud_todo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet_crud_todo.Controllers {
    [Route("api/[controller]")]
    public class TodoController : Controller {

        public ITodoRepository TodoItems { get; set; }

        public TodoController(ITodoRepository todoItems) {
            TodoItems = todoItems;
        }

        [HttpGet]
        public IEnumerable<TodoItem> GetAll() {
            return TodoItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id) {
            if (TodoItems.Find(id) == null) {
                return NotFound();
            }
            return new ObjectResult(TodoItems.Find(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item) {
            if (item == null) { return BadRequest(); }
            TodoItems.Add(item);
            return CreatedAtRoute("GetTodo", new { id = item.Key }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TodoItem item) {
            if (item == null || item.Key != id) {
                return BadRequest();
            }
            if (TodoItems.Find(id) == null) {
                return NotFound();
            }
            item.Key = TodoItems.Find(id).Key;
            TodoItems.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id) {
            if (TodoItems.Find(id) == null) {
                return NotFound();
            }
            TodoItems.Remove(id);
            return new NoContentResult();
        }

    }
}
