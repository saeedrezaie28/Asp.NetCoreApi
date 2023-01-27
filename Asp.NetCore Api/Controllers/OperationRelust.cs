namespace Asp.NetCore_Api.Controllers
{
    public class OperationResult
    {
        public bool Succeess { get; set; }
        public string Message { get; set; }
    }
    public class OperationResult<T> : OperationResult
    {
        public T Data { get; set; }
    }
}