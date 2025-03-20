namespace _038_Advanced_Dependency_Injection_DI.DI_with_Delegate_Factories
{
    public class EmailSender
    {
        private readonly string _smtpServer;

        public EmailSender(string smtpServer)
        {
            _smtpServer = smtpServer;
        }

        public void Send(string email, string message)
        {
            // send email logic
        }
    }

}
