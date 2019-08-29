using System.Collections.Generic;
using TechDemo.Todo.API.Entities;
using TechDemo.Todo.API.ViewModels;
using NetTopologySuite.Geometries;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace TechDemo.Todo.API.Services
{
    public class TodoService : ITodoService
    {
        private TodoDbContext _context;

        public TodoService(TodoDbContext context)
        {
            _context = context;
        }

        public List<TodoItemViewModel> GetAllTodoItems()
        {
            try
            {
                var items = _context.TodoItems.Select(i => new TodoItemViewModel
                {
                    Id = i.Id,
                    Title = i.Title,
                    Description = i.Description,
                    Latitude = i.Lat,
                    Longitude = i.Long
                }).ToList();

                return items;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public TodoItemViewModel GetTodoItemById(int id)
        {
            try
            {
                TodoItem item = _context.TodoItems.SingleOrDefault(i => i.Id == id);

                var itemVm = new TodoItemViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Latitude = item.Lat,
                    Longitude = item.Long
                };

                return itemVm;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int CreateTodoItem(TodoItemViewModel item)
        {
            try
            {
                var itemEntity = new TodoItem
                {
                    Title = item.Title,
                    Description = item.Description,
                    Lat = item.Latitude,
                    Long = item.Longitude
                    //Location = new Point(item.Latitude, item.Latitude) { SRID = 4326 }
                };

                _context.TodoItems.Add(itemEntity);
                _context.SaveChanges();

                return itemEntity.Id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int UpdateTodoItem(TodoItemViewModel item)
        {
            try
            {
                var itemEntity = new TodoItem
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Lat = item.Latitude,
                    Long = item.Longitude
                    //Location = new Point(item.Latitude, item.Latitude) { SRID = 4326 }
                };

                // add validation
                _context.Entry(itemEntity).State = EntityState.Modified;
                _context.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int DeleteTodoItem(int id)
        {
            try
            {
                TodoItem item = _context.TodoItems.Find(id);
                if (item == null)
                    return 0;

                _context.TodoItems.Remove(item);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
