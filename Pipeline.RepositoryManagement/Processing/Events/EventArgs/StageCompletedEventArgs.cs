namespace Pipeline.RepositoryManagement.Processing.Events.EventArgs
{
    public class StageCompletedEventArgs : System.EventArgs
    {
        public StageCompletedEventArgs(Configuration.Stage stage)
        {
            Stage = stage;
        }

        public Configuration.Stage Stage { get; }
    }
}
