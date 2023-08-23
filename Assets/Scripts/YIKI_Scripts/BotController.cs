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
    [SerializeField] private int currenChanceValue;
    public float moveSpeed = 3f;
    public GameManager gameManager;
    public Animator animator;
   
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (gameManager.isGreenLightActive)
        {
            MoveLeft();
            once = false;
        }
        else
        {
            if(once == false)
            {
                currenChanceValue = Random.Range(1, 9);
                once = true;
            }
            if (chance > currenChanceValue)
            {
                Speed = 1f;
                //animator.SetFloat("Speed", Speed);
                MoveLeft();
                
            }
            else
            {
                isMoving = false;
                Speed = 0f;
                //animator.SetFloat("Speed", Speed);
            }
        }
        if(gameManager.redLightActive==true && isMoving == true)
        {
            Debug.Log("bot öldü");
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
        // Bot ölümü ile ilgili iþlemleri burada yapabilirsiniz
        gameManager.BotDied();
        Debug.log("hamood");
        // gameObject.SetActive(false);
    }

}
