using System.Runtime.CompilerServices;

namespace Utils
{
    public interface IAwaiter<TAwaited> : INotifyCompletion
    {
        public bool IsCompleted { get; }
        public TAwaited GetResult();
    }
}
