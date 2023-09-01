using UnityEngine;

public class TopScript : MonoBehaviour
{
    private bool alindi = false;
    public NesneScript nesneScript;
    public OyuncuScript oyuncuScript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !alindi)
        {
            nesneScript.Alindi();
            Time.timeScale = 0f;
            alindi = true;
            Debug.Log("Top alýndý!");
            gameObject.SetActive(false);
            oyuncuScript.oyunbitti = true;
        }
    }
}
