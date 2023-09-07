namespace ComPDFKit.constant
{
    public static class CPDFConstant
    {
        public const string API_V1_OAUTH_TOKEN = "v1/oauth/token";

        public const string API_V1_CREATE_TASK = "v1/task/{executeTypeUrl}";

        public const string API_V1_TOOL_SUPPORT = "v1/tool/support";

        public const string API_V1_FILE_INFO = "v1/file/fileInfo";

        public const string API_V1_ASSET_INFO = "v1/asset/info";
        public const string API_V1_TASK_LIST = "v1/task/list";

        public const string API_V1_UPLOAD_FILE = "v1/file/upload";

        public const string API_V1_EXECUTE_TASK = "v1/execute/start";

        public const string API_V1_TASK_INFO = "v1/task/taskInfo";

        public const string COM_PDF_KIT_TOKEN = "ComPDFKit_AccessToken";

        public const string EXCEPTION_MSG_GET_TOKEN_FAIL = "Failed to get ComPDFKit Token: ";

        public const string EXCEPTION_MSG_CREATE_TASK_FAIL = "Saas task creation failed: ";

        public const string EXCEPTION_MSG_UPLOAD_FILE_FAIL = "Saas upload file failed: ";

        public const string EXCEPTION_MSG_EXECUTE_TASK_FAIL = "Saas file conversion failed: ";

        public const string EXCEPTION_MSG_TASK_INFO_FAIL = "Failed to query saas file status: ";
        public const string EXCEPTION_MSG_QUERY_FILE_INFO_FAIL = "Saas query file info failed: ";
        public const string EXCEPTION_MSG_QUERY_TOOLS_FAIL = "Saas query tools  failed: ";
        public const string EXCEPTION_MSG_QUERY_TENANT_ASSET_FAIL = "Saas query tenant asset failed: ";
        public const string EXCEPTION_MSG_QUERY_TASK_LIST_FAIL = "";


        public const string SUCCESS_CODE = "200";
        const int SUCCESS = 200;
        public const string RESULT_SUCCESS = "success";
        public const string STRING_SIGN_PERIOD = ".";
        public const string STRING_SIGN_COLON = ":";
        public const string PARAMS_MISSING_ERROR = "Missing required parameter!";
        public const string TASK_FINISH = "TaskFinish";
        const int EXCEPTION_CODE_PARAMETERS_ERROR = 300;
        const int EXCEPTION_CODE_SERVER_ERROR = 500;
        const int EXCEPTION_CODE_RUNTIME_ERROR = 700;
    }
}
