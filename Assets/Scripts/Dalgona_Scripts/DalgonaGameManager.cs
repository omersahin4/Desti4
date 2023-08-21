using UnityEngine;

public class DalgonaGameController : MonoBehaviour
{
    public GameObject krakerPrefab;      // Kraker objesinin prefabý
    public Transform spawnPoint;         // Krakerin doðduðu nokta
    public float clickInterval = 1.0f;    // Týklama aralýðý (saniye)
    public int maxClicks = 10;           // Maksimum týklama sayýsý
    public GameObject winScreen;         // Kazandý ekraný
    public GameObject gameOverScreen;    // Oyun bitti ekraný

    private int clickCount = 0;
    private float lastClickTime;
    private bool isGameActive = true;

    private void Update()
    {
        if (!isGameActive)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }
    }

    private void HandleClick()
    {
        if (clickCount < maxClicks && Time.time - lastClickTime >= clickInterval)
        {
            lastClickTime = Time.time;
            clickCount++;

            if (clickCount >= maxClicks)
            {
                WinGame();
            }
        }
        else
        {
            ResetClickCount();
        }
    }

    private void ResetClickCount()
    {
        clickCount = 0;
    }

    private void WinGame()
    {
        isGameActive = false;
        winScreen.SetActive(true);
    }

    private void EndGame()
    {
        isGameActive = false;
        gameOverScreen.SetActive(true);
    }
}
