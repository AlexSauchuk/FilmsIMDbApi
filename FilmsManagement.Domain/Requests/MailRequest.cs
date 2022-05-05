namespace FilmsManagement.Domain.Requests
{
    public class MailRequest
    {
        public string Subject { get; set; }

        public string ToEmail { get; set; }

        public string Body { get; set; }
    }
}
