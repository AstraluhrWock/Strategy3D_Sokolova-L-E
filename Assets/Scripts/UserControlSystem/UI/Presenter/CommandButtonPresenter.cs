using System.Collections.Generic;
using UnityEngine;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using Zenject;
using Utils;
using UserControlSystem.CommandRealization;
using System;
using UI.Model;

public class CommandButtonPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    [SerializeField] private CommandButtonView _view;
    [SerializeField] private AssetsContext _context;

    private ISelectable _currentSelectable;

    private void Start()
    {
        _selectable.OnSelected += OnSelected;
        OnSelected(_selectable.CurrentValue);

        _view.OnClick += OnButtonClick;
    }
    private void OnSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable)
        {
            return;
        }
        _currentSelectable = selectable;

        _view.Clear();

       if (selectable != null)
        {
            var commandExecutors = new List<ICommandExecutor>();
            commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
            _view.MakeLayout(commandExecutors);
        }
    }

    private void OnButtonClick(ICommandExecutor commandExecutor)
    {
        var unitProducer = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;
        if (unitProducer != null)
        {
            unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommand()));
            return;
        }

        var unitAttack = commandExecutor as CommandExecutorBase<IAttackCommand>;
        if (unitAttack != null)
        {
            //unitAttack.ExecuteSpecificCommand(_context.Inject(new AttackCommand()));
        }

       /* var unitMove = commandExecutor as CommandExecutorBase<IMoveCommand>;
        if (unitMove != null)
        {
            unitMove.ExecuteSpecificCommand(_context.Inject(new MoveCommand()));
        }*/

        var unitPatrol = commandExecutor as CommandExecutorBase<IPatrolCommand>;
        if (unitPatrol != null)
        {
            unitPatrol.ExecuteSpecificCommand(_context.Inject(new PatrolCommand()));
        }

        var unitStop = commandExecutor as CommandExecutorBase<IStopCommand>;
        if (unitStop != null)
        {
            unitStop.ExecuteSpecificCommand(_context.Inject(new StopCommand()));
        }

        throw new ApplicationException($"{nameof(CommandButtonPresenter)}.{nameof(OnButtonClick)}: " + 
            $"Unknown type of commands executor: {commandExecutor.GetType().FullName}!");
    }
}
