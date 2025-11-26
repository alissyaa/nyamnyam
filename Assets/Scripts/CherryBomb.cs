using UnityEngine;

public class CherryBomb : MonoBehaviour
{
    [Header("Movement Settings")]
    public float fallSpeed = 3f;           // kecepatan jatuh
    public float destroyY = -10f;          // batas hancur

    [Header("Scaling Pulse Settings")]
    public float minScale = 0.8f;          // ukuran minimum
    public float maxScale = 1.2f;          // ukuran maksimum
    public float scaleSpeed = 2f;          // kecepatan perubahan skala
    private bool growing = true;           // status membesar atau mengecil

    void Update()
    {
        HandleFalling();
        HandleScaling();
    }

    void HandleFalling()
    {
        // Translasi manual
        Vector3 pos = transform.position;
        pos.y -= fallSpeed * Time.deltaTime;
        transform.position = pos;

        if (pos.y < destroyY)
            Destroy(gameObject);
    }

    void HandleScaling()
    {
        Vector3 scale = transform.localScale;

        if (growing)
        {
            scale += Vector3.one * scaleSpeed * Time.deltaTime;

            if (scale.x >= maxScale)
                growing = false;
        }
        else
        {
            scale -= Vector3.one * scaleSpeed * Time.deltaTime;

            if (scale.x <= minScale)
                growing = true;
        }

        transform.localScale = scale;
    }
}
