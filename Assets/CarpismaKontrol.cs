using UnityEngine;

public class CarpismaKontrol : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Çarpýþma Algýlandý"); // Debug.Log mesajý ekle

        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Oyuncu ile Çarpýþma Algýlandý"); // Debug.Log mesajý ekle
            Destroy(collision.collider.gameObject);
        }
    }
}
