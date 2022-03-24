using System.Text.Json;

namespace WebAppsConsumeApi.CRUD.Helpers
{
    public class RestClientConfig<TSources> : IDisposable where TSources : class
    {
        private HttpClient _httpClient;
        private string _baseAddress;
        private string _addressSufix;
        private bool dispose = false;

        public HttpResponseMessage ResponseMessage { get; set; }
        public HttpRequestMessage RequestMessage { get; set; }

        public RestClientConfig(string baseAddress, string addressSufix)
        {
            _baseAddress = baseAddress;
            _addressSufix = addressSufix;
            _httpClient = new HttpClient();
        }

        public RestClientConfig() { }

        public TSources GetAll()
        {
            try
            {
                RequestMessage = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"{_baseAddress}{_addressSufix}")
                };

                ResponseMessage = _httpClient.SendAsync(RequestMessage).Result;

                string resContent = ResponseMessage.Content.ReadAsStringAsync().Result;
                TSources res = JsonSerializer.Deserialize<TSources>(resContent);

                return res;
            }
            catch (HttpRequestException hte)
            {
                throw new HttpRequestException(hte.Message);
            }
        }

        public async Task<TSources> GetAllAsync()
        {
            try
            {
                RequestMessage = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"{_baseAddress}{_addressSufix}")
                };

                ResponseMessage = await _httpClient.SendAsync(RequestMessage);

                string resContent = await ResponseMessage.Content.ReadAsStringAsync();
                TSources res = JsonSerializer.Deserialize<TSources>(resContent);

                return res;
            }
            catch (HttpRequestException hte)
            {
                throw new HttpRequestException(hte.Message);
            }
        }

        public TSources GetSingle(dynamic param = null)
        {
            try
            {
                RequestMessage = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"{_baseAddress}{_addressSufix}/{param}")
                };
                ResponseMessage = _httpClient.SendAsync(RequestMessage).Result;

                string resContent = ResponseMessage.Content.ReadAsStringAsync().Result;
                TSources res = JsonSerializer.Deserialize<TSources>(resContent);

                return res;
            }
            catch (HttpRequestException hte)
            {
                throw new HttpRequestException(hte.Message);
            }
        }

        public async Task<TSources> GetSingleAsync(dynamic param = null)
        {
            try
            {
                RequestMessage = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"{_baseAddress}{_addressSufix}/{param}")
                };
                ResponseMessage = await _httpClient.SendAsync(RequestMessage);

                string resContent = await ResponseMessage.Content.ReadAsStringAsync();
                TSources res = JsonSerializer.Deserialize<TSources>(resContent);

                return res;
            }
            catch (HttpRequestException hte)
            {
                throw new HttpRequestException(hte.Message);
            }
        }

        public TSources AddTSource(TSources sources)
        {
            try
            {
                RequestMessage = new HttpRequestMessage()
                {
                    Content = JsonContent.Create(sources),
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"{_baseAddress}{_addressSufix}")
                };
                ResponseMessage = _httpClient.SendAsync(RequestMessage).Result;

                if (ResponseMessage.IsSuccessStatusCode)
                {
                    string resContent = ResponseMessage.Content.ReadAsStringAsync().Result;
                    TSources res = JsonSerializer.Deserialize<TSources>(resContent);

                    return res;
                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException hte)
            {
                throw new HttpRequestException(hte.Message);
            }
        }

        public async Task<TSources> AddTSourceAsync(TSources sources)
        {
            try
            {
                RequestMessage = new HttpRequestMessage()
                {
                    Content = JsonContent.Create(sources),
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"{_baseAddress}{_addressSufix}")
                };
                ResponseMessage = await _httpClient.SendAsync(RequestMessage);

                if (ResponseMessage.IsSuccessStatusCode)
                {
                    string resContent = await ResponseMessage.Content.ReadAsStringAsync();
                    TSources res = JsonSerializer.Deserialize<TSources>(resContent);

                    return res;
                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException hte)
            {
                throw new HttpRequestException(hte.Message);
            }
        }

        public TSources UpdateTSource(int id, TSources sources)
        {
            try
            {
                RequestMessage = new HttpRequestMessage()
                {
                    Content = JsonContent.Create(sources),
                    Method = HttpMethod.Put,
                    RequestUri = new Uri($"{_baseAddress}{_addressSufix}/{id}")
                };
                ResponseMessage = _httpClient.SendAsync(RequestMessage).Result;

                if (ResponseMessage.IsSuccessStatusCode)
                {
                    string resContent = ResponseMessage.Content.ReadAsStringAsync().Result;
                    TSources res = JsonSerializer.Deserialize<TSources>(resContent);

                    return res;
                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException hte)
            {
                throw new HttpRequestException(hte.Message);
            }
        }

        public async Task<TSources> UpdateTSourceAsync(int id, TSources sources)
        {
            try
            {
                RequestMessage = new HttpRequestMessage()
                {
                    Content = JsonContent.Create(sources),
                    Method = HttpMethod.Put,
                    RequestUri = new Uri($"{_baseAddress}{_addressSufix}/{id}")
                };
                ResponseMessage = await _httpClient.SendAsync(RequestMessage);

                if (ResponseMessage.IsSuccessStatusCode)
                {
                    string resContent = await ResponseMessage.Content.ReadAsStringAsync();
                    TSources res = JsonSerializer.Deserialize<TSources>(resContent);

                    return res;
                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException hte)
            {
                throw new HttpRequestException(hte.Message);
            }
        }

        public TSources DeleteTSource(int id)
        {
            try
            {
                RequestMessage = new HttpRequestMessage()
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri($"{_baseAddress}{_addressSufix}/{id}")
                };
                ResponseMessage = _httpClient.SendAsync(RequestMessage).Result;

                if (ResponseMessage.IsSuccessStatusCode)
                {
                    string resContent = ResponseMessage.Content.ReadAsStringAsync().Result;
                    TSources res = JsonSerializer.Deserialize<TSources>(resContent);

                    return res;
                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException hte)
            {
                throw new HttpRequestException(hte.Message);
            }
        }

        public async Task<TSources> DeleteTSourceAsync(int id)
        {
            try
            {
                RequestMessage = new HttpRequestMessage()
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri($"{_baseAddress}{_addressSufix}/{id}")
                };
                ResponseMessage = await _httpClient.SendAsync(RequestMessage);

                if (ResponseMessage.IsSuccessStatusCode)
                {
                    string resContent = await ResponseMessage.Content.ReadAsStringAsync();
                    TSources res = JsonSerializer.Deserialize<TSources>(resContent);

                    return res;
                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException hte)
            {
                throw new HttpRequestException(hte.Message);
            }
        }

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
