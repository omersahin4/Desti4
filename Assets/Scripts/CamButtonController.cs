using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class glassB : MonoBehaviour
{
    public GameObject[] camSegments; // Referans to each cam segment
    public int maxLives = 3;

    private int currentLives;

    private void Start()
    {
        currentLives = maxLives;

        // Assign button click events to cam segments
        for (int i = 0; i < camSegments.Length; i++)
        {
            int camIndex = i; // Store current index for the lambda
            Button button = camSegments[i].GetComponent<Button>();
            button.onClick.AddListener(() => OnCamButtonClicked(camIndex));
        }
    }

    private void OnCamButtonClicked(int camIndex)
    {
        // Check if the selected cam is correct or not
        bool isCorrect = CheckCam(camIndex);

        if (isCorrect)
        {
            // Continue to the next level
        }
        else
        {
            LoseLife();
        }
    }

    private bool CheckCam(int camIndex)
    {
        // Implement your logic to check if the selected cam is correct
        // Return true if correct, false otherwise
        return false;
    }

    private void LoseLife()
    {
        currentLives--;
        if (currentLives <= 0)
        {
            // Game Over logic
        }
        else
        {
            // Reset position and continue
            // Reset cam selection for the new attempt
        }
    }
}
