using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GameInput;


namespace Player
{
    public class Player : MonoBehaviour
    {
        /// <summary>
        /// 入力関係
        /// </summary>
        [SerializeField] private InputState input_ = null;
        /// <summary>
        ///  Player実際に動かしてるやつ CharCon使用
        /// </summary>
        [SerializeField] private PlayerMover mover_ = null;
        /// <summary>
        /// Target決めるためのレイ発射スクリプト 名前募集中
        /// </summary>
        [SerializeField] private TargetRay targetRay_ = null;
        /// <summary>
        /// つかむ管理コンポーネント いらんかもな
        /// </summary>
        [SerializeField] private HoldFurniture holdMng_ = null;
        /// <summary>
        /// メインのカメラ 移動方向指定に使う
        /// </summary>
        [SerializeField] private GameObject mainCamera_ = null;
        /// <summary>
        ///  ものを持てる距離
        /// </summary>
        [SerializeField] private float handRenge_ = 0;
        /// <summary>
        /// Target決めるときのRayの届く距離
        /// </summary>
        [SerializeField] private float rayRenge_ = 0;



        /// <summary>
        /// Rayで取得した家具 Nullじゃなければ何かしらをTargetにしている
        /// </summary>
        private GameObject targetFurniture_ = null;

        public float HandRenge 
        {
            get { return handRenge_; } 
        }

        public float RayRenge
        {
            get { return rayRenge_; }
        }

        public GameObject Target
        {
            get { return targetFurniture_; }
        }

        /// <summary>
        /// Target家具指定用プロパティ
        /// </summary>
        public GameObject SetTarget
        {
            set 
            {
                if (value != null) 
                {
                    Debug.Log("ターゲット設定");
                }
                targetFurniture_ = value; 
            }
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            input_.InputUpdate();
            mover_.MoveUpdate(input_, mainCamera_);
            targetRay_.RayUpdete();
            holdMng_.HoldUpdate(input_.GetKeyTrgDown(INPUT_ID.MARU));

            if (targetFurniture_ != null)
            {
                if (input_.GetKeyTrgDown(INPUT_ID.BATU))
                {
                    targetFurniture_.transform.SetParent(null);
                }
            }
        }
        /// <summary>
        /// 上から見たときPlayerのHandRange内にTargetになっている家具があるかどうか
        /// </summary>
        /// <returns>　true:ある　false:ない</returns>
        public bool TargetRange()
        {
            if (targetFurniture_ == null) 
            {
                return false;
            }
            // 上から見た時のtargetFurniture_とPlayerの距離
            var tmpVec = targetFurniture_.transform.position - this.gameObject.transform.position;
            var renge = tmpVec.z * tmpVec.z + tmpVec.x * tmpVec.x;

            Math.Sqrt(renge);

            return renge < handRenge_;
        }
    }
}
