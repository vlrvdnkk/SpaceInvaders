using UnityEngine;

public class MobController : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3; // ������������ ���������� ���������, ����� ���������� ���
    [SerializeField] private int scoreValue = 10; // ���������� ����� �� ����������� ����
    [SerializeField] private ScoreManager scoreManager;
    private int currentHealth; // ������� �������� ����

    private void Start()
    {
        currentHealth = maxHealth; // �������������� �������� ����
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage();
            Destroy(collision.gameObject); // ���������� ���� ����� ���������
        }
    }

    // ����� ��� ��������� ��������� ����
    private void TakeDamage()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ����� ���������� ��� ����������� ����
    private void Die()
    {
        scoreManager.AddScore(scoreValue); // ����������� ����
        Destroy(gameObject); // ���������� ���
    }
}