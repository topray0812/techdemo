using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TechDemo.Todo.API.Test
{
    public class MockedServiceClient
    {
        private readonly Func<HttpRequestMessage, HttpResponseMessage> _mockFunc;

        public MockedServiceClient(Func<HttpRequestMessage, HttpResponseMessage> mockFunc)
        {
            _mockFunc = mockFunc;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return _mockFunc(request);
        }
    }
}
