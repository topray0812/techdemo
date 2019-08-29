using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TechDemo.Todo.API.Test
{
    public class TechDemoAuthAPITests : IDisposable
    {
        private readonly WebAppFactory _webAppFactory;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        private readonly string _apiUsername;
        private readonly string _apiPassword;
        
        private Func<HttpRequestMessage, HttpResponseMessage> _mockFunc;

        public TechDemoAuthAPITests()
        {
            _webAppFactory = new WebAppFactory(collection =>
            {
                var client = new MockedServiceClient(message => _mockFunc(message));
                collection.AddSingleton(client);
            });

            _httpClient = _webAppFactory.CreateClient();

            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                                                       .Build();

            _apiUsername = _configuration.GetSection("AppSettings").GetValue<string>("apiUsername");
            _apiPassword = _configuration.GetSection("AppSettings").GetValue<string>("apiPassword");

            _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{_apiUsername}:{_apiPassword}")));
        }

        [Fact]
        public async Task GetAllTodoItemsSuccess()
        {
            var request = new
            {
                Url = "/api/todo"
            };

            var result = await _httpClient.GetAsync(request.Url);

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetTodoItemByIdSuccess()
        {
            var request = new
            {
                Url = "/api/todo/1"
            };

            var result = await _httpClient.GetAsync(request.Url);

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task CreateTodoItemSuccess()
        {
            var request = new
            {
                Url = "/api/todo",
                Body = new
                {
                    Id = 4,
                    Title = "New Title",
                    Description = "New Description",
                    Latitude = -121.23126,
                    Longitude = 42.6235675
                }
            };

            var result = await _httpClient.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task UpdateTodoItemSuccess()
        {
            var request = new
            {
                Url = "/api/todo",
                Body = new
                {
                    Id = 4,
                    Title = "Updated Title",
                    Description = "Updated Description",
                    Latitude = -121.23456,
                    Longitude = 42.6234567
                }
            };

            var result = await _httpClient.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task DeleteTodoItemSuccess()
        {
            var request = new
            {
                Url = "/api/todo/4"
            };

            var result = await _httpClient.DeleteAsync(request.Url);

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }


        public void Dispose()
        {
            _webAppFactory.Dispose();
        }
    }
}
