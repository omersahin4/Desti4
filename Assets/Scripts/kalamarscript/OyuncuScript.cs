using UnityEngine;

public class OyuncuScript : MonoBehaviour
{
    public int can = 1;
    private bool canAzaldi = false;
    private bool oyunAktif = true; // Bu deðiþken oyunun aktif olup olmadýðýný kontrol eder.
    public GameObject gameovercanvas;
    public GameObject retrybutton;

    private void Start()
    {
        Time.timeScale = 1f;
    }
    private void Update()
    {
        if (!oyunAktif)
        {
            
            return; // Oyun pasifse, hiçbir þey yapma.
        }

        if (can <= 0)
        {
            OyunuBitir();
        }
        else if (Time.timeSinceLevelLoad > 20f && !canAzaldi)
        {
            canAzaldi = true;
            can--;
            Debug.Log("Can azaldý: " + can);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!oyunAktif)
        {
            return; // Oyun pasifse, hiçbir þey yapma.
        }

        if (collision.CompareTag("Bot"))
        {
            can--;
            Debug.Log("Can azaldý: " + can);
        }
    }

    private void OyunuBitir()
    {
        oyunAktif = false; // Oyunu pasifleþtir.
        Debug.Log("Oyunu kaybettin!");
        gameovercanvas.SetActive(true);
        retrybutton.SetActive(true);
        Time.timeScale = 0f;


        // Burada oyunu yeniden baþlatmak veya baþka bir iþlem yapabilirsiniz.
    }
}
