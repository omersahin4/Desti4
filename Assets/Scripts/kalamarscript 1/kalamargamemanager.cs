using UnityEngine;

public class kalamargamemanager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject[] objectsToSpawn;
    public GameObject player;
    public int maxObjectsToCollect = 4;
    public int startingLives = 3;

    private int currentLives;
    private int collectedObjects;

    public GameObject kalamar_tutorial;
    private void Start()
    {
        currentLives = startingLives;
        collectedObjects = 0;
        
        SpawnObjects();
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Time.timeScale = 1f;
            kalamar_tutorial.SetActive(false);
        }
    }
    private void SpawnObjects()
    {
        foreach (GameObject spawnPoint in spawnPoints)
        {
            int randomObjectIndex = Random.Range(0, objectsToSpawn.Length);
            Instantiate(objectsToSpawn[randomObjectIndex], spawnPoint.transform.position, Quaternion.identity);
        }
    }

    public void CollectObject()
    {
        collectedObjects++;

        if (collectedObjects >= maxObjectsToCollect)
        {
            // Win condition
            Debug.Log("You win!");
        }
    }

    public void PlayerHit()
    {
        currentLives--;

        if (currentLives <= 0)
        {
            // Game over condition
            Debug.Log("Game over!");
        }
    }
}

