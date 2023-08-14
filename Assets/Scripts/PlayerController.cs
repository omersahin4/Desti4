using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameManager gameManager;

    private bool isRunning = false;

    private void Update()
    {
        if (gameManager.isGreenLightActive)
        {
            HandleMovement();
        }
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 movement = new Vector3(-1f, 0f, 0f) * moveSpeed * Time.deltaTime;
            transform.Translate(movement);
        }
    }

    public void Die()
    {
        // Handle player death, animations, etc.
        gameManager.PlayerDied();
    }
}
