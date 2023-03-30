namespace RoyGBiv.Utility
{
    using UnityEngine;

    public class DontDestroyOnLoad : MonoBehaviour
    {
        private static DontDestroyOnLoad instance = null;
        private void Awake()
        {
            if(instance != null) {
                Destroy(gameObject);
            }
            else {
                instance = this;
            }

            DontDestroyOnLoad(gameObject);
        }
    }

}