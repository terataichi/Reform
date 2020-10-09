using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInput;

namespace Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] float moveSpeed_;
        [SerializeField] float spinSpeed_;

        CharacterController controller_;

        private Transform transform_;
        private Vector3 movePower_;

        public ref Vector3 MovePower
        {
            get { return ref movePower_; }
        }

        // Start is called before the first frame update
        void Start()
        {
            transform_ = transform;
            controller_ = GetComponent<CharacterController>();
            movePower_ = new Vector3 { };
        }

        public void MoveUpdate(InputState input,GameObject camera)
        {
            movePower_.x = input.GetLStickInput().now.x * moveSpeed_;
            movePower_.z = input.GetLStickInput().now.y * moveSpeed_;

            movePower_ = Quaternion.Euler(0, camera.transform.localEulerAngles.y, 0) * movePower_;

            var tmpPower = new Vector3(movePower_.x, 0, movePower_.z);

            if (tmpPower.magnitude > 0.01f) 
            {
                var rotation = Quaternion.LookRotation(tmpPower);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * spinSpeed_);
            }

            controller_.Move(movePower_*Time.deltaTime);
        }
    }
}
