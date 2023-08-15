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
            isPlayerAlive = false;
            player.SetActive(false);
        }
    }    

}
