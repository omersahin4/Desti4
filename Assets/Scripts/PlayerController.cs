using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameManager gameManager;

    private bool isMoving = false;  // Bu deðiþken hareket durumunu kontrol etmek için kullanýlýr.

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Space tuþuna basýldýðýnda sola doðru hareket baþlar.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = true;
        }
        // Space tuþu býrakýldýðýnda hareket durur.
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isMoving = false;
        }

        if (isMoving)
        {
            // Sola doðru hareket için yatay eksende -1 kullanýlýr.
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
