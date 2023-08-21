using UnityEngine;

public class OyuncuScript : MonoBehaviour
{
    public int can = 3;
    private bool canAzaldi = false;

    private void Update()
    {
        if (can <= 0)
        {
            Debug.Log("Oyunu kaybettin!");
            // Burada oyunu yeniden baþlatmak veya baþka bir iþlem yapabilirsiniz.
        }
        else if (Time.timeSinceLevelLoad > 20f && !canAzaldi)
        {
            canAzaldi = true;
            can--;
            Debug.Log("Can azaldý: " + can);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bot"))
        {
            can--;
            Debug.Log("Can azaldý: " + can);
        }
    }
}
