using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using PaymentAdvisoryPortalParentAPI.Dtos;
using PaymentAdvisoryPortalParentAPI.Dtos.BillDtos;

namespace PaymentAdvisoryPortalParentAPI.Utility
{
    class APIRequest
    {
        private readonly HttpClient _httpClient;
        public APIRequest(IConfiguration config)
        {
            _httpClient = new HttpClient();
        }

        public async Task<ApiResponse> CallGetEndpoint(string url, object payload=null)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync(url, payload);

            var responseContent = await httpResponse.Content.ReadAsStringAsync();
            var response = new ApiResponse
            {
                StatusCode = (int)httpResponse.StatusCode,
                IsSuccess = httpResponse.IsSuccessStatusCode,
                Message = httpResponse.IsSuccessStatusCode ? "Success" : responseContent,
                Data = httpResponse.IsSuccessStatusCode ? responseContent : null
            };

            return response;
        }
        public async Task<ApiResponse> CallPostEndpoint(string url, object payload)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync(url, payload);

            var responseContent = await httpResponse.Content.ReadAsStringAsync();
            var response = new ApiResponse
            {
                StatusCode = (int)httpResponse.StatusCode,
                IsSuccess = httpResponse.IsSuccessStatusCode,
                Message = httpResponse.IsSuccessStatusCode ? "Success" : responseContent,
                Data = httpResponse.IsSuccessStatusCode ? responseContent : null
            };

            return response;
        }

        public async Task<ApiResponse> CallGetEndpointWithToken(string url, IDictionary<string, string> headers, object payload=null)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // Add headers to the request
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url)
            {
                Content = content
            };

            foreach (var header in headers)
            {
                requestMessage.Headers.Add(header.Key, header.Value);
            }

            var httpResponse = await _httpClient.SendAsync(requestMessage);

            var responseContent = await httpResponse.Content.ReadAsStringAsync();
            var responseWrapper = new ApiResponse
            {
                StatusCode = (int)httpResponse.StatusCode,
                IsSuccess = httpResponse.IsSuccessStatusCode,
                Message = httpResponse.IsSuccessStatusCode ? "Success" : responseContent,
                Data = httpResponse.IsSuccessStatusCode ? responseContent : null
            };

            if (httpResponse.IsSuccessStatusCode)
            {
                if (bool.TryParse(responseContent, out bool result))
                {
                    responseWrapper.Data = result;
                }
                else
                {
                    responseWrapper.Data = responseContent;
                }
            }
            if (!httpResponse.IsSuccessStatusCode)
            {
                responseWrapper.Message = responseContent;
            }

            return responseWrapper;
        }

        public async Task<ApiResponse> CallGetEndpointWithTokenAndJsonResult<T>(string url, IDictionary<string, string> headers)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            foreach (var header in headers)
            {
                requestMessage.Headers.Add(header.Key, header.Value);
            }

            var httpResponse = await _httpClient.SendAsync(requestMessage);
            var responseContent = await httpResponse.Content.ReadAsStringAsync();

            var responseWrapper = new ApiResponse
            {
                StatusCode = (int)httpResponse.StatusCode,
                IsSuccess = httpResponse.IsSuccessStatusCode,
                Message = httpResponse.IsSuccessStatusCode ? "Success" : responseContent,
                Data = httpResponse.IsSuccessStatusCode ? responseContent : null
            };

            if (httpResponse.IsSuccessStatusCode)
            {
                // Deserialize the response content to a JSON object
                try
                {
                    var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseContent);
                    responseWrapper.Data = jsonObject;
                }
                catch (Exception)
                {
                    responseWrapper.Data = responseContent;
                }
            }
            else
            {
                responseWrapper.Message = responseContent;
            }

            return responseWrapper;
        }


        public async Task<ApiResponse> CallGetEndpointWithTokenAndResult<T>(string url, IDictionary<string, string> headers, object payload=null)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // Add headers to the request
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url)
            {
                Content = content
            };

            foreach (var header in headers)
            {
                requestMessage.Headers.Add(header.Key, header.Value);
            }

            var httpResponse = await _httpClient.SendAsync(requestMessage);

            var responseContent = await httpResponse.Content.ReadAsStringAsync();
            var responseWrapper = new ApiResponse
            {
                StatusCode = (int)httpResponse.StatusCode,
                IsSuccess = httpResponse.IsSuccessStatusCode,
                Message = httpResponse.IsSuccessStatusCode ? "Success" : responseContent,
                Data = httpResponse.IsSuccessStatusCode ? responseContent : null
            };

            if (!httpResponse.IsSuccessStatusCode)
            {
                responseWrapper.Message = responseContent;
            }

            if (httpResponse.IsSuccessStatusCode)
            {
                responseWrapper.Data = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<T>>(responseContent);
            }

            return responseWrapper;
        }

        public async Task<ApiResponse> CallPostEndpointWithToken(string url, object payload, IDictionary<string, string> headers)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // Add headers to the request
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = content
            };

            foreach (var header in headers)
            {
                requestMessage.Headers.Add(header.Key, header.Value);
            }

            var httpResponse = await _httpClient.SendAsync(requestMessage);

            var responseContent = await httpResponse.Content.ReadAsStringAsync();
            var responseWrapper = new ApiResponse
            {
                StatusCode = (int)httpResponse.StatusCode,
                IsSuccess = httpResponse.IsSuccessStatusCode,
                Message = httpResponse.IsSuccessStatusCode ? "Success" : responseContent,
                Data = httpResponse.IsSuccessStatusCode ? responseContent : null
            };

            if (!httpResponse.IsSuccessStatusCode)
            {
                responseWrapper.Message = responseContent;
            }

            return responseWrapper;
        }
        public async Task<ApiResponse> CallPostEndpointWithTokenAndResult<T>(string url, object payload, IDictionary<string, string> headers)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // Add headers to the request
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = content
            };

            foreach (var header in headers)
            {
                requestMessage.Headers.Add(header.Key, header.Value);
            }

            var httpResponse = await _httpClient.SendAsync(requestMessage);

            var responseContent = await httpResponse.Content.ReadAsStringAsync();
            var responseWrapper = new ApiResponse
            {
                StatusCode = (int)httpResponse.StatusCode,
                IsSuccess = httpResponse.IsSuccessStatusCode,
                Message = httpResponse.IsSuccessStatusCode ? "Success" : responseContent,
                Data = httpResponse.IsSuccessStatusCode ? responseContent : null
            };

            if (!httpResponse.IsSuccessStatusCode)
            {
                responseWrapper.Message = responseContent;
            }

            if (httpResponse.IsSuccessStatusCode)
            {
                responseWrapper.Data = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<T>>(responseContent);
            }

            return responseWrapper;
        }

        public async Task<ApiResponse> CallPutEndpointWithToken(string url, object payload, IDictionary<string, string> headers)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // Add headers to the request
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, url)
            {
                Content = content
            };

            foreach (var header in headers)
            {
                requestMessage.Headers.Add(header.Key, header.Value);
            }

            var httpResponse = await _httpClient.SendAsync(requestMessage);

            var responseContent = await httpResponse.Content.ReadAsStringAsync();
            var responseWrapper = new ApiResponse
            {
                StatusCode = (int)httpResponse.StatusCode,
                IsSuccess = httpResponse.IsSuccessStatusCode,
                Message = httpResponse.IsSuccessStatusCode ? "Success" : responseContent,
                Data = httpResponse.IsSuccessStatusCode ? responseContent : null
            };

            if (!httpResponse.IsSuccessStatusCode)
            {
                responseWrapper.Message = responseContent;
            }

            return responseWrapper;
        }

        public async Task<ApiResponse> CallDeleteEndpointWithToken(string url, IDictionary<string, string> headers)
        {
            // Add headers to the request
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, url);

            foreach (var header in headers)
            {
                requestMessage.Headers.Add(header.Key, header.Value);
            }

            var httpResponse = await _httpClient.SendAsync(requestMessage);

            var responseContent = await httpResponse.Content.ReadAsStringAsync();
            var responseWrapper = new ApiResponse
            {
                StatusCode = (int)httpResponse.StatusCode,
                IsSuccess = httpResponse.IsSuccessStatusCode,
                Message = httpResponse.IsSuccessStatusCode ? "Success" : responseContent,
                Data = httpResponse.IsSuccessStatusCode ? responseContent : null
            };

            if (!httpResponse.IsSuccessStatusCode)
            {
                responseWrapper.Message = responseContent;
            }

            return responseWrapper;
        }

        public async Task<ApiResponse> CallPostEndpointWithFiles<T>(string url, FilesToUpload request, IDictionary<string, string> headers)
        {
            using (var multipartFormData = new MultipartFormDataContent())
            {
                // Add files to the request
                foreach (var file in request.Files)
                {
                    var fileContent = new StreamContent(file.OpenReadStream());
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                    multipartFormData.Add(fileContent, "Files", file.FileName);
                }

                multipartFormData.Add(new StringContent(request.BillID.ToString()), "BillID");
                multipartFormData.Add(new StringContent(request.Type.ToString()), "Type");

                // Create the HTTP request message
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = multipartFormData
                };

                // Add headers to the request
                foreach (var header in headers)
                {
                    requestMessage.Headers.Add(header.Key, header.Value);
                }

                // Send the request and handle the response
                var httpResponse = await _httpClient.SendAsync(requestMessage);

                var responseContent = await httpResponse.Content.ReadAsStringAsync();
                var responseWrapper = new ApiResponse
                {
                    StatusCode = (int)httpResponse.StatusCode,
                    IsSuccess = httpResponse.IsSuccessStatusCode,
                    Message = httpResponse.IsSuccessStatusCode ? "Success" : responseContent,
                    Data = httpResponse.IsSuccessStatusCode ? responseContent : null
                };

                if (!httpResponse.IsSuccessStatusCode)
                {
                    responseWrapper.Message = responseContent;
                }

                if (httpResponse.IsSuccessStatusCode)
                {
                    responseWrapper.Data = responseContent;
                }

                return responseWrapper;
            }
        }
    }
}