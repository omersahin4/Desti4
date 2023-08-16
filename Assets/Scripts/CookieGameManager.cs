using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieGameManager : MonoBehaviour
{
    public GameObject[] sliceableObjects; // Farklý görsellerin listesi
    public Transform spawnPoint; // Görselin spawn konumu
    public GameObject gameOverScreen; // Oyun bitti ekraný

    private bool gameOver = false;

    void Start()
    {
        SpawnSliceableObject();
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverScreen.SetActive(true);
    }

    void SpawnSliceableObject()
    {
        int randomIndex = Random.Range(0, sliceableObjects.Length);
        Instantiate(sliceableObjects[randomIndex], spawnPoint.position, Quaternion.identity);
    }
}
