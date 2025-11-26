using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public Material playerMat;

    public Color normalColor = Color.white;
    public Color bombColor = Color.red;
    public Color fallColor = Color.green;   // warna jika kena FallingObject
    public Color coinColor = Color.yellow;  // kalau nanti mau dipakai

    public float hitDuration = 0.5f;

    bool isHit = false;
    float timer = 0f;

    void Update()
    {
        if (isHit)
        {
            timer += Time.deltaTime;

            if (timer >= hitDuration)
            {
                playerMat.SetColor("_BaseColor", normalColor);
                isHit = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CherryBomb"))
        {
            playerMat.SetColor("_BaseColor", bombColor);
            ResetHit();
        }
        else if (other.CompareTag("FallingObject"))
        {
            playerMat.SetColor("_BaseColor", fallColor);
            ResetHit();
        }
        else if (other.CompareTag("CoinSpawner"))
        {
            playerMat.SetColor("_BaseColor", coinColor);
            ResetHit();
        }
    }

    void ResetHit()
    {
        timer = 0f;
        isHit = true;
    }
}
