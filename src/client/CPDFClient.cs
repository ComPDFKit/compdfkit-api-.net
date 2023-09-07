using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using ComPDFKit.enums;
using ComPDFKit.param;
using ComPDFKit.pojo.comPdfKit;
using ComPDFKit.constant;

namespace ComPDFKit.client
{
    /// <summary>
    /// For execution ComPDFKit API
    /// </summary>
    public class CPDFClient
    {
        /// <summary>
        /// httpClient
        /// </summary>
        private readonly CPDFHttpClient _httpClient;

        /// <summary>
        /// ComPDFKit Client
        /// </summary>
        /// <param name="publicKey">your publicKey</param>
        /// <param name="secretKey">your secretKey</param>
        public CPDFClient(string publicKey, string secretKey)
        {
            var restClient = new HttpClient();
            restClient.Timeout = TimeSpan.FromSeconds(60 * 5);
            _httpClient = new CPDFHttpClient(restClient, publicKey, secretKey);
            _httpClient.RefreshAccessToken();
        }

        /// <summary>
        /// ComPDFKit Client
        /// </summary>
        /// <param name="publicKey">your publicKey</param>
        /// <param name="secretKey">your secretKey</param>
        /// <param name="readTimeout">readTimeout Seconds</param>
        /// <param name="connectTimeout">connectTimeout Seconds</param>
        public CPDFClient(string publicKey, string secretKey, long readTimeout, long connectTimeout)
        {
            var restClient = new HttpClient();
            restClient.Timeout = TimeSpan.FromSeconds(readTimeout);
            _httpClient = new CPDFHttpClient(restClient, publicKey, secretKey);
            _httpClient.RefreshAccessToken();
        }

        /// <summary>
        /// get token
        /// </summary>
        /// <param name="publicKey">publicKey</param>
        /// <param name="secretKey">secretKey</param>
        /// <returns></returns>
        private CPDFOauthResult GetComPdfKitAuth(string publicKey, string secretKey)
        {
            return _httpClient.GetComPdfKitAuth(publicKey, secretKey);
        }

        /// <summary>
        /// Get support tools
        /// </summary>
        /// <returns>CPDFTool</returns>
        public List<CPDFTool> GetTools()
        {
            return _httpClient.GetToolsAsync().Result;
        }
        
        /// <summary>
        /// Get file info
        /// </summary>
        /// <param name="fileKey">fileKey</param>
        /// <param name="language">1:English, 2:Chinese</param>
        /// <returns>CPDFFileInfo</returns>
        public CPDFFileInfo GetFileInfo(string fileKey, int language = 0)
        {
            return _httpClient.GetFileInfoAsync(fileKey, language).Result;
        }

        /// <summary>
        /// Get asset info
        /// </summary>
        /// <returns>CPDFTenantAssetResult</returns>
        public CPDFTenanAssetResult GetAssetInfo()
        {
            return _httpClient.GetAssetInfoAsync().Result;
        }

        /// <summary>
        /// Get task list
        /// </summary>
        /// <param name="page">page</param>
        /// <param name="size">size</param>
        /// <returns>CPDFTaskRecordsResult</returns>
        public CPDFTaskRecordsResult GetTaskList(string page, string size)
        {
            return _httpClient.GetTaskListAsync(page, size).Result;
        }

        /// <summary>
        /// Create task
        /// </summary>
        /// <param name="executeTypeUrl"> task execution type</param>
        /// <param name="language">1:English, 2:Chinese</param>
        /// <returns>CPDFCreateTaskResult</returns>
        public CPDFCreateTaskResult CreateTask(string executeTypeUrl, int language = 0)
        {
            return _httpClient.CreateTaskAsync(executeTypeUrl,language).Result;
        }
        
        /// <summary>
        /// Create task
        /// </summary>
        /// <param name="conversionEnum">task execution type</param>
        /// <param name="language">1:English, 2:Chinese</param>
        /// <returns>CPDFCreateTaskResult</returns>
        public CPDFCreateTaskResult CreateTask(CPDFConversionEnum conversionEnum, int language = 0)
        {
            return CreateTask(CPDFConversionEnumExtensions.GetValue(conversionEnum), language);
        }

        /// <summary>
        /// Create task
        /// </summary>
        /// <param name="documentEditorEnum">task execution type</param>
        /// <param name="language">1:English, 2:Chinese</param>
        /// <returns >CPDFCreateTaskResult</returns>
        public CPDFCreateTaskResult CreateTask(CPDFDocumentEditorEnum documentEditorEnum, int language = 0) {
            return CreateTask(CPDFDocumentEditorEnumExtensions.GetValue(documentEditorEnum), language);
        }

        /// <summary>
        /// Create task
        /// </summary>
        /// <param name="documentAIEnum">task execution type</param>
        /// <param name="language">1:English, 2:Chinese</param>
        /// <returns>CPDFCreateTaskResult</returns>
        public CPDFCreateTaskResult CreateTask(CPDFDocumentAIEnum documentAIEnum, int language = 0) {
            return CreateTask(CPDFDocumentAIEnumExtensions.GetValue(documentAIEnum), language);
        }

        /// <summary>
        /// Uploads a file.
        /// </summary>
        /// <param name="file">The FileInfo object.</param>
        /// <param name="taskId">The task ID.</param>
        /// <param name="password">The password</param>
        /// <param name="language">1:English, 2:Chinese</param>
        /// <returns>CPDFUploadFileResult</returns>
        public CPDFUploadFileResult UploadFile(FileInfo file, string taskId, string password = "", int language = 0)
        {
            return _httpClient.GetUploadFileResult(file, taskId, password,null, language);
        }

        /// <summary>
        /// Uploads a file.
        /// </summary>
        /// <param name="file">The FileInfo object.</param>
        /// <param name="taskId">The task ID.</param>
        /// <param name="parameter">The parameter</param>
        /// <param name="password">The password</param>
        /// <param name="language">1:English, 2:Chinese</param>
        /// <returns></returns>
        public CPDFUploadFileResult UploadFile(FileInfo file, string taskId,CPDFFileParameter parameter, string password = "", int language = 0)
        {
            return _httpClient.GetUploadFileResult(file, taskId, password, parameter, language);
        }
        
        /// <summary>
        /// Uploads a file.
        /// </summary>
        /// <param name="file">The FileInfo object.</param>
        /// <param name="taskId">The task ID.</param>
        /// <param name="fileParameter">The file parameter.</param>
        /// <param name="imageFile">The FileInfo object of the image file to attach.</param>
        /// <param name="password">The password</param>
        /// <param name="language">1:English, 2:Chinese</param>
        /// <returns>CPDFUploadFileResult</returns>
        public CPDFUploadFileResult UploadFile(FileInfo file, FileInfo imageFile, string taskId, CPDFFileParameter fileParameter,  string password = "", int language = 0)
        {
            using (FileStream fileStream = file.OpenRead())
            using (FileStream imageFileStream = imageFile.OpenRead())
            {
                return _httpClient.GetUploadFileResult(fileStream, taskId, password, fileParameter, file.Name, imageFileStream, imageFile.Name, language);
            }
        }

        /// <summary>
        /// Uploads a file.
        /// </summary>
        /// <param name="filePath">The path of the file to upload.</param>
        /// <param name="taskId">The task ID.</param>
        /// <param name="password">The password</param>
        /// <param name="language">1:English, 2:Chinese</param>
        /// <returns>CPDFUploadFileResult.</returns>
        public CPDFUploadFileResult UploadFile(string filePath, string taskId, string password = "", int language = 0)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                return _httpClient.GetUploadFileResult(fileStream, taskId, password, null, Path.GetFileName(filePath), null, null, language);
            }
        }
        
        /// <summary>
        /// Uploads a file.
        /// </summary>
        /// <param name="filePath">The path of the file to upload.</param>
        /// <param name="taskId">The task ID.</param>
        /// <param name="fileParameter">The file parameter.</param>
        /// <param name="password">The password</param>
        /// <param name="language">1:English, 2:Chinese</param>
        /// <returns>CPDFUploadFileResult.</returns>
        public CPDFUploadFileResult UploadFile(string filePath, string taskId, CPDFFileParameter fileParameter, string password = "", int language = 0)
        {
            var fileStream = new FileStream(filePath, FileMode.Open);
            return _httpClient.GetUploadFileResult(fileStream, taskId, password, fileParameter, Path.GetFileName(filePath), null, null, language);
        }

        /// <summary>
        /// Uploads a file.
        /// </summary>
        /// <param name="filePath">The path of the file to upload.</param>
        /// <param name="taskId">The task ID.</param>
        /// <param name="fileParameter">The file parameter.</param>
        /// <param name="imageFilePath">The path of the image file to attach.</param>
        /// <param name="password">The password</param>
        /// <param name="language">1:English, 2:Chinese</param>
        /// <returns>CPDFUploadFileResult.</returns>
        public CPDFUploadFileResult UploadFile(string filePath, string imageFilePath, string taskId, CPDFFileParameter fileParameter, string password = "", int language = 0)
        {
             var fileStream = new FileStream(filePath, FileMode.Open);
             var imageStream = new FileStream(imageFilePath, FileMode.Open);
            return _httpClient.GetUploadFileResult(fileStream, taskId, password, fileParameter, Path.GetFileName(filePath), imageStream, Path.GetFileName(imageFilePath), language);
        }

        /// <summary>
        /// Execute task
        /// </summary>
        /// <param name="taskId">The task ID.</param>
        /// <param name="language">1:English, 2:Chinese</param>
        /// <returns>CPDFCreateTaskResult</returns>
        public CPDFCreateTaskResult ExecuteTask(string taskId, int language = 0)
        {
            return _httpClient.ExecuteTask(taskId, language);
        }

        /// <summary>
        /// Get task info
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="language"></param>
        /// <returns>CPDFTaskInfoResult</returns>
        public CPDFTaskInfoResult GetTaskInfo(string taskId, int language = 0)
        {
            return _httpClient.GetTaskInfo(taskId, language);
        }
    }
}
