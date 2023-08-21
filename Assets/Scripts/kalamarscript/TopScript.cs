using UnityEngine;

public class TopScript : MonoBehaviour
{
    private NesneScript nesneScript;

    private void Start()
    {
        nesneScript = FindObjectOfType<NesneScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            nesneScript.Alindi();
            Destroy(gameObject);
        }
    }
}
