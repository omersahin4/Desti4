using UnityEngine;

public class KalamarGameManager : MonoBehaviour
{
    public GameObject topPrefab; // Top prefab'ýný buraya sürükleyin veya atayýn
    public Transform[] spawnPoints; // Toplarýn oluþturulacaðý pozisyonlarý buraya sürükleyin veya atayýn

    public GameObject kalamar_tutorial;

    private void Start()
    {
       Time.timeScale = 0f;
       
        //SpawnToplar();
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Time.timeScale = 1f;
            kalamar_tutorial.SetActive(false);
        }
    }

    private void SpawnToplar()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            Instantiate(topPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
