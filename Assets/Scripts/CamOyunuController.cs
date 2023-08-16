using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamOyunuController : MonoBehaviour
{
    public Button[] camButtons; // Array of camera buttons
    public int maxLives = 3;

    private int currentLives;
    private int correctCamIndex;

    private void Start()
    {
        currentLives = maxLives;
        GenerateRandomCam(); // Generate a random cam at the start

        // Assign click events to camera buttons
        for (int i = 0; i < camButtons.Length; i++)
        {
            int camIndex = i; // Store current index for the lambda
            Button button = camButtons[i];
            button.onClick.AddListener(() => OnCamButtonClicked(camIndex));
        }
    }

    private void GenerateRandomCam()
    {
        correctCamIndex = Random.Range(0, camButtons.Length); // Select a random cam index
        SetCamStatus(correctCamIndex);
    }

    private void SetCamStatus(int camIndex)
    {
        Button camButton = camButtons[camIndex];
        bool isCamBroken = Random.Range(0f, 1f) < 0.5f; // Assuming a 50% chance of being broken

        // Set the button's color or image based on the cam's status
        Image camImage = camButton.GetComponent<Image>();
        if (camImage != null)
        {
            if (isCamBroken)
            {
                // Set sprite for broken cam
                camImage.color = Color.red; // You can adjust this to match your game's visuals
            }
            else
            {
                // Set sprite for intact cam
                camImage.color = Color.green; // You can adjust this to match your game's visuals
            }
        }
    }

    public void OnCamButtonClicked(int camIndex)
    {
        if (CheckCam(camIndex))
        {
            // Correct cam selected, continue to the next level or take any necessary action
            GenerateRandomCam(); // Generate a new random cam for the next round
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
            GenerateRandomCam(); // Generate a new random cam for the next attempt
        }
    }
}
