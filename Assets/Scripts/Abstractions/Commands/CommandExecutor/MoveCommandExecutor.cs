using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UnityEngine.AI;
//using Core;


namespace Abstractions.Commands.CommandExecutors
{

    public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {
        //[SerializeField] private UnitMovementStop _stop;
        [SerializeField] private Animator _animator;
        [SerializeField] private StopCommandExecutor _stopCommand;
        private static readonly int Walk = Animator.StringToHash("Walk");
        private static readonly int Idle = Animator.StringToHash("Idle");

        public override async void ExecuteSpecificCommand(IMoveCommand command)
        {
            GetComponent<NavMeshAgent>().destination = command.Target;
            _animator.SetTrigger(Walk);
           /* _stopCommand.CancellationTokenSource = new CancellationTokenSource();
            try
            {
                await _stop.WithCancellation(_stopCommand.CancellationTokenSource.Token);
            }
            catch
            {
                GetComponent<NavMeshAgent>().isStopped = true;
                GetComponent<NavMeshAgent>().ResetPath();
            }

            _stopCommand.CancellationTokenSource = null;
            _animator.SetTrigger(Idle);*/
        }
        
    }
}
