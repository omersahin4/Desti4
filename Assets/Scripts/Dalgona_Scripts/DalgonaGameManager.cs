using UnityEngine;

public class DalgonaGameController : MonoBehaviour
{
    public GameObject krakerPrefab;      // Kraker objesinin prefabý
    public Transform spawnPoint;         // Krakerin doðduðu nokta
    public float clickInterval = 5.0f;    // Týklama aralýðý (saniye)
    public int maxClicks = 100;           // Maksimum týklama sayýsý
    public GameObject winScreen;         // Kazandý ekraný
    public GameObject gameOverScreen;    // Oyun bitti ekraný
    public GameObject youwin;

    private int clickCount = 0;
    private float lastClickTime;
    private bool isGameActive = true;

    private void Start()
    {
        // Oyun baþladýðýnda nesneyi spawn et
        SpawnKraker();
    }

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
        Debug.Log("týklandý");
        if (clickCount < maxClicks && Time.time - lastClickTime >= clickInterval)
        {
            lastClickTime = Time.time;
            clickCount++;

            if (clickCount >= maxClicks)
            {
                EndGame();
                Debug.Log("oyunu kaybettin");
            }
            else
            {
                Debug.Log("oyunu kazandýn");
                WinGame();
            }
        }
    }

    private void EndGame()
    {
        isGameActive = false;
        gameOverScreen.SetActive(true);
    }

    private void WinGame()
    {
        youwin.SetActive(true);
        isGameActive = false;
        winScreen.SetActive(true);
    }

    private void SpawnKraker()
    {
        krakerPrefab.SetActive(true);  // Kraker prefabýný görünür yap
        Instantiate(krakerPrefab, spawnPoint.position, Quaternion.identity);
    }
}
