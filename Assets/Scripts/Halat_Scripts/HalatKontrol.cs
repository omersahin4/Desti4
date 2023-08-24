using UnityEngine;
using UnityEngine.UI;

public class HalatKontrol : MonoBehaviour
{
    public Transform halatBaslangic; // Halatýn baþlangýç noktasý
    public Rigidbody2D[] oyuncuRigidbodyArray; // Oyuncularýn Rigidbody bileþenleri
    public float hiz = 5.0f;
    public float botHiz = 2.0f; // Botun hareket hýzý

    private bool týklamaYapýldý = false; // Týklama yapýldýðýnda çekme baþlar

    public Button sagaCekButton; // Saða çekme iþlemi için buton referansý

    private void Start()
    {
        // Butonun týklama olayýna çekme iþlemini ekle
        sagaCekButton.onClick.AddListener(SagaCek);
    }

    private void Update()
    {
        float hareket = 0.0f;

        if (týklamaYapýldý)
        {
            hareket = hiz; // Týklama olduðunda saða hareket

            // Oyuncularý saða doðru çek
            foreach (Rigidbody2D oyuncuRigidbody in oyuncuRigidbodyArray)
            {
                Vector2 oyuncuHareket = new Vector2(hareket, oyuncuRigidbody.velocity.y);
                oyuncuRigidbody.velocity = oyuncuHareket;
            }
        }
        else
        {
            // Oyuncularý durdur
            foreach (Rigidbody2D oyuncuRigidbody in oyuncuRigidbodyArray)
            {
                oyuncuRigidbody.velocity = Vector2.zero;
            }
        }
    }

    private void SagaCek()
    {
        // Saða çekme iþlemi
        týklamaYapýldý = true;
    }

    public void Býrak()
    {
        // Çekmeyi durdur
        týklamaYapýldý = false;
        foreach (Rigidbody2D oyuncuRigidbody in oyuncuRigidbodyArray)
        {
            oyuncuRigidbody.velocity = Vector2.zero; // Hýzý sýfýrla
        }
    }
}
