using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameManager gameManager;
    public float Speed = 0f;
    public bool isMoving = false;  // Bu deðiþken hareket durumunu kontrol etmek için kullanýlýr.
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
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
            Speed = 1f;
            animator.SetFloat("Speed", Speed);
        }
        // Space tuþu býrakýldýðýnda hareket durur.
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isMoving = false;
            Speed = 0f;
            animator.SetFloat("Speed", Speed);  // Animator'daki "Speed" parametresini güncelle
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
        // Oyuncunun ölüm iþlemleri burada gerçekleþtirilir.
        // Örneðin, animasyonlar, ses efektleri, oyun sonu iþlemleri vb.
        gameManager.PlayerDied();
        gameObject.SetActive(false);
    }
}
