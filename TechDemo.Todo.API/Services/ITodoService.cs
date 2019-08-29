using System;
using System.Collections.Generic;
using TechDemo.Todo.API.Entities;
using TechDemo.Todo.API.ViewModels;

namespace TechDemo.Todo.API.Services
{
    public interface ITodoService
    {
        List<TodoItemViewModel> GetAllTodoItems();

        TodoItemViewModel GetTodoItemById(int id);

        int CreateTodoItem(TodoItemViewModel item);

        int UpdateTodoItem(TodoItemViewModel item);

        int DeleteTodoItem(int id);
    }
}
