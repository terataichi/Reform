using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public interface PassVec
    {
        /// <summary>
        /// 他のオブジェクトからVector2を受け取るとき用
        /// </summary>
        /// <param name="vec">渡したいvec</param>
        void PassVec(Vector3 vec);
    }
}