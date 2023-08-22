using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using static UnityEditor.Progress;

public class CamOyunuController : MonoBehaviour
{
    public static CamOyunuController instance;

    public GlassGroup[] camButtons; // Array of camera buttons
    public int maxLives = 3;

    public int currentLives;
    private int correctCamIndex;
    public int currentGameIndex = 0;
    public GameObject gameovercanvas;
    public GameObject retrynutton;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        currentLives = maxLives;

        for (int i = 0; i < camButtons.Length; i++)
        {
            camButtons[i].Set(i);
        }

    }




    public void OnCamButtonClicked(int camIndex)
    {
        if (CheckCam(camIndex))
        {
            // Correct cam selected, continue to the next level or take any necessary action
            //  GenerateRandomCam(); // Generate a new random cam for the next round
        }
        else
        {
            LoseLife();
        }
    }

    private bool CheckCam(int camIndex)
    {
        return camIndex == correctCamIndex; // Return true if the selected cam is correct, false otherwise
    }

    public void LoseLife()
    {
        currentLives--;
        Debug.Log("can kaybettin");
        if (currentLives <= 0)
        {
            // Game Over logic
            Debug.Log("Game Over");
            retrynutton.SetActive(true);
            gameovercanvas.SetActive(true);
        }
        else
        {
            // Reset position and continue
            Debug.Log("Life Lost. Remaining Lives: " + currentLives);
            //     GenerateRandomCam(); // Generate a new random cam for the next attempt
        }
    }
}
