namespace RoyGBiv.Networking {

    using UnityEngine;
    using UnityEngine.UI; 
    using System.Net.Sockets;
	using System;

	public class NetworkManager : MonoBehaviour
    {

        [SerializeField]
        InputField REDInputField = null;
        [SerializeField]
        InputField GREENInputField = null;
        [SerializeField]
        InputField BLUEInputField = null;

        TcpClient client = null;

        NetworkStream stream = null;

        private void Awake()
        {
            ConnectToServer();
        }

        private void ConnectToServer()
        {
            try
            {
                client = new TcpClient("192.168.1.195", 8080);

                stream = client.GetStream();

                Debug.Log("Connected!");

            }
            catch (ArgumentNullException e)
            {
                Debug.Log("ArgumentNullException: " + e);
            }
            catch (SocketException e)
            {
                Debug.Log("SocketException: " + e);

            }
        }

        /*public void Send() {
            try
            {
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(inputField.text);

                stream.Write(data, 0, data.Length);

                Debug.Log("Sent: " + inputField.text);

                data = new Byte[256];

            }
            catch (ArgumentNullException e)
            {
                Debug.Log("ArgumentNullException: " + e);
            }
            catch (SocketException e) {
                Debug.Log("SocketException: " + e);
            }
        }*/

        public void SendColors() {

            Debug.Log(REDInputField.text.ToString() + " as int: " + Int32.Parse(REDInputField.text.ToString()));
            Debug.Log(GREENInputField.text.ToString() + " as int: " + Int32.Parse(GREENInputField.text.ToString()));
            Debug.Log(BLUEInputField.text.ToString() + " as int: " + Int32.Parse(BLUEInputField.text.ToString()));

            int r = Int32.Parse(REDInputField.text.ToString());
            int g = Int32.Parse(GREENInputField.text.ToString());
            int b = Int32.Parse(BLUEInputField.text.ToString());

            Debug.Log("R: " + r + "G: " + g + "B: " + b);

            string rgb = "R" + r + "G" + g + "B" + b;
            try
            {
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(rgb);

                stream.Write(data, 0, data.Length);

                Debug.Log("Sent: " + rgb);

                data = new Byte[256];

            }
            catch (ArgumentNullException e)
            {
                Debug.Log("ArgumentNullException: " + e);
            }
            catch (SocketException e)
            {
                Debug.Log("SocketException: " + e);
            }
        }

        private void TCPClose() {
            if (client != null && stream != null){
                stream.Close();
                client.Close();

                Debug.Log("Closed client");
            }
        }

        private void OnDisable()
        {
            TCPClose();
        }
    }
}