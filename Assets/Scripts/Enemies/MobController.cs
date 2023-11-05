using UnityEngine;

public class MobController : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private int scoreValue = 10;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }

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