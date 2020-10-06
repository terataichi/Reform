using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class TargetRay : MonoBehaviour
    {
        [SerializeField] private Material mate;

        private Player player_;
        private Ray ray_;
        private RaycastHit hitObj_;
        private GameObject line = null;
        private LineRenderer lRend = null;


        public void Start()
        {
            // とりあえずわかりやすくRay表示してみようか感
            line = new GameObject("Line");
            lRend = line.AddComponent<LineRenderer>();
            lRend.positionCount = 2;
            lRend.startWidth = 0.1f;
            lRend.material = mate;
            lRend.startColor = Color.white;
            lRend.endColor = Color.white;
            lRend.endWidth = 0.1f;

            player_ = this.gameObject.GetComponent<Player>();
        }

        public void RayUpdete()
        {
            ray_ = new Ray(this.gameObject.transform.position, this.gameObject.transform.forward);
            if(Physics.Raycast(ray_, out hitObj_, player_.RayRenge))
            {
                var hitObj = hitObj_.collider.gameObject.GetComponent<IHitPlayerRay>();
                if (hitObj != null) 
                {
                    hitObj.HitPlayerRay(player_);
                }
            }
            else
            {
                player_.SetTarget = null;
            }
            Vector3 startVec = player_.transform.forward + player_.transform.position;
            Vector3 endVec = player_.transform.forward * player_.RayRenge + player_.transform.position;
            lRend.SetPosition(0, startVec);
            lRend.SetPosition(1, endVec);
            line.transform.SetParent(player_.transform);
        }
    }
}
