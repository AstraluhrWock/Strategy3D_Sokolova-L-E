using UnityEngine;
using Zenject;
using Abstractions.Commands.CommandsInterfaces;

namespace Core
{
    public class AttackerParallelnfoUpdater : MonoBehaviour, ITickable
    {
        [Inject] private IAutomaticAttacker _automaticAttacker;
        [Inject] private ICommandsQueue _queue;
        public void Tick()
        {
            AutoAttackEvaluator.AttackersInfo.AddOrUpdate(
            gameObject
            , new AutoAttackEvaluator.AttackerParallelnfo(_automaticAttacker.VisionRadius, _queue.CurrentCommand), (go, value) 
            =>
            {
                value.VisionRadius = _automaticAttacker.VisionRadius;
                value.CurrentCommand = _queue.CurrentCommand;
                return value;
            });
        }
        private void OnDestroy()
        {
            AutoAttackEvaluator.AttackersInfo.TryRemove(gameObject, out _);
        }
    }
}