//using UnityEngine;
//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using UniRx;
//using UnityEngine.AI;
//using Zenject;
//using Utils;
//using Abstractions.Commands.CommandExecutors;

//namespace Abstractions.Commands.CommandsInterfaces
//{
//    public partial class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
//    {
//        [SerializeField] private Animator _animator;
//        [SerializeField] private StopCommandExecutor _stopCommandExecutor;

//        [Inject] private IHealthHolder _ourHealth;
//        [Inject(Id = "AttackDistance")] private float _attackingDistance;
//        [Inject(Id = "AttackPeriod")] private int _attackingPeriod;

//        private Vector3 _ourPosition;
//        private Vector3 _targetPosition;
//        private Quaternion _ourRotation;

//        private readonly Subject<Vector3> _targetPositions = new Subject<Vector3>();
//        private readonly Subject<Quaternion> _targetRotations = new Subject<Quaternion>();
//        private readonly Subject<IAttackable> _attackTargets = new Subject<IAttackable>();
//        private Transform _targetTransform;
//       // private AttackOperation _currentAttackOp;

//        [Inject]
//        private void Init()
//        {
//            _targetPositions
//            .Select(value => new Vector3((float)Math.Round(value.x, 2),
//            (float)Math.Round(value.y, 2), (float)Math.Round(value.z, 2)))
//            .Distinct()
//            .ObserveOnMainThread()
//            .Subscribe(startMovingToPosition);
//            _attackTargets
//            .ObserveOnMainThread()
//            .Subscribe(startAttackingTargets);
//            _targetRotations
//            .ObserveOnMainThread()
//            .Subscribe(setAttackRoation);
//        }
//        private void setAttackRoation(Quaternion targetRotation)
//        {
//            transform.rotation = targetRotation;
//        }
//        private void startAttackingTargets(IAttackable target)
//        {
//            GetComponent<NavMeshAgent>().isStopped = true;
//            GetComponent<NavMeshAgent>().ResetPath();
//           // _animator.SetTrigger(Animator.StringToHash(AnimationTypes.Attack));
//            target.ReceiveDamage(GetComponent<IDamageDealer>().Damage);
//        }
//        private void startMovingToPosition(Vector3 position)
//        {
//            GetComponent<NavMeshAgent>().destination = position;
//            //_animator.SetTrigger(Animator.StringToHash(AnimationTypes.Walk));
//        }
//        public override async Task ExecuteSpecificCommand(IAttackCommand command)
//        {
//            /*_targetTransform = (command.Target as Component).transform;
//            _currentAttackOp = new AttackOperation(this, command.Target);
//            _stopCommandExecutor.CancellationTokenSource = new
//            CancellationTokenSource();
//            try
//            {
//                await _currentAttackOp.WithCancellation(_stopCommandExecutor.CancellationTokenSource.Token);
//            }
//            catch
//            {
//                _currentAttackOp.Cancel();
//            }
//            _animator.SetTrigger("Idle");
//            _currentAttackOp = null;
//            _targetTransform = null;
//            _stopCommandExecutor.CancellationTokenSource = null;*/
//        }

//        /*private void Update()
//        {
//            if (_currentAttackOp == null)
//            {
//                return;
//            }
//        }*/

//        #region
//       /* public class AttackOperation : IAwaitable<AsyncExtensions.Void>
//        {
//            public class AttackOperationAwaiter : AwaiterBase<AsyncExtensions.Void>
//            {
//                private AttackOperation _attackOperation;
//                public AttackOperationAwaiter(AttackOperation attackOperation)
//                {
//                    _attackOperation = attackOperation;
//                    attackOperation.OnComplete += onComplete;
//                }
//                private void onComplete()
//                {
//                    _attackOperation.OnComplete -= onComplete;
//                    onWaitFinish(new AsyncExtensions.Void());
//                }
//            }*/

//            private event Action OnComplete;
//            private readonly AttackCommandExecutor _attackCommandExecutor;
//            private readonly IAttackable _target;
//            private bool _isCancelled;
//            /*public AttackOperation(AttackCommandExecutor attackCommandExecutor, IAttackable target)
//            {
//                _target = target;
//                _attackCommandExecutor = attackCommandExecutor;
//                var thread = new Thread(attackAlgorythm);
//                thread.Start();
//            }*/

//            public void Cancel()
//            {
//                _isCancelled = true;
//                OnComplete?.Invoke();
//            }
//            private void attackAlgorythm(object obj)
//            {
//                while (true)
//                {
//                    if (
//                    _attackCommandExecutor == null
//                    || _attackCommandExecutor._ourHealth.Health == 0
//                    || _target.Health == 0
//                    || _isCancelled
//                )
//                    {
//                        OnComplete?.Invoke();
//                        return;
//                    }
//                    var targetPosition = default(Vector3);
//                    var ourPosition = default(Vector3);
//                    var ourRotation = default(Quaternion);
//                    lock (_attackCommandExecutor)
//                    {
//                        targetPosition = _attackCommandExecutor._targetPosition;
//                        ourPosition = _attackCommandExecutor._ourPosition;
//                        ourRotation = _attackCommandExecutor._ourRotation;
//                    }

//                    var vector = targetPosition - ourPosition;
//                    var distanceToTarget = vector.magnitude;
//                    if (distanceToTarget > _attackCommandExecutor._attackingDistance)
//                    {
//                        var finalDestination = targetPosition - vector.normalized *
//                        (_attackCommandExecutor._attackingDistance * 0.9f);
//                        _attackCommandExecutor
//                        ._targetPositions.OnNext(finalDestination);
//                        Thread.Sleep(100);
//                    }
//                    else if (ourRotation != Quaternion.LookRotation(vector))
//                    {
//                        _attackCommandExecutor.
//                        _targetRotations
//                        .OnNext(Quaternion.LookRotation(vector));
//                    }

//                    else
//                    {
//                        _attackCommandExecutor._attackTargets.OnNext(_target);
//                        Thread.Sleep(_attackCommandExecutor._attackingPeriod);
//                    }
//                }
//            }
//            /*public IAwaiter<AsyncExtensions.Void> GetAwaiter()
//            {
//                return new AttackOperationAwaiter(this);
//            }*/

//            #endregion
//        }
//    }

