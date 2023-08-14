using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player; // Ana karakteriniz
    public GameObject[] bots; // Bot karakterleri
    public Transform finishLine; // Bitiþ çizgisi

    public float minGreenLightTime = 3f;
    public float maxGreenLightTime = 5f;
    public float redLightDuration = 5f;

    public Text gameOverText;
    public Button retryButton;
    public Button mainMenuButton;

    public bool isGreenLightActive = false;
    private bool isPlayerAlive = true;
    private int remainingBots;

    private void Start()
    {
        remainingBots = bots.Length;
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
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
        float greenLightTime = Random.Range(minGreenLightTime, maxGreenLightTime);
        yield return new WaitForSeconds(greenLightTime);
        isGreenLightActive = false;
    }

    private IEnumerator RedLightPhase()
    {
        yield return new WaitForSeconds(redLightDuration);
        if (isPlayerAlive)
        {
            isPlayerAlive = false;
            player.SetActive(false);
        }
    }

    public void PlayerShot()
    {
        if (isGreenLightActive && isPlayerAlive)
        {
            // Handle player shooting during green light
            // You can implement character deaths, bot movements, etc. here
        }
    }

    public void BotDied()
    {
        remainingBots--;
        if (remainingBots <= 0)
        {
            EndGame(true);
        }
    }

    public void PlayerDied()
    {
        EndGame(false);
    }

    private void EndGame(bool isWinner)
    {
        gameOverText.gameObject.SetActive(true);
        if (isWinner)
        {
            gameOverText.text = "You Win!";
        }
        else
        {
            gameOverText.text = "Game Over";
        }
        retryButton.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
    }
}
