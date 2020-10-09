using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Furuniture
{
    public class Furniture : MonoBehaviour, Player.IHitPlayerRay
    {

        private Vector3 movePower_;


        private void Start()
        {
            movePower_ = new Vector3 { };
        }

        private void LateUpdate()
        {
            //transform.position = movePower_;
            //movePower_ = new Vector3 { };
        }

        public void HitPlayerRay(Player.Player player,ref Vector3 movePower)
        {
            //movePower_ += movePower;
            player.SetTarget = this.gameObject;
        }
    }
}
