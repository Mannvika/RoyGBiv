namespace RoyGBiv.Networking {

    using UnityEngine;
    using UnityEngine.UI; 
    using System.Net.Sockets;
	using System;

	public class NetworkManager : MonoBehaviour
    {
        [SerializeField]
        Boolean isTestMode = true; 

        TcpClient client = null;

        NetworkStream stream = null;

        private void Start() {
            if (!isTestMode) {
                ConnectToServer();
            }
        }

        private void ConnectToServer() {
            try {
                client = new TcpClient("192.168.1.195", 8080);

                stream = client.GetStream();

                Debug.Log("Connected!");

            }
            catch (ArgumentNullException e) {
                Debug.Log("ArgumentNullException: " + e);
            }
            catch (SocketException e) {
                Debug.Log("SocketException: " + e);

            }
        }

        public void Send(string message) {
            Debug.Log("Sending " + message);

            if (!isTestMode) {
                try {
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                    stream.Write(data, 0, data.Length);

                    Debug.Log("Sent: " + message);

                    data = new Byte[256];

                }
                catch (ArgumentNullException e) {
                    Debug.Log("ArgumentNullException: " + e);
                }
                catch (SocketException e) {
                    Debug.Log("SocketException: " + e);
                }
            }
        }

        public void SendColors(float r, float g, float b) {
            Debug.Log("R: " + r + "G: " + g + "B: " + b);

             string rgb = "R" + r + "G" + g + "B" + b;
             Send(rgb);
        }

        private void TCPClose() {
            if (client != null && stream != null) {
                stream.Close();
                client.Close();

                Debug.Log("Closed client");
            }
        }

        private void OnDisable() {
            if (!isTestMode) {
                TCPClose();
            }  
        }
    }
}