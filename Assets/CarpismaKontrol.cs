using UnityEngine;

public class CarpismaKontrol : MonoBehaviour
{
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
        Debug.Log("Oyun Bitti!");
        // Oyunun bittiðini iþaretlemek veya gerektiði baþka iþlemleri burada yapabilirsiniz.
    }
}
