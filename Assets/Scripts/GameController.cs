using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameWinPanel;

    private void Start()
    {
        Time.timeScale = 1;
        gameOverPanel.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void GameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameWin()
    {
        gameWinPanel.gameObject.SetActive(true);
        GameObject.Find("GameController").GetComponent<ScoreManager>().EndScoreText();
        Time.timeScale = 0;
    }

    private void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}