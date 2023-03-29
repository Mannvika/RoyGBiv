namespace RoyGBiv.Core {

    using UnityEngine;
    using UnityEngine.Rendering.Universal;
    using RoyGBiv.Networking;

    public class ColorChanger : MonoBehaviour
    {
        private SpriteRenderer player = null;
        private NetworkManager networkManager = null;
        private void Awake()
        {
            player = GetComponent<SpriteRenderer>();
            networkManager = FindObjectOfType<NetworkManager>();
        }
        public void ChangeColor(float r, float g, float b) {
            player.color = new Color(r, g, b, 1f);
            player.GetComponentInChildren<Light2D>().color = new Color(r, g, b, 0.85f);
            //networkManager.SendColors((int)r*255, (int)g *255, (int)b *255);
        }
    }
}