using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{

    [Range(1, 5), SerializeField] private int chance;
    private bool once = false;
    public bool isMoving = false;
    [SerializeField] private int currenChanceValue;
    public float moveSpeed = 3f;
    public GameManager gameManager;

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
                currenChanceValue = Random.Range(1, 6);
                once = true;
            }
            if (chance > currenChanceValue)
            {
                MoveLeft();
            }
            else
            {
                isMoving = false;
            }
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
        gameObject.SetActive(false);
    }

}
