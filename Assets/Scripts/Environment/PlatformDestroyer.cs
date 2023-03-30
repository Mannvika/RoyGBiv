namespace RoyGBiv.Environment {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlatformDestroyer : MonoBehaviour
    {
        public GameObject platformDestructionPoint = null;

        private void Start() {
            platformDestructionPoint = GameObject.Find("Platform Destruction Point");    
        }
        void Update() {
            if(transform.position.x < platformDestructionPoint.transform.position.x) {
                gameObject.SetActive(false);
            }
        }
    }
}
