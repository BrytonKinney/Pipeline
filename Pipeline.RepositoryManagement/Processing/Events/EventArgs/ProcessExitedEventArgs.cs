namespace Pipeline.RepositoryManagement.Processing.Events.EventArgs
{
    public class ProcessExitedEventArgs : System.EventArgs
    {
        public ProcessExitedEventArgs(int exitCode, System.DateTime exitTime)
        {
            ExitCode = exitCode;
            ExitTime = exitTime;
        }

        public int ExitCode { get; }
        public System.DateTime ExitTime { get; }
    }
}