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
        ///  ものを持てる距離　1以下だとPlayer内部にめり込んでる扱いのため持てなくなる　1以上にしよう
        /// </summary>
        [SerializeField] private float handRenge_ = 0;
        /// <summary>
        /// Target決めるときのRayの届く距離
        /// </summary>
        [SerializeField] private float rayRenge_ = 0;
        /// <summary>
        /// どのコントローラーかの識別用 デバックしやすいように今SerializeFieldなだけ 1～4
        /// </summary>
        [SerializeField] private int padNum_ = 1;

        /// <summary>
        /// Unityinput用buttonName格納先
        /// </summary>
        private Dictionary<int, Dictionary<INPUT_ID, String>> inputNameList_ = new Dictionary<int, Dictionary<INPUT_ID, String>>();



        /// <summary>
        /// Rayで取得した家具 Nullじゃなければ何かしらをTargetにしている
        /// </summary>
        private GameObject targetFurniture_ = null;

        /// <summary>
        /// 状態コントロール用enum
        /// </summary>
        private PLAYERSTATE state_;

        public PLAYERSTATE State
        {
            set { state_ = value; }
        }

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
        /// <summary>
        /// 現在コントローラー用のStringを設定しているがこのままだとPlayerの数だけ作られてしまうため
        /// 外部に逃がしてpadNum_に応じてデータをもらう方が無駄がなさそう
        /// 変更予定
        /// </summary>
        public void Start()
        {
            state_ = PLAYERSTATE.STAY;
                for (int i = 1; i <= 4; i++)
            {
                inputNameList_.Add(i, new Dictionary<INPUT_ID, String>());
                inputNameList_[i].Add(INPUT_ID.B,"C" + i + "ButtonB");
                inputNameList_[i].Add(INPUT_ID.A, "C" + i + "ButtonA");
                inputNameList_[i].Add(INPUT_ID.X, "C" + i + "ButtonX");
                inputNameList_[i].Add(INPUT_ID.Y, "C" + i + "ButtonY");
                inputNameList_[i].Add(INPUT_ID.LSTICK_X,"C" + i + "LStickX");
                inputNameList_[i].Add(INPUT_ID.LSTICK_Y, "C" + i + "LStickY");
                inputNameList_[i].Add(INPUT_ID.RSTICK_X, "C" + i + "RStickY");
                inputNameList_[i].Add(INPUT_ID.RSTICK_Y, "C" + i + "RStickX");
            }
        }
        // Update is called once per frame
        void Update()
        {
            mover_.MoveUpdate(inputNameList_[padNum_],mainCamera_);
            targetRay_.RayUpdete(ref mover_.MovePower);
            holdMng_.HoldUpdate(Input.GetButtonDown(inputNameList_[padNum_][INPUT_ID.B]));

            if (targetFurniture_ != null)
            {
                if (Input.GetButtonDown(inputNameList_[padNum_][INPUT_ID.A]))
                {
                    targetFurniture_.transform.SetParent(null);
                }
            }
            gameObject.GetComponent<Animator>().SetInteger("state", (int)state_);
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
