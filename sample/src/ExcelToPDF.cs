using System;
using System.IO;
using ComPDFKit.client;
using ComPDFKit.constant;
using ComPDFKit.enums;
using ComPDFKit.exception;
using ComPDFKit.param;
using ComPDFKit.pojo.comPdfKit;

namespace Samples
{
    public class ExcelToPDF
    {
        private const string publicKey = "";
        private const string secretKey = "";
        private static CPDFClient client;

        static void Main(string[] args)
        {
            ExcelToPDFFunc();
        }

        static void ExcelToPDFFunc()
        {
            try
            {
                // Initialize Client
                client = new CPDFClient(publicKey, secretKey);
                // Create Task
                CPDFCreateTaskResult createTaskResult = client.CreateTask(CPDFConversionEnum.XLSX_TO_PDF);
                // TaskId
                string taskId = createTaskResult.TaskId;
                // Upload File
                FileInfo file = new FileInfo("sample/test.xlsx");
                string filePassword = "";
                CExcelToPDFParameter fileParameter = new CExcelToPDFParameter();
                CPDFUploadFileResult uploadFileResult = client.UploadFile(file, taskId, fileParameter, filePassword);
                string fileKey = uploadFileResult.FileKey;
                // Perform tasks
                client.ExecuteTask(taskId);
                // Get task processing information
                CPDFTaskInfoResult taskInfo = client.GetTaskInfo(taskId);
                // Determine whether the task status is "TaskFinish"
                if (taskInfo.TaskStatus.Equals(CPDFConstant.TASK_FINISH))
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