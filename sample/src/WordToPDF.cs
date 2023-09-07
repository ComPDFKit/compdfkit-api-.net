using System;
using System.IO;
using ComPDFKit.client;
using ComPDFKit.constant;
using ComPDFKit.enums;
using ComPDFKit.exception;
using ComPDFKit.param;
using ComPDFKit.pojo.comPdfKit;

namespace ComPDFKit
{
    public class WordToPDF
    {
        private static readonly string publicKey = "";
        private static readonly string secretKey = "";
        private static CPDFClient client;

        public static void Main(string[] args)
        {
            WordToPDFFunc();
        }

        public static void WordToPDFFunc()
        {
            try
            {
                // Initialize Client
                client = new CPDFClient(publicKey, secretKey);
                // Create Task
                CPDFCreateTaskResult createTaskResult = client.CreateTask(CPDFConversionEnum.DOCX_TO_PDF);
                // TaskId
                string taskId = createTaskResult.TaskId;
                // Upload File
                FileInfo file = new FileInfo("sample/test.docx");
                string filePassword = "";
                CWordToPDFParameter fileParameter = new CWordToPDFParameter();
                CPDFUploadFileResult uploadFileResult = client.UploadFile(file, taskId, fileParameter, filePassword);
                string fileKey = uploadFileResult.FileKey;
                // Perform tasks
                client.ExecuteTask(taskId);
                // Get Task Processing Information
                CPDFTaskInfoResult taskInfo = client.GetTaskInfo(taskId);
                // Determine Whether the Task Status is "TaskFinish"
                if (taskInfo.TaskStatus.Equals(CPDFConstant.TASK_FINISH))
                {
                    Console.WriteLine(taskInfo);
                    // Get The Final File Processing Information
                    CPDFFileInfo fileInfo = client.GetFileInfo(fileKey);
                    Console.WriteLine(fileInfo);
                    // If The Task is Finished, Cancel The Scheduled Task
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