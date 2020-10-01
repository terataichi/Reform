using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInput;

namespace Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] float speed_;

        CharacterController controller_;

        private Transform transform_;

        // Start is called before the first frame update
        void Start()
        {
            transform_ = transform;
            controller_ = GetComponent<CharacterController>();
        }

        void MoveUpdate(InputState input)
        {

        }
    }
}
