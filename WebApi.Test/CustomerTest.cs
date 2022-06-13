using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Test
{
    [TestClass]
    public class CustomerTest
    {
        private HttpClient _client;
        public CustomerTest()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [TestMethod]
        public void GetAllCustomerTest()
        {
            var request = new HttpRequestMessage(new HttpMethod("GET"), "/Customer");
            var response = _client.SendAsync(request).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        [DataRow(1)]
        public void GetCustomerByIdTest(int id)
        {
            var request = new HttpRequestMessage(new HttpMethod("GET"), $"/Customer/{id}");
            var response = _client.SendAsync(request).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void PostCustomerTest()
        {
            var request = new HttpRequestMessage(new HttpMethod("POST"), "/Customer");
            var response = _client.SendAsync(request).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PutCustomerTest()
        {
            var request = new HttpRequestMessage(new HttpMethod("PUT"), "/Customer");
            var response = _client.SendAsync(request).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        [DataRow(1)]
        public void DeleteCustomerTest(int id)
        {
            var request = new HttpRequestMessage(new HttpMethod("DELETE"), $"/Customer/{id}");
            var response = _client.SendAsync(request).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
