namespace CheckMate_API.Exceptions
{
    public class MyExceptions { }
    public class MailNotSentExceptions : Exception 
    {
        public MailNotSentExceptions(string message) : base(message) { }
    }
}