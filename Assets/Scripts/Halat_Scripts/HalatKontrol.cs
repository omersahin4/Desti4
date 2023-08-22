using UnityEngine;

public class HalatKontrol : MonoBehaviour
{
    public Rigidbody2D halatRigidbody;
    public float hiz = 5.0f;
    public float botHiz = 2.0f; // Botun hareket hýzý

    private bool týklamaYapýldý = false; // Týklama yapýldýðýnda çekme baþlar

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            týklamaYapýldý = true; // Týklama yapýldýðýnda çekme baþlar
        }
        else if (Input.GetMouseButtonUp(0))
        {
            týklamaYapýldý = false; // Týklama býrakýldýðýnda çekmeyi durdur
            halatRigidbody.velocity = Vector2.zero; // Týklama býrakýldýðýnda hýzý sýfýrla
        }

        float hareket = 0.0f;

        if (týklamaYapýldý)
        {
            hareket = hiz; // Týklama olduðunda saða hareket
        }

        // Klavyeden gelen input veya botun otomatik hareketine göre hareket
        Vector2 toplamHareket = new Vector2(hareket - botHiz, halatRigidbody.velocity.y);
        halatRigidbody.velocity = toplamHareket;
    }
}
