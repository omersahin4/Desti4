using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamOyunuController : MonoBehaviour
{
    public GlassGroup[] camButtons; // Array of camera buttons
    public int maxLives = 3;

    private int currentLives;
    private int correctCamIndex;

    private void Start()
    {
        currentLives = maxLives;

        foreach (var item in camButtons)
        {
            item.Set();
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

    private void LoseLife()
    {
        currentLives--;
        Debug.Log("can kaybettin");
        if (currentLives <= 0)
        {
            // Game Over logic
            Debug.Log("Game Over");
        }
        else
        {
            // Reset position and continue
            Debug.Log("Life Lost. Remaining Lives: " + currentLives);
       //     GenerateRandomCam(); // Generate a new random cam for the next attempt
        }
    }
}
