using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ComPDFKit.constant;
using ComPDFKit.exception;
using ComPDFKit.param;
using ComPDFKit.pojo.comPdfKit;
using ComPDFKit.utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ComPDFKit.client
{
    /// <summary>
    /// For http request to ComPDFKit server
    /// </summary>
    public class CPDFHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _address;
        private long _expireTime;
        private static string _accessToken;
        private readonly string _publicKey;
        private readonly string _secretKey;

        /// <summary>
        /// ComPDFKit Client
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="publicKey"></param>
        /// <param name="secretKey"></param>
        public CPDFHttpClient(HttpClient httpClient, string publicKey, string secretKey)
        {
            _address = "https://api-server.compdf.com/server/";
            _httpClient = httpClient;
            _publicKey = publicKey;
            _secretKey = secretKey;
            RefreshAccessToken();
        }
        
        /// <summary>
        /// Send request
        /// </summary>
        /// <param name="method"></param>
        /// <param name="url"></param>
        /// <returns>The response of the request</returns>
        private async Task<HttpResponseMessage> SendRequestAsync(HttpMethod method, string url)
        {
            HttpRequestMessage request = new HttpRequestMessage(method, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", GetAccessToken());
            return await _httpClient.SendAsync(request);
        }

        /// <summary>
        /// Get access token
        /// </summary>
        /// <returns>The access token</returns>
        private string GetAccessToken()
        {
            if (_expireTime == 0 || DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond > _expireTime)
            {
                RefreshAccessToken();
            }
            return _accessToken;
        }

        /// <summary>
        /// Set access token
        /// </summary>
        /// <param name="token"></param>
        /// <param name="expiresIn"></param>
        private void SetAccessToken(string token, long expiresIn)
        {
            _accessToken = token;
            _expireTime = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond + expiresIn * 1000L;
        }

        /// <summary>
        /// Refresh and set access token
        /// </summary>
        internal void RefreshAccessToken()
        {
            var newToken = GetComPdfKitAuth(_publicKey, _secretKey);
            SetAccessToken(newToken.AccessToken, long.Parse(newToken.ExpiresIn));
        }

        /// <summary>
        /// Get token
        /// </summary>
        /// <param name="publicKey"></param>
        /// <param name="secretKey"></param>
        /// <returns>The token</returns>
        /// <exception cref="CPDFException"></exception>
        internal CPDFOauthResult GetComPdfKitAuth(string publicKey, string secretKey)
        {
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            var tokenParam = new Dictionary<string, string>
            {
                ["publicKey"] = publicKey,
                ["secretKey"] = secretKey
            };

            var responseEntity = _httpClient.PostAsync(_address + CPDFConstant.API_V1_OAUTH_TOKEN, new StringContent(JsonConvert.SerializeObject(tokenParam), Encoding.UTF8, "application/json")).Result;

            if (!responseEntity.IsSuccessStatusCode)
            {
                throw new CPDFException(CPDFConstant.EXCEPTION_MSG_GET_TOKEN_FAIL);
            }

            var responseBody = responseEntity.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<CPDFResult<CPDFOauthResult>>(responseBody);

            if (result.Code != CPDFConstant.SUCCESS_CODE)
            {
                throw new CPDFException(result.Code, result.Msg);
            }

            return result.Data;
        }

        /// <summary>
        /// Get tools
        /// </summary>
        /// <returns>The tools list</returns>
        /// <exception cref="CPDFException"></exception>
        public async Task<List<CPDFTool>> GetToolsAsync()
        {
            string url = _address + CPDFConstant.API_V1_TOOL_SUPPORT;
            HttpResponseMessage response;
            try
            {
                response = await SendRequestAsync(HttpMethod.Get, url);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw new CPDFException(CPDFConstant.EXCEPTION_MSG_QUERY_TOOLS_FAIL + e.Message);
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            CPDFResult<List<CPDFTool>> result = JsonConvert.DeserializeObject<CPDFResult<List<CPDFTool>>>(responseBody);
            if (result == null || result.Code != CPDFConstant.SUCCESS_CODE)
            {
                throw new CPDFException(result?.Code, result?.Msg);
            }

            return result.Data;
        }

        /// <summary>
        /// Get file info
        /// </summary>
        /// <param name="fileKey"></param>
        /// <param name="language">1: English, 2: Chinese</param>
        /// <returns>File info</returns>
        /// <exception cref="CPDFException"></exception>
        public async Task<CPDFFileInfo> GetFileInfoAsync(string fileKey, int language)
        {
            string url = $"{_address}{CPDFConstant.API_V1_FILE_INFO}?fileKey={fileKey}&language={language}";
            HttpResponseMessage response;
            try
            {
                response = await SendRequestAsync(HttpMethod.Get, url);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw new CPDFException($"{CPDFConstant.EXCEPTION_MSG_QUERY_FILE_INFO_FAIL}{e.Message}");
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            CPDFResult<CPDFFileInfo> result = JsonConvert.DeserializeObject<CPDFResult<CPDFFileInfo>>(responseBody);
            if (result == null || result.Code != CPDFConstant.SUCCESS_CODE)
            {
                throw new CPDFException(result?.Code, result?.Msg);
            }

            return result.Data;
        }
        
        /// <summary>
        /// Get tenant asset info
        /// </summary>
        /// <returns>Tenant asset info</returns>
        /// <exception cref="CPDFException"></exception>
        public async Task<CPDFTenanAssetResult> GetAssetInfoAsync()
        {
            string url = $"{_address}{CPDFConstant.API_V1_ASSET_INFO}";
            HttpResponseMessage response;
            try
            {
                response = await SendRequestAsync(HttpMethod.Get, url);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw new CPDFException($"{CPDFConstant.EXCEPTION_MSG_QUERY_TENANT_ASSET_FAIL}{e.Message}");
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            CPDFResult<CPDFTenanAssetResult> result = JsonConvert.DeserializeObject<CPDFResult<CPDFTenanAssetResult>>(responseBody);
            if (result == null || result.Code != CPDFConstant.SUCCESS_CODE)
            {
                throw new CPDFException(result?.Code, result?.Msg);
            }

            return result.Data;
        }

        /// <summary>
        /// Get task list
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns>The task list</returns>
        /// <exception cref="CPDFException"></exception>
        public async Task<CPDFTaskRecordsResult> GetTaskListAsync(string page, string size)
        {
            if (string.IsNullOrEmpty(page))
            {
                page = "1";
            }
            if (string.IsNullOrEmpty(size))
            {
                size = "5";
            }
            string url = $"{_address}{CPDFConstant.API_V1_TASK_LIST}?page={page}&size={size}";

            try
            {
                HttpResponseMessage httpResponse = await _httpClient.GetAsync(url);
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new CPDFException($"{CPDFConstant.EXCEPTION_MSG_QUERY_TASK_LIST_FAIL} - {httpResponse.ReasonPhrase}");
                }

                string responseContent = await httpResponse.Content.ReadAsStringAsync();
                CPDFResult<CPDFTaskRecordsResult> apiResponse = JsonConvert.DeserializeObject<CPDFResult<CPDFTaskRecordsResult>>(responseContent);

                if (apiResponse == null || apiResponse.Code != CPDFConstant.SUCCESS_CODE)
                {
                    throw new CPDFException(apiResponse?.Code ?? "Unknown", apiResponse?.Msg ?? "Unknown error");
                }

                return apiResponse.Data;
            }
            catch (Exception e)
            {
                throw new CPDFException($"{CPDFConstant.EXCEPTION_MSG_QUERY_TASK_LIST_FAIL} - {e.Message}");
            }
        }

        /// <summary>
        /// Create task
        /// </summary>
        /// <param name="executeTypeUrl"></param>
        /// <param name="language">1: English, 2: Chinese</param>
        /// <returns>Create task result</returns>
        /// <exception cref="CPDFException"></exception>
        public async Task<CPDFCreateTaskResult> CreateTaskAsync(string executeTypeUrl, int language)
        {
            string url = _address + CPDFConstant.API_V1_CREATE_TASK.Replace("{executeTypeUrl}", executeTypeUrl) + $"?language={language}";

            try
            {
                HttpResponseMessage response = await SendRequestAsync(HttpMethod.Get, url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                CPDFResult<CPDFCreateTaskResult> result = JsonConvert.DeserializeObject<CPDFResult<CPDFCreateTaskResult>>(responseBody);

                if (result == null || result.Code != CPDFConstant.SUCCESS_CODE)
                {
                    throw new CPDFException(result?.Code, result?.Msg);
                }

                return result.Data;
            }
            catch (Exception e)
            {
                throw new CPDFException(CPDFConstant.EXCEPTION_MSG_CREATE_TASK_FAIL + e.Message);
            }
        }

        /// <summary>
        /// Get upload file result
        /// </summary>
        /// <param name="file"></param>
        /// <param name="taskId"></param>
        /// <param name="password"></param>
        /// <param name="fileParameter"></param>
        /// <param name="language">1: English, 2: Chinese</param>
        /// <returns>The upload file result</returns>
        /// <exception cref="CPDFException"></exception>
        public CPDFUploadFileResult GetUploadFileResult(FileInfo file, string taskId, string password, CPDFFileParameter fileParameter, int language)
        {
            try
            {
                using (FileStream stream = new FileStream(file.FullName, FileMode.Open))
                {
                    return GetUploadFileResult(stream, taskId, password, fileParameter, file.Name, null, null, language);
                }
            }
            catch (FileNotFoundException e)
            {
                throw new CPDFException(e.Message, e);
            }
        }

        /// <summary>
        /// Get upload file result
        /// </summary>
        /// <param name="fileInputStream"></param>
        /// <param name="taskId"></param>
        /// <param name="password"></param>
        /// <param name="fileParameter"></param>
        /// <param name="fileName"></param>
        /// <param name="imageInputStream"></param>
        /// <param name="imageFileName"></param>
        /// <param name="language">1: English, 2: Chinese</param>
        /// <returns>The upload file result</returns>
        /// <exception cref="CPDFException"></exception>
        public CPDFUploadFileResult GetUploadFileResult(FileStream fileInputStream, string taskId, string password, CPDFFileParameter fileParameter, string fileName, FileStream imageInputStream, string imageFileName, int language)
        {
            string url = _address + CPDFConstant.API_V1_UPLOAD_FILE;
            MultipartFormDataContent content = new MultipartFormDataContent();
            content.Add(new StreamContent(fileInputStream), "file", fileName);
            content.Add(new StringContent(taskId), "taskId");
            if (language > 0)
            {
                content.Add(new StringContent(language.ToString()), "language");
            }
            
            if (!string.IsNullOrEmpty(password))
            {
                content.Add(new StringContent(password), "password");
            }
            if (fileParameter != null)
            {
                var settings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                string serializedData = JsonConvert.SerializeObject(fileParameter, settings);
                content.Add(new StringContent(serializedData), "parameter");
            }
            if (imageInputStream != null && !string.IsNullOrEmpty(imageFileName))
            {
                StreamContent imageContent = new StreamContent(imageInputStream);
                imageContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "image",
                    FileName = imageFileName
                };
                content.Add(imageContent, "image");
            }
            
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GetAccessToken());
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "multipart/form-data");
                HttpResponseMessage response;
                try
                {
                    response = client.PostAsync(url, content).Result;
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception e)
                {
                    throw new CPDFException(CPDFConstant.EXCEPTION_MSG_UPLOAD_FILE_FAIL + e.Message);
                }
                
                string responseBody = response.Content.ReadAsStringAsync().Result;
                CPDFResult<CPDFUploadFileResult> result = JsonConvert.DeserializeObject<CPDFResult<CPDFUploadFileResult>>(responseBody);
                if (result == null || result.Code != CPDFConstant.SUCCESS_CODE)
                {
                    throw new CPDFException(result?.Code, result?.Msg);
                }
                
                return result.Data;
            }
        }

        /// <summary>
        /// Execute task
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="language"></param>
        /// <returns>The execute task result</returns>
        /// <exception cref="CPDFException"></exception>
        public CPDFCreateTaskResult ExecuteTask(string taskId, int language)
        {
            string url = _address + CPDFConstant.API_V1_EXECUTE_TASK + "?taskId=" + taskId + "&language=" + language;
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + GetAccessToken());
            HttpResponseMessage response;

            try
            {
                response = _httpClient.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw new CPDFException(CPDFConstant.EXCEPTION_MSG_EXECUTE_TASK_FAIL + e.Message);
            }

            string responseBody = response.Content.ReadAsStringAsync().Result;
            CPDFResult<CPDFCreateTaskResult> result = JsonConvert.DeserializeObject<CPDFResult<CPDFCreateTaskResult>>(responseBody);
            if (result == null || result.Code != CPDFConstant.SUCCESS_CODE)
            {
                throw new CPDFException(result?.Code, result?.Msg);
            }
            
            return result.Data;
        }

        /// <summary>
        /// Get task info result
        /// </summary>
        /// <param name="taskId">The task id</param>
        /// <param name="language">1: English, 2: Chinese</param>
        /// <returns>The task info result</returns>
        /// <exception cref="CPDFException"></exception>
        public CPDFTaskInfoResult GetTaskInfo(string taskId, int language)
        {
            string url = _address + CPDFConstant.API_V1_TASK_INFO + "?taskId=" + taskId + "&language=" + language;
            HttpResponseMessage response;

            try
            {
                response = _httpClient.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw new CPDFException(CPDFConstant.EXCEPTION_MSG_TASK_INFO_FAIL + e.Message);
            }

            string responseBody = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<CPDFResult<CPDFTaskInfoResult>>(responseBody);
            if (result == null || result.Code != CPDFConstant.SUCCESS_CODE)
            {
                throw new CPDFException(result?.Code, result?.Msg);
            }

            return result.Data;
        }

    }
}
