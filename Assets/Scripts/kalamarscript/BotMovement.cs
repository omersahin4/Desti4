using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovement : MonoBehaviour
{
    public GameObject oyuncu; // Oyuncu GameObject'i

    public float moveSpeed = 3f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (oyuncu != null)
        {
            Vector3 direction = oyuncu.transform.position - transform.position;
            direction.Normalize();

            // Botun yatay ve dikey hareketini hesapla
            float moveX = direction.x * moveSpeed;
            float moveY = direction.y * moveSpeed;

            // Botun Rigidbody'sini güncelle
            rb.velocity = new Vector2(moveX, moveY);
        }
    }
}
