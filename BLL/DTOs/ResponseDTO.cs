namespace BLL.DTOs
{
    public class ResponseDTO
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }

    public class ResponseDTO<T> : ResponseDTO
    {
        public T Data { get; set; }
    }
}
