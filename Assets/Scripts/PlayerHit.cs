using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public Material playerMat;

    public Color normalColor = Color.white;
    public Color bombColor = Color.red;
    public Color fallColor = Color.green;
    public Color shieldColor = Color.cyan;   // warna saat shield aktif

    public float hitDuration = 0.5f;

    bool isHit = false;
    float timer = 0f;

    // === SHIELD SYSTEM ===
    public bool shieldActive = false;
    public float shieldDuration = 5.0f;
    float shieldTimer = 0f;

    void Update()
    {
        // --- Shield activation ---
        if (Input.GetKeyDown(KeyCode.Space) && !shieldActive)
        {
            ActivateShield();
        }

        // --- Shield countdown ---
        if (shieldActive)
        {
            shieldTimer += Time.deltaTime;

            if (shieldTimer >= shieldDuration)
            {
                DeactivateShield();
            }
        }

        // --- Hit flash effect ---
        if (isHit)
        {
            timer += Time.deltaTime;

            if (timer >= hitDuration)
            {
                // jika shield aktif, warna tetap warna shield
                playerMat.SetColor("_BaseColor", shieldActive ? shieldColor : normalColor);
                isHit = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ======== CHERRY BOMB ========
        if (other.CompareTag("CherryBomb"))
        {
            if (shieldActive)
            {
                // shield melindungi
                Destroy(other.gameObject);
                return;
            }

            playerMat.SetColor("_BaseColor", bombColor);
            ScoreManager.Instance.SubScore(1);   // -1 poin
            ResetHit();
        }

        // ======== FALLING OBJECT (MAKANAN) ========
        else if (other.CompareTag("FallingObject"))
        {
            playerMat.SetColor("_BaseColor", fallColor);
            ScoreManager.Instance.AddScore(5);   // +5 poin
            ResetHit();
        }
    }

    // === HIT EFFECT RESET ===
    void ResetHit()
    {
        timer = 0f;
        isHit = true;
    }

    // === SHIELD FUNCTIONS ===
    void ActivateShield()
    {
        shieldActive = true;
        shieldTimer = 0f;

        playerMat.SetColor("_BaseColor", shieldColor);
        Debug.Log("Shield ON");
    }

    void DeactivateShield()
    {
        shieldActive = false;

        playerMat.SetColor("_BaseColor", normalColor);
        Debug.Log("Shield OFF");
    }
}
