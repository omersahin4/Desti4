using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dollheadanim : MonoBehaviour
{
    public GameManager gameManager;

    public void FixedUpdate()
    {
        Vector3 targetEulerAngles = Vector3.zero; // Default rotation (green light)

        if (!gameManager.isGreenLightActive)
        {
            targetEulerAngles.y = 180f; // Red light, rotate around y-axis by 180 degrees
        }

        transform.eulerAngles = new Vector3(0f, targetEulerAngles.y + 180f, 0f);
    }
}
