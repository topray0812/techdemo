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

namespace TechDemo.Auth.API.Test
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
        public async Task LoginSuccess()
        {
            var request = new
            {
                Url = "/api/login",
                Body = new
                {
                    Username = "techdemo",
                    Password = "12345"
                }
            };

            var result = await _httpClient.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        public void Dispose()
        {
            _webAppFactory.Dispose();
        }
    }
}
