using UnityEngine;

public class CarpismaKontrol : MonoBehaviour
{
    public GameObject gameovercanvas;
    public GameObject retrybutton;
    public bool oyunbitti = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Tetikleyici Çakýþma Algýlandý");

        if (other.CompareTag("Player") || other.CompareTag("Oyuncu"))
        {
            Debug.Log("Oyuncu ile Tetikleyici Çakýþma Algýlandý");
            other.gameObject.SetActive(false);
            OyunuBitir();
        }
    }

    private void OyunuBitir()
    {
        gameovercanvas.SetActive(true);
        retrybutton.SetActive(true);
        oyunbitti = true;
        Debug.Log("Oyun Bitti!");
        Time.timeScale = 0f;
        // Oyunun bittiðini iþaretlemek veya gerektiði baþka iþlemleri burada yapabilirsiniz.
    }
}
