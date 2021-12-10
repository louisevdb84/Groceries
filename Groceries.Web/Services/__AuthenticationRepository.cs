using Groceries.Web.Models;
using Groceries.Web.Static;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Groceries.Web.Services
{
    public class jlkjlkjAuthenticationRepository
    {
     
       private readonly IHttpClientFactory _client;

        public jlkjlkjAuthenticationRepository(IHttpClientFactory httpClient)
        {
            _client = httpClient;
        }

        public async Task<bool> Register(RegistrationModel user)
        {
            var request = new HttpRequestMessage(HttpMethod.Post
                , Endpoints.RegisterEndpoint);
            request.Content = new StringContent(JsonConvert.SerializeObject(user)
                , Encoding.UTF8, "application/json");

            var client = _client.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            return response.IsSuccessStatusCode;
        }

    }
}
