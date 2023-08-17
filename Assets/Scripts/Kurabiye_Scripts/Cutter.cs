using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    private bool isCutting = false;
    private Vector2 previousPosition;

    public GameObject cutPrefab; // Kesme görseli prefabý
    public LayerMask sliceableLayer;
    public CookieGameManager gameManager;

    void Update()
    {
        if (gameManager.IsGameOver()) // Oyun bitti mi kontrol et
            return;

        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if (isCutting)
        {
            UpdateCut();
        }
    }

    void StartCutting()
    {
        isCutting = true;
        previousPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void StopCutting()
    {
        isCutting = false;
    }

    void UpdateCut()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(previousPosition, newPosition - previousPosition, Vector2.Distance(previousPosition, newPosition), sliceableLayer);

        if (hit.collider != null)
        {
            CreateSlice(hit.point);
            gameManager.GameOver();
        }

        previousPosition = newPosition;
    }

    void CreateSlice(Vector3 position)
    {
        GameObject slice = Instantiate(cutPrefab, position, Quaternion.identity);
        Destroy(slice, 1f); // Kesme görselini belirli bir süre sonra yok et
    }
}
