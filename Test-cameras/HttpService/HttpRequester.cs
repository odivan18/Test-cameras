using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;

namespace Test_cameras
{
    class HttpRequester
    {
        public async Task<HttpResponseMessage> ReponseByAuth(HttpAuthData authData, CancellationToken cancelTokenHoler)
        {
            if (authData == null)
            {
                throw new Exception("Данные аутентификации не существуют");
            }

            HttpClient client = HttpClientConstructor(authData);
            HttpResponseMessage response = await client.GetAsync(authData.address, cancelTokenHoler);
            client.Dispose();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"При подключении произошла ошибка {response.StatusCode}");
            }

            return response;
        }

        private HttpClient HttpClientConstructor(HttpAuthData authData)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(authData.address);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(authData.GetAuthToken()));

            return client;
        }
    }
}
