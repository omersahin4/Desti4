using UnityEngine;

public class HalatKontrol : MonoBehaviour
{
    public Rigidbody2D halatRigidbody;
    public float hiz = 5.0f;
    public float botHiz = 2.0f; // Botun hareket hýzý

    private bool sagaCekiliyor = false; // M tuþuna basýldýðýnda çekme baþlar

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.M))
        {
            sagaCekiliyor = true;
        }
        else if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.M))
        {
            sagaCekiliyor = false;
            halatRigidbody.velocity = new Vector2(0, halatRigidbody.velocity.y); // Týklama býrakýldýðýnda hýzý sýfýrla
        }

        float hareket = 0.0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            hareket = -hiz; // Sol ok tuþuna basýldýðýnda sola hareket
        }
        else if (sagaCekiliyor)
        {
            hareket = hiz; // Týklama veya "M" tuþuna basýlýysa saða hareket
        }

        // Klavyeden gelen input veya botun otomatik hareketine göre hareket
        Vector2 toplamHareket = new Vector2(hareket, 0) + new Vector2(-botHiz, 0);
        halatRigidbody.velocity = toplamHareket;
    }

    private void OnDisable()
    {
        // Halatýn hareketini sýfýrla
        halatRigidbody.velocity = Vector2.zero;
    }
}
