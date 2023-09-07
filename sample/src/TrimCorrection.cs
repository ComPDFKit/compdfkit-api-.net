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
    public class TrimCorrection
    {
        private static readonly string publicKey = "";
        private static readonly string secretKey = "";
        private static CPDFClient client;

        public static void Main(string[] args)
        {
            TrimCorrectionFunc();
        }

        public static void TrimCorrectionFunc()
        {
            try
            {
                // Initialize Client
                client = new CPDFClient(publicKey, secretKey);
                // create Task
                CPDFCreateTaskResult createTaskResult = client.CreateTask(CPDFDocumentAIEnum.DEWARP);
                // taskId
                string taskId = createTaskResult.TaskId;
                // upload File
                FileInfo file = new FileInfo("sample/test.jpg");
                string filePassword = "";
                CPDFTrimCorrectionParameter fileParameter = new CPDFTrimCorrectionParameter();
                CPDFUploadFileResult uploadFileResult = client.UploadFile(file, taskId, fileParameter, filePassword);
                string fileKey = uploadFileResult.FileKey;
                // perform tasks
                client.ExecuteTask(taskId);
                // get task processing information
                CPDFTaskInfoResult taskInfo = client.GetTaskInfo(taskId);
                // determine whether the task status is "TaskFinish"
                if (taskInfo.TaskStatus.Equals(CPDFConstant.TASK_FINISH))
                {
                    Console.WriteLine(taskInfo);
                    // get the final file processing information
                    CPDFFileInfo fileInfo = client.GetFileInfo(fileKey);
                    Console.WriteLine(fileInfo);
                    // if the task is finished, cancel the scheduled task
                }
                else
                {
                    Console.WriteLine("Task incomplete processing");
                }
            }
            catch (CPDFException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}