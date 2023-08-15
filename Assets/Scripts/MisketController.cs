using UnityEngine;

public class MisketController : MonoBehaviour
{
    public Transform halkaDelik; // Halka deliðin transform bileþeni
    public float maxCekmeMesafesi = 2.0f; // Misketi ne kadar geri çekebileceðimiz

    private bool isDragging = false;
    private Rigidbody2D rb;
    private SpringJoint2D springJoint;
    private Vector2 dragStartPos;
    private int atisHakki = 6;
    private int can = 3;
    private bool oyunBitti = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        springJoint = GetComponent<SpringJoint2D>();
        springJoint.enabled = false;
    }

    private void OnMouseDown()
    {
        if (!oyunBitti && atisHakki > 0)
        {
            isDragging = true;
            rb.isKinematic = true;
            dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dragStartPos.y = Mathf.Clamp(dragStartPos.y, -3.0f, 3.0f); // Misket y ekseninde sýnýrlý hareket etsin
            springJoint.connectedAnchor = dragStartPos;
            springJoint.enabled = true;
        }
    }

    private void OnMouseUp()
    {
        if (isDragging)
        {
            isDragging = false;
            rb.isKinematic = false;
            springJoint.enabled = false;

            Vector2 dragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dragEndPos.y = Mathf.Clamp(dragEndPos.y, -3.0f, 3.0f); // Misket y ekseninde sýnýrlý hareket etsin

            Vector2 force = dragStartPos - dragEndPos;
            force = Vector2.ClampMagnitude(force, maxCekmeMesafesi) * 5.0f; // Misketi ne kadar geri çektiðimize baðlý olarak hýz ayarý yapabilirsiniz
            rb.AddForce(force, ForceMode2D.Impulse);

            atisHakki--;

            if (atisHakki == 0)
            {
                Debug.Log("Atýþ hakkýnýz bitti!");
                oyunBitti = true;
            }
        }
    }

    private void Update()
    {
        if (!oyunBitti && rb.velocity.magnitude < 0.1f)
        {
            springJoint.enabled = false;
        }

        if (transform.position.y < halkaDelik.position.y)
        {
            Debug.Log("Misketi halka deliðine soktunuz!");
            oyunBitti = true;
        }

        if (transform.position.x > 10.0f) // Eðer misket çok hýzlý giderse sahneden çýkarsa
        {
            Debug.Log("Misketi kaybettiniz!");
            can--;
            if (can == 0)
            {
                Debug.Log("Canlarýnýz bitti, oyun bitti!");
                oyunBitti = true;
            }
            else
            {
                Debug.Log("Kalan can: " + can);
                ResetMisket();
            }
        }
    }

    public void ResetMisket()
    {
        transform.position = new Vector3(-6.0f, 0.0f, 0.0f);
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0.0f;
        springJoint.enabled = false;
    }
}