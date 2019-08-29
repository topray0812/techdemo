using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechDemo.Todo.API.Services;
using TechDemo.Todo.API.ViewModels;
using System;

namespace TechDemo.Todo.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        // GET api/todo
        [HttpGet]
        public ActionResult<List<TodoItemViewModel>> Get()
        {
            try
            {
                return _todoService.GetAllTodoItems();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message }); 
            }
        }

        // GET api/todo/5
        [HttpGet("{id}")]
        public ActionResult<TodoItemViewModel> Get(int id)
        {
            try
            {
                return _todoService.GetTodoItemById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST api/todo
        [HttpPost]
        public ActionResult Post([FromBody] TodoItemViewModel item)
        {
            try
            {
                var userId = _todoService.CreateTodoItem(item);
                return Ok(userId);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }   
        }

        // PUT api/todo
        [HttpPut]
        public ActionResult Put([FromBody] TodoItemViewModel item)
        {
            try
            {
                _todoService.UpdateTodoItem(item);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        // DELETE api/todo/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = _todoService.DeleteTodoItem(id);
                if (result == 0)
                    return BadRequest(new { message = $"Todo Item with id: {id} not exist." });

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
