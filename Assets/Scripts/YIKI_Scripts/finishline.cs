using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishline : MonoBehaviour
{
    public GameObject gameOverCanvas; // "Game Over" ekranýný temsil eden Canvas nesnesi
    public GameObject player; // Ana karakteriniz

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Eðer etkileþim yapan nesne "Player" tag'ine sahipse
        {
            Debug.Log("oyun sonu");
            // "Game Over" ekranýný aktif hale getir
            gameOverCanvas.SetActive(true);
            player.SetActive(false);

        }
    }
}
