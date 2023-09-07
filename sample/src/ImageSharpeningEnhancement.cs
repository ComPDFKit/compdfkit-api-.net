using System;
using System.IO;
using System.Threading.Tasks;
using ComPDFKit.client;
using ComPDFKit.constant;
using ComPDFKit.enums;
using ComPDFKit.exception;
using ComPDFKit.param;
using ComPDFKit.pojo.comPdfKit;

namespace Samples
{
    public class ImageSharpeningEnhancement
    {
        private static readonly string publicKey = "";
        private static readonly string secretKey = "";
        private static CPDFClient client;

        static void Main(string[] args)
        {
            ImageSharpeningEnhancementFunc();
        }

        public static void ImageSharpeningEnhancementFunc()
        {
            try
            {
                // Initialize Client
                client = new CPDFClient(publicKey, secretKey);
                // create Task
                CPDFCreateTaskResult createTaskResult = client.CreateTask(CPDFDocumentAIEnum.MAGICCOLOR);
                // taskId
                string taskId = createTaskResult.TaskId;
                // upload File
                FileInfo file = new FileInfo("sample/test.jpg");
                string filePassword = "";
                CPDFImageSharpeningEnhancementParameter fileParameter = new CPDFImageSharpeningEnhancementParameter();
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
                Console.WriteLine(e.GetCode() + ": " + e.Message);
            }
        }
    }
}
