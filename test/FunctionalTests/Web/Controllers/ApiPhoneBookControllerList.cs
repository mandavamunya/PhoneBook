using Core.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web;
using Xunit;

namespace FunctionalTests.Web.Controllers
{
    public class ApiPhoneBookControllerList : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        public ApiPhoneBookControllerList(CustomWebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task ReturnsAllPhoneBooks()
        {
            var response = await Client.GetAsync("/api/PhoneBook");
            string jsonResult = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<List<PhoneBook>>(stringResponse);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task ReturnsEmptyJson()
        {
            var response = await Client.GetAsync("/api/PhoneBook/0");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            Assert.Equal("[]", stringResponse);
        }

        [Fact]
        public async Task ReturnsBlogById()
        {
            var response = await Client.GetAsync("/api/PhoneBook/1");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<List<PhoneBook>>(stringResponse);
            Assert.Single(model);
        }
    }
}
