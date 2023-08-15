using UnityEngine;

public class MisketController : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Rigidbody2D rb;
    private SpringJoint2D springJoint;

    public float maxCekmeMesafesi = 2.0f; // Misketi ne kadar geri çekebileceðiniz
    public float cekmeGucu = 5.0f; // Misketin çekilme gücü

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        springJoint = GetComponent<SpringJoint2D>();
        springJoint.enabled = false;
    }

    private void OnMouseDown()
    {
        if (!isDragging)
        {
            isDragging = true;
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
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
            dragEndPos.y = Mathf.Clamp(dragEndPos.y, -3.0f, 3.0f);

            Vector2 force = (Vector2)transform.position - dragEndPos;
            force = Vector2.ClampMagnitude(force, maxCekmeMesafesi) * cekmeGucu;
            rb.AddForce(force, ForceMode2D.Impulse);

            AtisYapildi();
        }
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = new Vector3(curPosition.x, curPosition.y, transform.position.z);
        }

        if (!isDragging && rb.velocity.magnitude < 0.1f)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void AtisYapildi()
    {
        MisketOyunController oyunKontrol = FindObjectOfType<MisketOyunController>();
        oyunKontrol.AtisYapildi();
    }
}
