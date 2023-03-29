using System;

namespace Core
{
    public interface ITimeModel
    {
        IObservable<int> GameTime { get; }
    }
}