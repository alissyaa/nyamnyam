using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public Material playerMat;

    public Color normalColor = Color.white;
    public Color bombColor = Color.red;
    public Color fallColor = Color.green;
    public Color shieldColor = Color.cyan;

    public float hitDuration = 0.5f;

    bool isHit = false;
    float timer = 0f;

    ShieldSpawner shieldSpawner;

    void Start()
    {
        shieldSpawner = GetComponent<ShieldSpawner>();

        if (shieldSpawner == null)
            Debug.LogError("PlayerHit tidak menemukan ShieldSpawner! Pastikan script ShieldSpawner ada di Player!");
    }

    void Update()
    {
        // Kembalikan warna setelah durasi hit
        if (isHit)
        {
            timer += Time.deltaTime;

            if (timer >= hitDuration)
            {
                // Jika shield aktif → warna shield
                if (shieldSpawner != null && shieldSpawner.shieldActive)
                    playerMat.SetColor("_BaseColor", shieldColor);
                else
                    playerMat.SetColor("_BaseColor", normalColor);

                isHit = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // --- Cherry Bomb ---
        if (other.CompareTag("CherryBomb"))
        {
            if (shieldSpawner != null && shieldSpawner.shieldActive)
            {
                Destroy(other.gameObject);
                return;
            }

            playerMat.SetColor("_BaseColor", bombColor);
            ScoreManager.Instance.SubScore(1);
            ResetHit();
        }

        // --- Falling Object ---
        else if (other.CompareTag("FallingObject"))
        {
            playerMat.SetColor("_BaseColor", fallColor);
            ScoreManager.Instance.AddScore(5);
            ResetHit();
        }
    }

    void ResetHit()
    {
        timer = 0f;
        isHit = true;
    }
}
