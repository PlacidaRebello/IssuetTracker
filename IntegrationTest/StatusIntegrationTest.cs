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
        private static int StatusId;

        public StatusIntegrationTest(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            Task.Run(() => this.SignIn_WhenCalled_ReturnsJWT()).Wait();
        }
        
        protected internal async Task SignIn_WhenCalled_ReturnsJWT()
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

            var startIndex = responseString.IndexOf("token") + 8;
            var endIndex = responseString.IndexOf("expiration") - 13;
            var token = responseString.Substring(startIndex, endIndex);
            AuthHelper.BearerToken = "Bearer " + token;
        }
        
        [Fact]
        public async Task CreateStatus_WhenCalled_CreatesCorrectStatus()
        {
            //Arrange
            var getRequest = new HttpRequestMessage(HttpMethod.Post, "/api/Status");

            var req = GetStatus();

            getRequest.Content = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

            _client.DefaultRequestHeaders.Add("Authorization", AuthHelper.BearerToken);

            //Act
            var response = await _client.SendAsync(getRequest);

            //Assert
            response.EnsureSuccessStatusCode();
            
            var responseString = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<CreateResponse>(responseString);
            StatusId = resp.Id;

            Assert.Equal("Status Created Successfully", resp.Message);
        }

        [Fact]
        public async Task Status_WhenCalled_ReturnsCorrectStatus()
        {
            var getRequest = new HttpRequestMessage(HttpMethod.Get, $"/api/Status/{StatusId}");
            _client.DefaultRequestHeaders.Add("Authorization", AuthHelper.BearerToken);

            var response = await _client.SendAsync(getRequest);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("inmemory", responseString);
        }

        //Add a test method to edit status and check if name is updated
        
        [Fact]
        public async Task DeleteStatus_WhenCalled_DeletesCorrectStatus()
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/Status/{StatusId}");
            _client.DefaultRequestHeaders.Add("Authorization", AuthHelper.BearerToken);

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("Deleted Succesfully", responseString);
        }

        #region HelperMethods
        private CreateStatusRequest GetStatus()
        {
            return new CreateStatusRequest
            {
                StatusName = "inmemory",
                CreatedBy = "jason"
            };
        }
        #endregion

    }
}
