namespace DoAnTedu.Common
{
    public class ResponseService <T> where T : class
    {
        public T? Data { get; set; }
        public int Statuscode { get; set; }
        public string? Message { get; set; }
    }
}
