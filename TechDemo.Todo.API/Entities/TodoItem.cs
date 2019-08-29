using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechDemo.Todo.API.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }

        //[Column(TypeName = "geometry")]
        //public Point Location { get; set; }
    }
}
