namespace Pipeline.RepositoryManagement.Processing.Events.EventArgs
{
    public class ProcessOutputEventArgs : System.EventArgs
    {
        public ProcessOutputEventArgs(string output)
        {
            Output = output;
        }

        public string Output { get; private set; }
    }
}