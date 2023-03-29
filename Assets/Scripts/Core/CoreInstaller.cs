using Zenject;

namespace Core
{
    public class CoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(ITimeModel), typeof(ITickable)).To(typeof(TimeModel)).AsSingle();
        }
    }
}