using System;
using System.IO;
using ComPDFKit;
using ComPDFKit.client;
using ComPDFKit.constant;
using ComPDFKit.enums;
using ComPDFKit.exception;
using ComPDFKit.param;
using ComPDFKit.pojo.comPdfKit;

namespace Samples
{
    public class AddWatermark
    {
        private const string publicKey = "";
        private const string secretKey = "";
        private static  CPDFClient client;

        public static void Main(string[] args)
        {
            AddWatermarkTextFunc();
            // AddWatermarkImageFunc();
        }

        public static void AddWatermarkTextFunc()
        {
            try
            {
                // Initialize Client
                client = new CPDFClient(publicKey, secretKey);
                // Create Task
                CPDFCreateTaskResult createTaskResult =client.CreateTask(CPDFDocumentEditorEnum.ADD_WATERMARK, CPDFLanguageConstant.English);
                // TaskId
                string taskId = createTaskResult.TaskId;
                // Upload File
                FileInfo file = new FileInfo("sample/test.pdf");
                string filePassword = "";
                CPDFAddWatermarkParameter fileParameter = new CPDFAddWatermarkParameter
                {
                    Type = "text",
                    Scale = "1",
                    Opacity = "0.5",
                    Rotation = "0.785",
                    TargetPages = "1-2",
                    VertAlign = "center",
                    HorizAlign = "left",
                    XOffset = "100",
                    YOffset = "100",
                    Content = "test",
                    TextColor = "#59c5bb",
                    FullScreen = "1",
                    HorizontalSpace = "10",
                    VerticalSpace = "10",
                    Front = "1"
                };
                CPDFUploadFileResult uploadFileResult = client.UploadFile(file, taskId, fileParameter, filePassword);
                string fileKey = uploadFileResult.FileKey;
                // Perform Tasks
                client.ExecuteTask(taskId);
                // Get Task Processing Information
                CPDFTaskInfoResult taskInfo = client.GetTaskInfo(taskId);
                // Determine whether the task status is "TaskFinish"
                if (taskInfo.TaskStatus == CPDFConstant.TASK_FINISH)
                {
                    Console.WriteLine(taskInfo);
                    // Get the final file processing information
                    CPDFFileInfo fileInfo = client.GetFileInfo(fileKey);
                    Console.WriteLine(fileInfo);
                    // If the task is finished, cancel the scheduled task
                }
                else
                {
                    Console.WriteLine("Task incomplete processing");
                }
            }
            catch (CPDFException e)
            {
                Console.WriteLine(e.GetCode() + ": " + e.Message);
            }
        }

        public static void AddWatermarkImageFunc()
        {
            try
            {
                // Initialize Client
                client = new CPDFClient(publicKey, secretKey);
                // Create Task
                CPDFCreateTaskResult createTaskResult = client.CreateTask(CPDFDocumentEditorEnum.ADD_WATERMARK);
                // TaskId
                string taskId = createTaskResult.TaskId;
                // Upload File
                FileInfo file = new FileInfo("sample/test.pdf");
                string filePassword = "";
                CPDFAddWatermarkParameter fileParameter = new CPDFAddWatermarkParameter
                {
                    Type = "image",
                    Scale = "0.5",
                    Opacity = "0.5",
                    Rotation = "45",
                    TargetPages = "1-2",
                    VertAlign = "center",
                    HorizAlign = "left",
                    XOffset = "50",
                    YOffset = "50",
                    FullScreen = "1",
                    HorizontalSpace = "100",
                    VerticalSpace = "100",
                    Front = "1"
                };
                CPDFUploadFileResult uploadFileResult =
                    client.UploadFile(file, new FileInfo("sample/test.jpg"), taskId, fileParameter, filePassword);
                string fileKey = uploadFileResult.FileKey;
                // Perform Tasks
                client.ExecuteTask(taskId);
                // Get Task Processing Information
                CPDFTaskInfoResult taskInfo = client.GetTaskInfo(taskId);
                // Determine whether the task status is "TaskFinish"
                if (taskInfo.TaskStatus == CPDFConstant.TASK_FINISH)
                {
                    Console.WriteLine(taskInfo);
                    // Get the final file processing information
                    CPDFFileInfo fileInfo = client.GetFileInfo(fileKey);
                    Console.WriteLine(fileInfo);
                    // If the task is finished, cancel the scheduled task
                }
                else
                {
                    Console.WriteLine("Task incomplete processing");
                }
            }
            catch (CPDFException e)
            {
                Console.WriteLine(e.GetCode() + ": " + e.Message);
            }
        }
    }
}