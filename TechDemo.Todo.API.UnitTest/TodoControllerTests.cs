using TechDemo.Todo.API.Services;
using TechDemo.Todo.API.ViewModels;
using Xunit;
using System.Threading.Tasks;

namespace TechDemo.Todo.API.UnitTest
{
    public class TodoControllerTests
    {
        [Fact]
        public async Task TestGetAllTodoItemsAsync()
        {
            // Arrange
            var dbContext = DbContextMocker.GetTodoDbContext();
            var todoService = new TodoService(dbContext);

            // Act
            var items = todoService.GetAllTodoItems();

            dbContext.Dispose();

            // Assert
            Assert.Single(items);
        }

        [Fact]
        public async Task TestGetTodoItemAsync()
        {
            // Arrange
            var dbContext = DbContextMocker.GetTodoDbContext();
            var todoService = new TodoService(dbContext);

            // Act
            var item = todoService.GetTodoItemById(1);

            dbContext.Dispose();

            // Assert
            Assert.Equal(1, item.Id);
        }


        [Fact]
        public async Task TestUpdateTodoItemAsync()
        {
            // Arrange
            var dbContext = DbContextMocker.GetTodoDbContext();
            var todoService = new TodoService(dbContext);

            var request = new TodoItemViewModel
            {
                Id = 1,
                Title = "unit test title",
                Description = "unit test description",
                Latitude = -121.23126,
                Longitude = 42.6235675
            };

            // Act
            var result = todoService.UpdateTodoItem(request);

            dbContext.Dispose();

            // Assert
            Assert.Equal(1, result);
        }
    }
}
