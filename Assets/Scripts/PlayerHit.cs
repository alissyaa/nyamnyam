using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public Color normalColor = Color.white;
    public Color bombColor = Color.red;
    public Color fallColor = Color.green;
    public Color shieldColor = Color.cyan;

    public float hitDuration = 0.5f;

    bool isHit = false;
    float timer = 0f;

    ShieldSpawner shieldSpawner;

    Renderer rend;
    MaterialPropertyBlock mpb;

    void Start()
    {
        shieldSpawner = GetComponent<ShieldSpawner>();

        rend = GetComponent<Renderer>();
        mpb = new MaterialPropertyBlock();

        if (shieldSpawner == null)
            Debug.LogError("PlayerHit tidak menemukan ShieldSpawner!");
    }

    void Update()
    {
        if (isHit)
        {
            timer += Time.deltaTime;

            if (timer >= hitDuration)
            {
                if (shieldSpawner != null && shieldSpawner.shieldActive)
                    SetColor(shieldColor);
                else
                    SetColor(normalColor);

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

            SetColor(bombColor);

            ScoreManager.Instance.SubScore(1);
            GameManager.Instance.GameOver();
            return;
        }

        // --- Falling Object ---
        if (other.CompareTag("FallingObject"))
        {
            SetColor(fallColor);
            ScoreManager.Instance.AddScore(5);
            ResetHit();
        }
    }

    void ResetHit()
    {
        timer = 0f;
        isHit = true;
    }

    void SetColor(Color color)
    {
        rend.GetPropertyBlock(mpb);
        mpb.SetColor("_BaseColor", color);
        rend.SetPropertyBlock(mpb);
    }
}
