using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExplodyBlocks.Assets.Scripts
{
    public class InputManager : MonoBehaviour
    {
        private bool moveLeft;
        private bool moveRight;
        // Update is called once per frame
        void Update()
        {

            if (Input.GetKey("d") || Input.GetKey("right"))
            {
               moveRight = true;
            }

            if (Input.GetKey("a") || Input.GetKey("left"))
            {
                moveLeft = true;
            }
        }

        public bool getMoveLeft() {
            bool temp = moveLeft;
            moveLeft = false;
            return temp;
        }

        public bool getMoveRight()
        {
            bool temp = moveRight;
            moveRight = false;
            return temp;
        }
    }
}
