using UniRx;
using Abstractions;

namespace Utils
{
    public interface IUnitProducer
    {
        IReadOnlyReactiveCollection<IUnitProductionTask> Queue { get; }
        public void Cancel(int index);
    }
}