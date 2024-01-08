namespace BookManagement.Infrastructure.Services
{
    public class Common
    {
        public class ServiceResult<T>
        {
            public StatusType Status { get; set; }
            public string Message { get; set; }
            public T Data { get; set; }
        }
    }

    public enum StatusType
    {
        Success,
        Failure,
    }
}
