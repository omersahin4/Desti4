using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{
    public GameObject music;
    private bool isMuted = false;

    public void ToggleMute()
    {
        isMuted = !isMuted; // Mute durumunu tersine çevir

        if (isMuted)
        {
            music.SetActive(false); // Müziði kapat
        }
        else
        {
            music.SetActive(true); // Müziði aç
        }
    }
}
