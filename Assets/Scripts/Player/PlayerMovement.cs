using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerMovementSpeed = 5.0f;

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 playerPosition = transform.position;

        playerPosition.x += horizontalInput * playerMovementSpeed * Time.deltaTime;
        playerPosition.x = Mathf.Clamp(playerPosition.x, -8.2f, 8.2f);
        transform.position = playerPosition;
    }
}
