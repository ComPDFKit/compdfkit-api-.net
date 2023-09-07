## ComPDFKit API in C#.NET

[ComPDFKit](https://api.compdf.com/api/docs/introduction) API provides a variety of C# API tools that allow you to create an efficient document processing workflow in a single API call. Try our various APIs for free — no credit card required.



## Requirements

Programming Environment: .NET Framework 4.6.1 or higher. Or .NET Core 1.0 or higher.

Dependencies: Nuget.



## Installation

You can install the ComPDFKit API in C# via NuGet Package Manager, or run the following command in the Package Manager Console:
``` shell script
Install-Package ComPDFKit.Api.CSharp
```
Alternatively, you can add the package ***"ComPDFKit.Api.CSharp"***, choose the package version you want to your ***".csproj"*** file, and then run.



## Create API Client

You can use your **publicKey** and **secretKey** to complete the authentication. You need to [sign in](https://api.compdf.com/login) your ComPDFKit API account to get your **publicKey** and **secretKey** at the [dashboard](https://api-dashboard.compdf.com/api/keys). If you are new to ComPDFKit, click here to [sign up](https://api.compdf.com/signup) for a free trial.

- Project public Key: You can find the public key in the **API Keys** section of your ComPDFKit API account.

- Project secret Key: You can find the secret Key in the **API Keys** section of your ComPDFKit API account.

```csharp
CPDFClient client = new CPDFClient(<publicKey>, <secretKey>);
```



## Create Task

A task ID is automatically generated for you based on the type of PDF tool you choose. You can provide the callback notification URL. After the task processing is completed, we will notify you of the task result through the callback interface. You can perform other operations according to the request result, such as checking the status of the task, uploading files, starting the task, or downloading the result file.

```csharp
// Create a client
CPDFClient client = new CPDFClient(<publicKey>, <secretKey>);

// Create a task
// Create an example task to convert a PDF tO a Word
CPDFCreateTaskResult result = client.CreateTask(CPDFConversionEnum.PDF_TO_WORD);

// Get a task id
string taskId = result.TaskId;
```



## Upload Files

Upload the original file and bind the file to the task ID. The field parameter is used to pass the JSON string to set the processing parameters for the file. Each file will generate automatically a unique **filekey**. Please note that a maximum of five files can be uploaded for a task ID and no files can be uploaded for that task after it has started.

```csharp
// Create a client
CPDFClient client = new CPDFClient(<publicKey>, <secretKey>);

// Create a task
// Create an example task to convert a PDF tO a Word
CPDFCreateTaskResult result = client.CreateTask(CPDFConversionEnum.PDF_TO_WORD);

// Get a task id
string taskId = result.TaskId;

// Upload files
client.UploadFile(<convertFile>, taskId);
```



## Execute the Task

After the file upload is completed, call this interface with the task ID to process the files.

```csharp
// Create a client
CPDFClient client = new CPDFClient(<publicKey>, <secretKey>);

// Create a task
// Create an example task to convert a PDF tO a Word
CPDFCreateTaskResult result = client.CreateTask(CPDFConversionEnum.PDF_TO_WORD);

// Get a task id
string taskId = result.TaskId;

// Upload files
client.UploadFile(<convertFile>, taskId);

// Execute the task
client.ExecuteTask(taskId, CPDFLanguageConstant.English);
```



## Get Task Info

Request task status and file-related meta data based on the task ID.

```csharp
// Create a client
CPDFClient client = new CPDFClient(<publicKey>, <secretKey>);

// Create a task
// Create an example task to convert a PDF tO a Word
CPDFCreateTaskResult result = client.CreateTask(CPDFConversionEnum.PDF_TO_WORD);

// Get a task id
string taskId = result.TaskId;

// Upload files
client.UploadFile(<convertFile>, taskId);

// execute Task
client.ExecuteTask(taskId, CPDFLanguageConstant.English);

// Query TaskInfo
CPDFTaskInfoResult taskInfo = client.GetTaskInfo(taskId);
```



## Samples

See ***"Samples"*** folder in this folder.



## Resources

* [Guides of ComPDFKit API Libraries](https://api.compdf.com/api-libraries/overview)
