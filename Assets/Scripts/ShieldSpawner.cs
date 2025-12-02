using UnityEngine;

public class ShieldSpawner : MonoBehaviour
{
    public GameObject shieldPrefab;   // prefab shield
    public Transform player;          // target untuk ditempel
    public float shieldDuration = 5f;

    private GameObject currentShield;
    private float timer = 0f;
    public bool shieldActive = false;

    void Update()
    {
        // Tekan SPACE untuk spawn shield
        if (Input.GetKeyDown(KeyCode.Space) && !shieldActive)
        {
            SpawnShield();
        }

        // Hitung durasi aktif
        if (shieldActive)
        {
            timer += Time.deltaTime;
            if (timer >= shieldDuration)
            {
                Destroy(currentShield);
                shieldActive = false;
            }
        }

        // Pastikan shield selalu nempel ke player
        if (shieldActive && currentShield != null)
        {
            currentShield.transform.position = player.position;
        }
    }

    void SpawnShield()
    {
        currentShield = Instantiate(shieldPrefab, player.position, Quaternion.identity);
        shieldActive = true;
        timer = 0f;
    }
}
