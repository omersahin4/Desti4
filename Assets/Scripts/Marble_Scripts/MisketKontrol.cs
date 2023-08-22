using UnityEngine;

public class MisketKontrol : MonoBehaviour
{
    private Rigidbody2D rb2D;
   // private bool isDragging = false;
    private Vector3 offset;
    private float throwForce = 10.0f;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
      //  isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        rb2D.velocity = Vector2.zero;
    }

    private void OnMouseUp()
    {
       // isDragging = false;

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        Vector2 throwDirection = (curPosition - transform.position).normalized;
        float throwDistance = Vector3.Distance(curPosition, transform.position);
        Vector2 throwVelocity = throwDirection * throwDistance * throwForce;

        rb2D.velocity = throwVelocity;
    }
}