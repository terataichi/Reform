using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameInput
{
    public abstract class InputState : MonoBehaviour
    {
        protected Dictionary<INPUT_ID, (bool now, bool old)> inputList_ = new Dictionary<INPUT_ID, (bool, bool)>();     // INPUT_IDに対応した、ボタン押下格納先
        protected (Vector2 now, Vector2 old) analogInputL_;              // 左スティックの入力状態  
        protected (Vector2 now, Vector2 old) analogInputR_;              // 右スティックの入力状態 

        public InputState()
        {
            foreach (INPUT_ID id in Enum.GetValues(typeof(INPUT_ID)))
            {
                inputList_[id] = (false, false);
            }
        }
        /// <summary>
        /// インプット更新用　継承先でやる
        /// </summary>
        public abstract void InputUpdate();

        /// <summary>
        /// 押した瞬間true
        /// </summary>
        /// <param name="id">欲しいキーのID</param>
        public bool GetKeyTrgDown(INPUT_ID id)
        {
            return inputList_[id].now && !inputList_[id].old;
        }
        /// <summary>
        /// 押してるあいだtrue
        /// </summary>
        /// <param name="id">欲しいキーのID</param>
        public bool GetKeyHold(INPUT_ID id)
        {
            return inputList_[id].now && inputList_[id].old;
        }
        /// <summary>
        /// 離した瞬間true
        /// </summary>
        /// <param name="id">欲しいキーのID</param>
        public bool GetKeyTrgUp(INPUT_ID id)
        {
            return !inputList_[id].now && inputList_[id].old;
        }
        /// <summary>
        /// 右スティック状況獲得
        /// </summary>
        /// <returns>now：現在　old：1フレーム前</returns>
        public (Vector2 now, Vector2 old) GetRStickInput()
        {
            return analogInputR_;
        }
        /// <summary>
        /// 左スティック状況獲得
        /// </summary>
        /// <returns>now：現在　old：1フレーム前</returns>
        public (Vector2 now, Vector2 old) GetLStickInput()
        {
            return analogInputL_;
        }
    }
}
