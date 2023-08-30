namespace JituUdemy.Responses
{
    public class SuccessMessage
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public SuccessMessage(int code, string message)
        {
            Code=code;
            Message=message;
        }
    }
}
