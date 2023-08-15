using UnityEngine;

public class HalatKontrol : MonoBehaviour
{
    public Rigidbody2D halatRigidbody;
    public float hiz = 5.0f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            HalatiSagaCek();
        }
        else if (Input.GetKey(KeyCode.C))
        {
            HalatiSolaCek();
        }
    }

    private void HalatiSagaCek()
    {
        halatRigidbody.velocity = new Vector2(hiz, 0);
    }

    private void HalatiSolaCek()
    {
        halatRigidbody.velocity = new Vector2(-hiz, 0);
    }

    private void OnDisable()
    {
        // Halatýn hareketini sýfýrla
        halatRigidbody.velocity = Vector2.zero;
    }
}
