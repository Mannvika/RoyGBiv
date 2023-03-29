namespace RoyGBiv.Movement
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CameraController : MonoBehaviour
    {
        private PlayerMovement player = null;

        [SerializeField]
        private Vector3 offset =  Vector3.zero;

        void Start() {
            player = FindObjectOfType<PlayerMovement>();
        }

        void LateUpdate() {

            this.transform.position = player.transform.position - offset;
        }
    }

}