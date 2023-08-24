using UnityEngine;

public class collectible : MonoBehaviour
{
    public kalamargamemanager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            manager.CollectObject();
            Destroy(gameObject);
        }
    }
}
