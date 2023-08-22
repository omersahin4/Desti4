using UnityEngine;

public class MisketBall : MonoBehaviour
{
    public MisketGameController gameController;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetGameController(MisketGameController controller)
    {
        gameController = controller;
    }

    private void OnMouseDown()
    {
        // Mouse týklanýnca topu at
        Throw();
    }

    public void Throw()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 throwDirection = (mousePosition - rb.position).normalized;

        float throwSpeed = Mathf.Clamp(Vector2.Distance(mousePosition, rb.position) * 2, 0, gameController.maxBallSpeed);
        rb.velocity = throwDirection * throwSpeed;

        Destroy(gameObject, 10f); // Topun ekran dýþýna çýkmasý durumunda silinmesi için zamanlayýcý
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pin"))
        {
            Destroy(collision.gameObject); // Taþý vur
            gameController.AddScore(1);
        }
    }
}
