using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject fallingObjectPrefab;
    public GameObject cherryBombPrefab;

    public float spawnInterval = 1f;   // berapa detik sekali spawn
    public float minX = -4f;
    public float maxX = 4f;

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
        // posisi acak di sumbu X
        float randomX = Random.Range(minX, maxX);

        Vector3 spawnPos = new Vector3(randomX, transform.position.y, 0);

        // 50% peluang jatuhin FallingObject atau CherryBomb
        int pick = Random.Range(0, 2);

        if (pick == 0)
            Instantiate(fallingObjectPrefab, spawnPos, Quaternion.identity);
        else
            Instantiate(cherryBombPrefab, spawnPos, Quaternion.identity);
    }
}
