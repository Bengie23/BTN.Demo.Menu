using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BTN.Demo.Menu.IntegrationTests
{
    public static class HttpClientExtensions
    {
        public static void AssertSuccessfulResponse(this HttpResponseMessage response)
        {
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        public static async Task<T> AssertSuccessfulResponse<T>(this HttpResponseMessage response)
        {
            T data = default;
            response.AssertSuccessfulResponse();

            try
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (Exception ex)
            {
                Assert.Fail("Something went wrong while trying to deserialize api response");
            }

            return data;
        }
    }
}
