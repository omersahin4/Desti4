using UnityEngine;

public class MisketKontrol : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // Misket z eksende olmadýðý için z pozisyonunu sýfýrlýyoruz

        rb2D.MovePosition(mousePos);
    }
}
