using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public enum PLAYERSTATE
    {
        STAY,           // 待機
        RUN,            // 走り
        HOLD,           // 持つ
        PULL,           // 引く
        INQUIRE,        // 引き合う
        PUSH            // 押す
    }
}
