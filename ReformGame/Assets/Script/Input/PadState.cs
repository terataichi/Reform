using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameInput
{
    public class PadState : InputState
    {
        // Unityから入力関係もらうときのstring格納場所
        private Dictionary<INPUT_ID, String> inputNameList_ = new Dictionary<INPUT_ID, String>();

        public void Start()
        {
            inputNameList_[INPUT_ID.MARU] = "Button2";
            inputNameList_[INPUT_ID.BATU] = "Button1";
            inputNameList_[INPUT_ID.SANKAKU] = "Button3";
            inputNameList_[INPUT_ID.SIKAKU] = "Button4";
        }

        public override void InputUpdate()
        {
            foreach (INPUT_ID id in Enum.GetValues(typeof(INPUT_ID)))
            {
                var tmpOld = inputList_[id].now;
                inputList_[id] = (Input.GetButton(inputNameList_[id]), tmpOld);
            }
            Vector2 tempAngle = analogInputL_.now;
            analogInputL_ = (new Vector2(Input.GetAxis("LStickLR"), Input.GetAxis("LStickUD")), tempAngle);
            tempAngle = analogInputR_.now;
            analogInputR_ = (new Vector2(Input.GetAxis("RStickLR"), Input.GetAxis("RStickUD")), tempAngle);
        }
    }
}
