using UnityEngine;

public class NesneScript : MonoBehaviour
{
    public GameObject nesnePrefab;
    public EdgeCollider2D edgeCollider;
    public int maxTopSayisi = 3;
    private int alinanTopSayisi = 0;

    public GameObject youwin;
    public GameObject levelup;

    private void Start()
    {
        InvokeRepeating("SpawnNesne", 6f, 3f);
    }

    private void SpawnNesne()
    {
        if (alinanTopSayisi < maxTopSayisi)
        {
            Vector2 spawnPosition = GetRandomSpawnPosition();
            Instantiate(nesnePrefab, spawnPosition, Quaternion.identity);
        }
    }

    private Vector2 GetRandomSpawnPosition()
    {
        Vector2[] colliderPoints = edgeCollider.points; // Edge Collider'ýn köþe noktalarýný al
        Vector2 minPoint = colliderPoints[0];
        Vector2 maxPoint = colliderPoints[1];

        float randomX = Random.Range(minPoint.x, maxPoint.x);
        float randomY = Random.Range(minPoint.y, maxPoint.y);

        return new Vector2(randomX, randomY);
    }

    public void Alindi()
    {
        alinanTopSayisi++;
        Debug.Log("hamood");
        if (alinanTopSayisi >= 1)
        {
            Debug.Log("Oyun Kazanýldý!");
            levelup.SetActive(true);
            youwin.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
