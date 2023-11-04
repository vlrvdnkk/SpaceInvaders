using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject playerBulletPrefab;
    [SerializeField] private float shotCooldown = 0.5f;
    [SerializeField] private Transform firePoint;

    private float shotTimer = 0.0f;

    private void Update()
    {
        shotTimer -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && shotTimer <= 0)
        {
            Shoot();
            shotTimer = shotCooldown;
        }
    }

    private void Shoot()
    {
        Vector3 bulletPosition = firePoint.position;
        GameObject bullet = Instantiate(playerBulletPrefab, bulletPosition, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(0, 10);

        Destroy(bullet, 2.0f);
    }
}