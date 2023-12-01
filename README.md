# ComPDFKit API in C#.NET

## Introduction

[ComPDFKit](https://www.compdf.com/) offers powerful and steady PDF libraries and complete PDF functions to build PDF viewer and editor, which allows to preview, edit, annotate, sign, encrypt and decrypt PDF files.

[ComPDFKit API](https://api.compdf.com/api/docs/introduction) provides a variety of C# API tools that allow you to create an efficient document processing workflow in a single API call. Try our various APIs for free  no credit card required.

### Related

- ComPDFKit API - PHP Library: [ComPDFKit API - PHP Library](https://github.com/ComPDFKit/compdfkit-api-php)

- ComPDFKit API - Java Library: [ComPDFKit API - Java Library](https://github.com/ComPDFKit/compdfkit-api-java)

- ComPDFKit API - Swift Library: [ComPDFKit API - Swift Library](https://github.com/ComPDFKit/compdfkit-api-swift)

- ComPDFKit API - Python Library: [ComPDFKit API - Python Library](https://github.com/ComPDFKit/compdfkit-api-python)


## Requirements

Programming Environment: .NET Framework 4.6.1 or higher. Or .NET Core 1.0 or higher.



## Installation

You can install [the NuGet Package of ComPDFKit API Library](https://www.nuget.org/packages/compdfkit-api-dotnet) directly using the NuGet Package Manager. Alternatively, you can run the following command in the NuGet Package Manager Console:
``` shell script
Install-Package compdfkit-api-dotnet
```

## Usage

### Create An API Client

First of all, please create an API client to complete the authentication. You need to [sign in](https://api.compdf.com/login) your ComPDFKit API account to get your **publicKey** and **secretKey** at the [dashboard](https://api-dashboard.compdf.com/api/keys). If you are new to ComPDFKit, click here to [sign up](https://api.compdf.com/signup) for a free trial to process 1,000 documents per month for free.

- Project public Key: You can find the public key in the **API Keys** section of your ComPDFKit API account.

- Project secret Key: You can find the secret Key in the **API Keys** section of your ComPDFKit API account.

```csharp
CPDFClient client = new CPDFClient(<publicKey>, <secretKey>);
```



### Create A Task

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



### Upload Files

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



### Execute the Task

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



### Get The Task Info

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

## Examples

There are many examples in the **samples** folder, which show the main features of the ComPDFKit API and how to use them, such as watermarking PDFs, converting PDF to Word, Excel, JPG, PNG, etc. You can copy the code to your project and run it directly. To learn more about the ComPDFKit API, please visit our [API Reference](https://api.compdf.com/api-reference/overview).


## Free Trial

[ComPDFKit API](https://api.compdf.com/) is a powerful API that can be used to create an efficient document processing workflow in a single API call.

If you do not have a ComPDFKit API account, you can [sign up for a free trial](https://api.compdf.com/signup) to process 1,000 documents per month for free.

Once you have a ComPDFKit API account, you can obtain your **publicKey** and **secretKey** in the [dashboard](https://api-dashboard.compdf.com/api/keys).


## Support

[ComPDFKit](https://www.compdf.com/) has a professional R&D team that produces comprehensive technical documentation and guides to help developers. Also, you can get an immediate response when reporting your problems to our support team.

For detailed information, please visit our [Guides page](https://api.compdf.com/api/docs/guides).

Stay updated with the latest improvements through our [Changelog](https://www.compdf.com/api/changelog-compdfkit-api).

For technical assistance, please reach out to our [Technical Support](https://www.compdf.com/support).

To get more details and an accurate quote, please contact our [Sales Team](https://www.compdf.com/contact-sales).


## License

The code is available as open source under the terms of the [MIT License](http://opensource.org/licenses/MIT).
