using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public GameManager gameManager;

    private void Update()
    {
        if (gameManager.isGreenLightActive)
        {
            MoveLeft();
        }
    }

    private void MoveLeft()
    {
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
