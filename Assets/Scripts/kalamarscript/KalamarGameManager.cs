using UnityEngine;

public class KalamarGameManager : MonoBehaviour
{
    public GameObject topPrefab; // Top prefab'ýný buraya sürükleyin veya atayýn
    public Transform[] spawnPoints; // Toplarýn oluþturulacaðý pozisyonlarý buraya sürükleyin veya atayýn

    private void Start()
    {
        SpawnToplar();
    }

    private void SpawnToplar()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            Instantiate(topPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
