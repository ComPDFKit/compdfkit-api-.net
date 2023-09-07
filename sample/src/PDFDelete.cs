using System;
using System.IO;
using System.Threading.Tasks;
using ComPDFKit.client;
using ComPDFKit.constant;
using ComPDFKit.enums;
using ComPDFKit.param;
using ComPDFKit.pojo.comPdfKit;
using System.Collections.Generic;
using System.Linq;
using ComPDFKit.exception;

namespace Samples
{
    public class PDFDelete
    {
        private static readonly string publicKey = "";
        private static readonly string secretKey = "";
        private static CPDFClient client;

        static void Main(string[] args)
        {
            PDFDeleteFunc();
        }

        public static void PDFDeleteFunc()
        {
            try
            {
                // Initialize Client
                client = new CPDFClient(publicKey, secretKey);
                // create Task
                CPDFCreateTaskResult createTaskResult = client.CreateTask(CPDFDocumentEditorEnum.DELETE);
                // taskId
                string taskId = createTaskResult.TaskId;
                // upload File
                FileInfo file = new FileInfo("sample/test.pdf");
                string filePassword = "";
                CPDFPageDeleteParameter fileParameter = new CPDFPageDeleteParameter();
                fileParameter.PageOptions = new List<string> { "1", "2" };
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
