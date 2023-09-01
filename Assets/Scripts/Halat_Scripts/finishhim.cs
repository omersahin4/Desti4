using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishhim : MonoBehaviour
{
    public bool oyunbitti = false;
    public GameObject gameovercanvas;
    public GameObject retrybutton;
    public GameObject wingame;
    public GameObject youwin;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            oyunbitti = true;
            gameovercanvas.SetActive(true);
            retrybutton.SetActive(true);
            Debug.Log("kaybettin");
            Time.timeScale = 0f;
        }
        else if(other.CompareTag("Oyuncu"))
        {
            oyunbitti = true;
            wingame.SetActive(true);
            youwin.SetActive(true);
            Debug.Log("kazandýn");
            Time.timeScale = 0f;
        }
    }
}
