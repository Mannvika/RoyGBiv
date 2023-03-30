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

        [SerializeField]
        private float platformWidthMin = 0f;
        [SerializeField]
        private float platformWidthMax = 0f;

        private float minHeight;
        private float maxHeight;
        private float heightChange;

        [SerializeField]
        public Transform maxHeightPoint;
        [SerializeField]
        private float maxHeightChange = 0;

        private float distanceBetween = 0f;
        
        private float platformWidth = 0f;

        private ObjectPooler objectPooler = null;
        
        private void Start() {
            platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
            objectPooler = FindObjectOfType<ObjectPooler>();

            minHeight = transform.position.y;
            maxHeight = maxHeightPoint.position.y;
        }

        private void Update() {
            if(transform.position.x  < generationPoint.position.x) {

                platformWidth = Random.Range(platformWidthMin, platformWidthMax);

                distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

                heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

                if (heightChange > maxHeight) {
                    heightChange = maxHeight;
                }
                else if(heightChange < minHeight){
                    heightChange = minHeight;
                }

                transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, heightChange, transform.position.z);

                int r = Random.Range(0, 256); int g = Random.Range(0, 256); int b = Random.Range(0, 256);

                GameObject newPlatform = objectPooler.GetPooledObject();

                newPlatform.transform.position = transform.position;
                newPlatform.transform.rotation = transform.rotation;
                newPlatform.transform.localScale = new Vector3(platformWidth, platformWidth * 0.125f);

                newPlatform.GetComponent<SpriteRenderer>().color = new Color(r / 255.0f, g / 255.0f, b / 255.0f, 1.0f);
                newPlatform.GetComponentInChildren<Light2D>().color = new Color(r / 255.0f, g / 255.0f, b / 255.0f, 0.7f);

                newPlatform.SetActive(true);
            }
        }
    }
}