using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject fallingObjectPrefab;
    public GameObject cherryBombPrefab;

    public float spawnInterval = 0.5f;

    public int fallingObjectWeight = 5;
    public int cherryBombWeight = 5;

    float timer;

    float minX;
    float maxX;

    void Start()
    {
        // Ambil batas layar dari kamera
        Camera cam = Camera.main;
        float z = Mathf.Abs(cam.transform.position.z);

        minX = cam.ViewportToWorldPoint(new Vector3(0, 0, z)).x;
        maxX = cam.ViewportToWorldPoint(new Vector3(1, 0, z)).x;
    }

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
        Vector3 spawnPos = new Vector3(randomX, transform.position.y, 0f);

        int roll = Random.Range(0, fallingObjectWeight + cherryBombWeight);

        GameObject prefabToSpawn =
            roll < fallingObjectWeight
            ? fallingObjectPrefab
            : cherryBombPrefab;

        Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
    }
}
