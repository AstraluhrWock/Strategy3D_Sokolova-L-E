using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UnityEngine.AI;
//using Core;


namespace Abstractions.Commands.CommandExecutors
{
    public class PatrolCommandExecutor// : CommandExecutorBase<IPatrolCommand>
    {
        //[SerializeField] private UnitMovementStop _stop;
        [SerializeField] private Animator _animator;
        [SerializeField] private StopCommandExecutor _stopCommandExecutor;

        /*public override async Task ExecuteSpecificCommand(IPatrolCommand command)
        {
            var point1 = command.From;
            var point2 = command.To;
            while (true)
            {
                GetComponent<NavMeshAgent>().destination = point2;
                _animator
                .SetTrigger(Animator
                .StringToHash(AnimationTypes.Walk));
                _stopCommandExecutor.CancellationTokenSource = new
                CancellationTokenSource();
                try
                {
                    await
                    _stop.WithCancellation(_stopCommandExecutor.CancellationTokenSource.Token);
                }
                catch
                {
                    GetComponent<NavMeshAgent>().isStopped = true;
                    GetComponent<NavMeshAgent>().ResetPath();
                    break;
                }
                var temp = point1;
                point1 = point2;
                point2 = temp;
            }
            _stopCommandExecutor.CancellationTokenSource = null;
            _animator.SetTrigger(Animator.StringToHash(AnimationTypes.Idle));
        }*/
    }
}
