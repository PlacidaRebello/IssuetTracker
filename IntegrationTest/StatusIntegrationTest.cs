using IssueTracker;
using Newtonsoft.Json;
using ServiceModel.Dto;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest
{
    public class StatusIntegrationTest : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;

        public StatusIntegrationTest(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            Task.Run(() => this.SignIn_WhenCalled_ReturnsJWT()).Wait();
        }

        [Fact]
        public async Task Index_WhenCalled_ReturnsApplicationForm()
        {
            var response = await _client.GetAsync("/WeatherForecast");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("Cool", responseString);
        }

        [Fact]
        internal async Task SignIn_WhenCalled_ReturnsJWT()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/SignIn");
            var req = new CreateUserRequest
            {
                Username = "testUser",
                Password = "test123User!"
            };
            
            postRequest.Content = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Bearer", responseString);

            var bearerIndex = responseString.IndexOf("Bearer");
            var expirationIndex = responseString.IndexOf("expiration") - 13;
            AuthHelper.BearerToken = responseString.Substring(bearerIndex, expirationIndex);
        }

        [Fact]
        public async Task Status_WhenCalled_ReturnsCorrectStatus()
        {
            var getRequest = new HttpRequestMessage(HttpMethod.Get, "/api/Status/1");
            _client.DefaultRequestHeaders.Add("Authorization", AuthHelper.BearerToken);

            var response = await _client.SendAsync(getRequest);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("TODO", responseString);
        }
    }
}
