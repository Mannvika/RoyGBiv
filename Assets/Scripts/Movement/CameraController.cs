namespace RoyGBiv.Movement
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CameraController : MonoBehaviour
    {
        private PlayerMovement player = null;

        [SerializeField]
        private float offset =  0f;

        void Start() {
            player = FindObjectOfType<PlayerMovement>();
        }

        void LateUpdate() {

            this.transform.position = new Vector3(player.transform.position.x - offset, transform.position.y, - 10);
        }
    }

}