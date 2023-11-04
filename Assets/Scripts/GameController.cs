using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private bool isGameOver = false;

    //[SerializeField] private Text gameOverText;

    private void Start()
    {
        //gameOverText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mob") && !isGameOver)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        //isGameOver = true;
        //// Отображаем сообщение о проигрыше
        //gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}