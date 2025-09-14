namespace App.Domain.Core.Result
{
    public class Resultt
    {
        public bool IsSuccess { get; set; }
        public string? IsMessage { get; set; }
        public Resultt(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            IsMessage = message;
        }
    }
}
