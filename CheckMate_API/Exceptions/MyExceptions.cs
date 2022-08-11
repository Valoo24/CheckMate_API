namespace CheckMate_API.Exceptions
{
    public class MyExceptions { }
    /// <summary>
    /// Exception levée si un Email ne s'est pas envoyé correctement.
    /// </summary>
    public class MailNotSentExceptions : Exception 
    {
        public MailNotSentExceptions(string message) : base(message) { }
    }
}