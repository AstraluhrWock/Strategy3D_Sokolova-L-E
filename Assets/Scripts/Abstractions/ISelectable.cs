using UnityEngine;
//using Utils;

namespace Abstractions
{
    public interface ISelectable //: IHealthHolder
    {
        float Health { get; }
        float MaxHealth { get; }
        Sprite Icon { get; }
    }
}
