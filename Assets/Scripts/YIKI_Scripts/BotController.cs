using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BotController : MonoBehaviour
{

    [Range(1, 8), SerializeField] private int chance;
    private bool once = false;
    public float Speed = 0f;
    public bool isMoving = false;
    [SerializeField] private int currentChanceValue;
    public float moveSpeed = 3f;
    public GameManager gameManager;
    public Animator animator;

    private bool isDead = false; // Yeni eklendi

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isDead) // Yeni eklendi
        {
            return; // Yeni eklendi, ölü botlar hareket etmeyecek
        }

        if (gameManager.isGreenLightActive)
        {
            MoveLeft();
            Speed = 1f;
            animator.SetFloat("Speed", Speed);
            once = false;
        }
        else
        {
            if (once == false)
            {
                currentChanceValue = Random.Range(1, 9);
                once = true;
            }
            if (chance > currentChanceValue)
            {
                Speed = 1f;
                animator.SetFloat("Speed", Speed);
                MoveLeft();
            }
            else
            {
                isMoving = false;
                Speed = 0f;
                animator.SetFloat("Speed", Speed);
            }
        }
        if (gameManager.redLightActive == true && isMoving == true)
        {
            Die();
        }
    }

    private void MoveLeft()
    {
        isMoving = true;
        Vector3 movement = Vector3.left * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    public void Die()
    {
        if (!isDead) // Yeni eklendi
        {
            isDead = true; // Yeni eklendi, botun öldüðünü iþaretler
            gameObject.SetActive(false); 
            // Bot ölümü ile ilgili iþlemleri burada yapabilirsiniz
            gameManager.BotDied();
        }
    }

}
