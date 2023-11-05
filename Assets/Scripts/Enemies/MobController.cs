using UnityEngine;

public class MobController : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3; // ћаксимальное количество попаданий, чтобы уничтожить моб
    [SerializeField] private int scoreValue = 10; //  оличество очков за уничтожение моба
    private int currentHealth; // “екущее здоровье моба

    private void Start()
    {
        currentHealth = maxHealth; // »нициализируем здоровье моба
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage();
            Destroy(collision.gameObject); // ”ничтожаем пулю после попадани€
        }
    }

    // ћетод дл€ обработки попадани€ пули
    private void TakeDamage()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameObject.Find("GameController").GetComponent<ScoreManager>().AddScore(scoreValue);
        Destroy(gameObject);
    }
}