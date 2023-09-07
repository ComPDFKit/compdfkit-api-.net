namespace ComPDFKit.pojo.comPdfKit
{
    public class CPDFResult<T>
    {
        public string Code { get; set; }
        public string Msg { get; set; }
        public T Data { get; set; }

        public override string ToString()
        {
            return $"CPDFResult{{code='{Code}', msg='{Msg}', data={Data}}}";
        }
    }
}