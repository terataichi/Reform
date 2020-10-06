using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Furuniture
{
    public class Furniture : MonoBehaviour, Player.IHitPlayer
    {
        public void HitPlayerRay(Player.Player player)
        {
            player.SetTarget = this.gameObject;
        }
    }
}
