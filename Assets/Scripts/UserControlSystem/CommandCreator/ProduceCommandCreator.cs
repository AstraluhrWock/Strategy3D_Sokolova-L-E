using Abstractions.Commands.CommandsInterfaces;
using Utils;
using Zenject;
using System;

namespace UserControlSystem
{
    public sealed class ProduceCommandCreator /*: CancellableCommandCreatorBase<IProduceUnitCommand>
    {
        [Inject] private AssetsContext _context;
        [Inject] private DiContainer _diContainer;
        protected override void ClassSpecificCommandCreation(Action<IProduceUnitCommand> creationCallback)
        {
            var produceUnitCommand = _context.Inject(new ProduceUnitCommand());
            _diContainer.Inject(produceUnitCommand);
            creationCallback?.Invoke(produceUnitCommand);
        }*/
    { }
}

