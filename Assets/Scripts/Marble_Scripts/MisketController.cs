using UnityEngine;

public class MisketController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isMoving = false;
    private int atisHakki = 6; // Toplam atýþ hakký

    public float itmeGucu = 10.0f; // Misketi itme gücü

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Misketi yerçekimsiz yaparak düz bir doðrultuda hareket etmesini saðlayýn
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving && atisHakki > 0)
        {
            AtisYap();
        }
    }

    private void AtisYap()
    {
        rb.velocity = new Vector2(itmeGucu, 0);
        isMoving = true;
        atisHakki--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Halka"))
        {
            Debug.Log("Misket halkaya girdi! Puan kazandýnýz!");
            Destroy(gameObject);
        }
        else if (collision.CompareTag("SinirCizgisi") || atisHakki == 0)
        {
            Debug.Log("Misket oyun alanýný terk etti veya atýþ hakkýnýz bitti.");
            Destroy(gameObject);
        }
    }
}
