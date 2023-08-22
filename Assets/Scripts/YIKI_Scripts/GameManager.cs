using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public GameObject player; // Ana karakteriniz
    public GameObject[] bots; // Bot karakterleri
    public Transform finishLine; // Bitiþ çizgisi
    public PlayerController playerController;
    public BotController botController;
    public GameObject gameover;
    //public GameObject deadbody;

    public float minGreenLightTime = 3f;
    public float maxGreenLightTime = 5f;
    public float redLightDuration = 5f;


    public bool isGreenLightActive = false;
    private bool isPlayerAlive = true;
    private int remainingBots;

    private void Start()
    {
        remainingBots = bots.Length;

        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {
        while (true)
        {
            yield return StartCoroutine(GreenLightPhase());
            yield return StartCoroutine(RedLightPhase());
        }
    }

    private IEnumerator GreenLightPhase()
    {
        isGreenLightActive = true;
        Debug.Log("yeþil ýþýk");
        float greenLightTime = Random.Range(minGreenLightTime, maxGreenLightTime);
        yield return new WaitForSeconds(greenLightTime);
        isGreenLightActive = false;
    }

    private IEnumerator RedLightPhase()
    {
        Debug.Log("kýrmýzý ýþýk");
        yield return new WaitForSeconds(redLightDuration);

        if (isPlayerAlive && playerController != null && playerController.isMoving)
        {
            Debug.Log("öldün");
            PlayerDied();
        }
    }
    public void BotDied()
    {
        Debug.Log("bot öldü");
        remainingBots--;
        if (remainingBots <= 0)
        {
            EndGame(true);
        }

    }
    private void EndGame(bool isWinner)
    {
        // Oyunu sonlandýrma iþlemleri burada gerçekleþtirilebilir.
        Debug.Log(isWinner ? "You Win!" : "Game Over");
        Time.timeScale = 0;
    }
    public void GameOver()
    {
        player.SetActive(false);
        //deadbody.SetActive(true);
        gameover.SetActive(true);

        //Time.timeScale = 0;
    }
    public void PlayerDied()
    {
        Debug.Log("Oyuncu Öldü");
        GameOver();
        //isPlayerAlive = false;


         player.SetActive(false);
        // Burada yapýlmasý gereken ölüm ile ilgili iþlemleri gerçekleþtirebilirsiniz.
        // Örneðin, oyun sonu ekranýný göstermek veya tekrar baþlatma seçenekleri gibi.
    }
}
