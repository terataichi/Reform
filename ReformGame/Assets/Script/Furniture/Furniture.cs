using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Furuniture
{
    public class Furniture : MonoBehaviour, Player.IHitPlayerRay,Common.PassVec
    {
        /// <summary>
        /// 家具移動量 
        /// </summary>
        private Vector3 movePower_;

        private void Start()
        {
            movePower_ = new Vector3 { };
        }

        public void HitPlayerRay(Player.Player player,ref Vector3 movePower)
        {
            player.SetTarget = this.gameObject;
        }

        public void PassVec(Vector3 vec)
        {
            movePower_ += vec;
        }
    }
}
