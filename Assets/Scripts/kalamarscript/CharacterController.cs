using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public EdgeCollider2D mapBounds; // Harita sýnýrlarýný belirlemek için kullanýlan Edge Collider
    public GameObject deathText; // Ölüm yazýsýný içeren UI nesnesi
    public PlayerMovement playerMovementScript; // Hareketi kontrol eden script bileþeni

    private bool isDead = false; // Karakter öldü mü kontrolü

    private void Update()
    {
        if (!isDead && !mapBounds.bounds.Contains(transform.position))
        {
            // Eðer karakter sýnýrlarýn dýþýndaysa
            Debug.Log("Öldün!");
            isDead = true; // Karakter öldüðünü belirt
            deathText.SetActive(true); // Ölüm yazýsýný etkinleþtir

            // Karakterin hareketini kontrol eden scripti devre dýþý býrak
            playerMovementScript.enabled = false;

            // Burada karakterin ölme animasyonu, oyunun yeniden baþlatýlmasý vb. iþlemleri gerçekleþtirebilirsiniz
        }
    }
}
