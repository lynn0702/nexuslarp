namespace NexCharCore
{
    public interface IContextManager
    {
        NexCharContextBase NexCharContext { get; set; }
    }

    public class ContextManager : IContextManager
    {
        public ContextManager()
        {
            NexCharContext = NexCharContextFactory.NexCharContext;
        }

        public NexCharContextBase NexCharContext { get; set; }
    }

}
