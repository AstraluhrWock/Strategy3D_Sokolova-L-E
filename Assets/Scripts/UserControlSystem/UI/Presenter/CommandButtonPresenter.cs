//using System.Collections.Generic;
//using UnityEngine;
//using Abstractions;
//using Abstractions.Commands;
//using System;

//public class CommandButtonPresenter : MonoBehaviour
//{
//    [SerializeField] private SelectableValue _selectable;
//    [SerializeField] private CommandButtonPresenter _view;
//    private ISelectable _currentSelectable;

//    private void Start()
//    {
//        _selectable.OnSelected += OnSelected;
//        OnSelected(_selectable.CurrentValue);
//        _view.OnClick += OnButtonClick;
//    }
//    private void OnSelected(ISelectable selectable)
//    {
//        if (_currentSelectable == selectable)
//        {
//            return;
//        }
//        _currentSelectable = selectable;
//        _view.Clear();

//        if (selectable != null)
//        {
//            var commandExecutors = new List<ICommandExecutor>();
//            commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
//            _view.MakeLayout(commandExecutors);
//        }
//    }
//    private void OnButtonClick(ICommandExecutor commandExecutor)
//    {
//        var unitProducer = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;
//        var unitAttack = commandExecutor as CommandExecutorBase<IAttackCommand>;
//        var unitMove = commandExecutor as CommandExecutorBase<IMoveCommand>;
//        var unitPatrol = commandExecutor as CommandExecutorBase<IPatrolCommand>;
//        var unitStop = commandExecutor as CommandExecutorBase<IStopCommand>;

//        if (unitProducer != null)
//        {
//            unitProducer.ExecuteSpecificCommand(new ProduceUnitCommand());
//            return;
//        }

//        if (unitAttack != null)
//        {
//            unitAttack.ExecuteSpecificCommand(new AttackCommand());
//        }

//        if (unitMove != null)
//        {
//            unitMove.ExecuteSpecificCommand(new MoveCommand());
//        }

//        if (unitPatrol != null)
//        {
//            unitPatrol.ExecuteSpecificCommand(new PatrolCommand());
//        }

//        if (unitStop != null)
//        {
//            unitStop.ExecuteSpecificCommand(new StopCommand());
//        }

//        throw new ApplicationException($"{nameof(CommandButtonPresenter)}.{nameof(onButtonClick)}: Unknown type of commands executor: { commandExecutor.GetType().FullName }!");
//    }
//}
