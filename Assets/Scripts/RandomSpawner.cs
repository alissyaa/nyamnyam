using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject fallingObjectPrefab;
    public GameObject cherryBombPrefab;

    public float spawnInterval = 0.5f; // makin kecil makin rame
    public float minX = -4f;
    public float maxX = 4f;

    public int fallingObjectWeight = 5;  
    public int cherryBombWeight = 5;   

    float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnRandomObject();
            timer = 0f;
        }
    }

    void SpawnRandomObject()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPos = new Vector3(randomX, transform.position.y, 0);

        int roll = Random.Range(0, fallingObjectWeight + cherryBombWeight);

        if (roll < fallingObjectWeight)
        {
            Instantiate(fallingObjectPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            Instantiate(cherryBombPrefab, spawnPos, Quaternion.identity);
        }
    }
}
