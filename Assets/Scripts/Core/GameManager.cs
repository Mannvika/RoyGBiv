namespace RoyGBiv.Core
{
    using UnityEngine;
    using TMPro;
    using UnityEngine.SceneManagement;

    public class GameManager : MonoBehaviour
    {
        [HideInInspector]
        public float currentScore = 0f;
        private float highScore = 0f;

        [SerializeField]
        private TMP_Text currentScoreText = null;

        [SerializeField]
        private TMP_Text highScoreText = null;

        [SerializeField]
        private TMP_Text finalScoreText = null;

        [SerializeField]
        private GameObject deathPanel = null;

        private void Start()
        {
            highScoreText.text = "High Score: " + highScore.ToString("0.0");
        }

        private void Update()
        {
            currentScoreText.text = "Current Score: " + currentScore.ToString("0.0");
            finalScoreText.text = currentScore.ToString("0.0");
            if (currentScore >= highScore) {
                highScoreText.text = "High Score: " + currentScore.ToString("0.0");
            }

        }

        public void Die() 
        {
            Time.timeScale = 0;
            deathPanel.SetActive(true);
        }

        public void RestartGame()
        {
            if(currentScore > highScore)
            {
                highScore = currentScore;
            }
            deathPanel.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
            highScoreText.text = "High Score: " + highScore.ToString("0.0");
        }
    }
}
