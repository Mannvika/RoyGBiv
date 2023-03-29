namespace RoyGBiv.Environment {

    using UnityEngine;
    using UnityEngine.Rendering.Universal;

    public class PlatformGenerator : MonoBehaviour
    {
        [SerializeField]
        private GameObject platform = null;
        [SerializeField]
        private Transform generationPoint = null;
        [SerializeField]
        private float distanceBetweenMin = 0f;
        [SerializeField]
        private float distanceBetweenMax = 0f;

        private float distanceBetween = 0f;
        
        private float platformWidth = 0f;
        
        private void Start() {
            platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
        }

        private void Update() {
            if(transform.position.x  < generationPoint.position.x) {

                distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

                transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

                GameObject go = Instantiate(platform, transform.position, Quaternion.identity);

                int r = Random.Range(0, 256); int g = Random.Range(0, 256); int b = Random.Range(0, 256);
                go.GetComponent<SpriteRenderer>().color = new Color(r / 255.0f, g / 255.0f, b / 255.0f, 1.0f);
                go.GetComponentInChildren<Light2D>().color = new Color(r / 255.0f, g / 255.0f, b / 255.0f, 0.7f);
            }
        }
    }
}