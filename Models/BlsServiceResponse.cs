namespace BLS_API.Models
{
    public class BlsServiceResponse<T>
    {
        public T Data { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
