using UnityEngine;

public class OyuncuScript : MonoBehaviour
{
    public bool oyunbitti = false;
    public int can = 1;
    private bool canAzaldi = false;
    public bool oyunAktif = true; // Bu deðiþken oyunun aktif olup olmadýðýný kontrol eder.
    public GameObject gameovercanvas;
    public GameObject retrybutton;
    public GameObject kalamar_tutorial;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    private void Start()
    {
        Time.timeScale = 0f;
    }
    private void Update()
    {
        
        if ( Input.GetMouseButtonUp(0) && oyunAktif == true && oyunbitti == false)
        {
            Time.timeScale = 1f;
            kalamar_tutorial.SetActive(false);
        }

        if (!oyunAktif)
        {
            Time.timeScale=0f; 
        }
       
        if (can == 2)
        {
            heart3.SetActive(false);
        }
        if (can == 1)
        {
            heart2.SetActive(false);
        }
        if (can <= 0)
        {
            heart1.SetActive(false);
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
            oyunbitti = true;
            Time.timeScale = 0f;
        }

        if (collision.CompareTag("Bot"))
        {
            can--;
            Debug.Log("Can azaldý: " + can);
        }
    }

    private void OyunuBitir()
    {
        oyunbitti=true;
        oyunAktif = false; // Oyunu pasifleþtir.
        Debug.Log("Oyunu kaybettin!");
        gameovercanvas.SetActive(true);
        retrybutton.SetActive(true);
        Time.timeScale = 0f;


     
    }
}
