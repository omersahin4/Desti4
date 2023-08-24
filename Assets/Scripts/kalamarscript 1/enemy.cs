using UnityEngine;

public class enemy : MonoBehaviour
{
    public kalamargamemanager manager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            manager.PlayerHit();
        }
    }
}
