using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechDemo.Todo.API.ViewModels
{
    public class TodoItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
