using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public interface IHitPlayerRay
    {
        void HitPlayerRay(Player player,ref Vector3 movePower);
    }
}
