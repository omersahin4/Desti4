using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DalgonaGame : MonoBehaviour
{
    public float gameDuration = 10f;
    public int minTapsToWin = 8;
    public int maxTapsToWin = 10;
    public GameObject winScreen;         // Kazandý ekraný
    public GameObject gameOverScreen;    // Oyun bitti ekraný
    public GameObject youwin;
    public GameObject krakerPrefab;      // Kraker objesinin prefabý
    public Transform spawnPoint;
    public GameObject retrybutton;
    public GameObject dalgona_tutorial;
    private bool isGameRunning = false;
    private int taps = 0;

    private void Start()
    {
        Time.timeScale = 0f;
       
    }

    private void Update()
    {
        if (!isGameRunning && Input.GetMouseButtonUp(0))
        {
            Time.timeScale = 1f;
            dalgona_tutorial.SetActive(false);
            SpawnKraker();
            StartGame();
        }

        if (isGameRunning)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("týklandý");
                taps++;
            }
        }
    }

    private void StartGame()
    {
        isGameRunning = true;
        StartCoroutine(EndGameAfterDuration());
    }

    private IEnumerator EndGameAfterDuration()
    {
        Debug.Log("TT");
        yield return new WaitForSeconds(gameDuration);
        Debug.Log("RR");
        isGameRunning = false;
        EndGame();
    }

    private void EndGame()
    {
        if (taps >= minTapsToWin && taps <= maxTapsToWin)
        {
            youwin.SetActive(true);
            Debug.Log("Kazandýnýz!");
            winScreen.SetActive(true);
        }
        else
        {
            Debug.Log("Kaybettiniz.");
            gameOverScreen.SetActive(true);
            retrybutton.SetActive(true);
        }
    }
    private void SpawnKraker()
    {
        krakerPrefab.SetActive(true);  // Kraker prefabýný görünür yap
        Instantiate(krakerPrefab, spawnPoint.position, Quaternion.identity);
    }
}

