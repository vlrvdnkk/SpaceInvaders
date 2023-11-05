using UnityEngine;

public class MobController : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3; // Максимальное количество попаданий, чтобы уничтожить моб
    [SerializeField] private int scoreValue = 10; // Количество очков за уничтожение моба
    [SerializeField] private ScoreManager scoreManager;
    private int currentHealth; // Текущее здоровье моба

    private void Start()
    {
        currentHealth = maxHealth; // Инициализируем здоровье моба
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage();
            Destroy(collision.gameObject); // Уничтожаем пулю после попадания
        }
    }

    // Метод для обработки попадания пули
    private void TakeDamage()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Метод вызывается при уничтожении моба
    private void Die()
    {
        scoreManager.AddScore(scoreValue); // Увеличиваем счет
        Destroy(gameObject); // Уничтожаем моб
    }
}