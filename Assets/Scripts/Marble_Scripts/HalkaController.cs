using UnityEngine;

public class HalkaController : MonoBehaviour
{
    private MisketOyunController oyunKontrol;

    private void Start()
    {
        oyunKontrol = FindObjectOfType<MisketOyunController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Misket"))
        {
            oyunKontrol.MisketiHalkayaGirdi();
        }
    }
}
