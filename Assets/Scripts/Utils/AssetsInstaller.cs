//using UnityEngine;
//using Zenject;
//using Utils;
//using UserControlSystem;
//using UI.Model;


//[CreateAssetMenu(fileName = "AssetsInstaller", menuName = "Installers/AssetsInstaller")]
//public class AssetsInstaller : ScriptableObjectInstaller<AssetsInstaller>
//{
//    [SerializeField] private AssetsContext _legacyContext;
//    [SerializeField] private Vector3Value _groundClicksRMB;
//    [SerializeField] private AttackableValue _attackableClicksRMB;
//    [SerializeField] private SelectableValue _selectables;
//    public override void InstallBindings()
//    {
//        Container.Bind<IAwaitable<IAttackable>>().FromInstance(_attackableClicksRMB);
//        Container.Bind<IAwaitable<Vector3>>().FromInstance(_groundClicksRMB);
//        Container.BindInstances(_legacyContext, _selectables);
//        Container.Bind<Sprite>().WithId("Chomper").FromInstance(_chomperSprite);
//        Container.Bind<IObservable<ISelecatable>>().FromInstance(_selectables);
//    }
//}