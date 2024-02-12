namespace TestMvc.Models
{

    public class ServiceResponse
    {
        public bool Success
        {
            get => Error == string.Empty;
        }
        public string Error { get; set; } = string.Empty;
        public ServiceResponse() { }
        public ServiceResponse(string error)
        {
            Error = error;
        }
    }

    public class ServiceResponse<T> : ServiceResponse
    {

        public T? Response { get; set; }

        public ServiceResponse(T response)
        {
            Response = response;
        }

        public ServiceResponse(string message) : base(message) { }
        
    }
}
