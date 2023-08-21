using UnityEngine;

public class TopScript : MonoBehaviour
{
    private bool alindi = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !alindi)
        {
            alindi = true;
            Debug.Log("Top alýndý!");
            gameObject.SetActive(false); // Topu görünmez yap
        }
    }
}
