using System;
using System.IO;
using System.Threading.Tasks;
using ComPDFKit.client;
using ComPDFKit.constant;
using ComPDFKit.enums;
using ComPDFKit.param;
using ComPDFKit.pojo.comPdfKit;
using System.Collections.Generic;
using ComPDFKit.exception;

namespace Samples
{
    public class PDFMerge
    {
        private static readonly string publicKey = "";
        private static readonly string secretKey = "";
        private static CPDFClient client;

        static void Main(string[] args)
        {
            PDFMergeFunc();
        }

        public static void PDFMergeFunc()
        {
            try
            {
                // Initialize Client
                client = new CPDFClient(publicKey, secretKey);
                // create Task
                CPDFCreateTaskResult createTaskResult = client.CreateTask(CPDFDocumentEditorEnum.MERGE);
                // taskId
                string taskId = createTaskResult.TaskId;
                // upload File
                FileInfo file = new FileInfo("sample/test.pdf");
                string filePassword = "";
                CPDFPageMergeParameter fileParameter = new CPDFPageMergeParameter();
                fileParameter.PageOptions = new List<string> { "1", "2" };
                CPDFUploadFileResult uploadFileResult = client.UploadFile(file, taskId, fileParameter, filePassword);
                // upload File
                FileInfo fileSecond = new FileInfo("sample/test.pdf");
                CPDFPageMergeParameter fileParameterSecond = new CPDFPageMergeParameter();
                fileParameterSecond.PageOptions = new List<string> { "1", "2" };
                client.UploadFile(fileSecond, taskId, fileParameterSecond, filePassword);
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
