using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInput;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private InputState input_ = null;
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            input_.InputUpdate();
        }
    }
}
