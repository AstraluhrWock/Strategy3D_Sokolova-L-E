using Abstractions.Commands.CommandsInterfaces;
using Zenject;
using Utils;
using System;
using UnityEngine;
using UserControlSystem.CommandRealization;

namespace UserControlSystem
{
    public sealed class MoveCommandCreator : CommandCreatorBase<IMoveCommand>
    {
        [Inject] private AssetsContext _context;
        private Action<IMoveCommand> _createCallback;

        [Inject]
        private void Init(Vector3Value groundClicks) => groundClicks.OnNewValue += OnNewValue;

        private void OnNewValue(Vector3 groundClick)
        {
            _createCallback?.Invoke(_context.Inject(new MoveCommand(groundClick)));
            _createCallback = null;
        }

        protected override void ClassSpecificCommandCreation(Action<IMoveCommand> creationCallback)
        {
            _createCallback = creationCallback;
        }

        public override void ProcessCancel()
        {
            base.ProcessCancel();
            _createCallback = null;
        }
    }
}
