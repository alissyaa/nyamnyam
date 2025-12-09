using UnityEngine;
using System.Collections;

public class FallingObject : MonoBehaviour
{
    public float fallSpeed = 3.0f;
    public float destroyY = -10.0f;
    public float rotateSpeed = 120.0f;

    public float fadeDuration = 0.5f; // durasi fade

    private float fixedZ;
    private Material mat;
    private bool isFading = false; // biar gak trigger berkali-kali

    void Start()
    {
        fixedZ = transform.position.z;
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (!isFading)
        {
            HandleFall();
            HandleRotation();
        }
    }

    void HandleFall()
    {
        Vector3 pos = transform.position;
        pos.y -= fallSpeed * Time.deltaTime;
        pos.z = fixedZ;
        transform.position = pos;

        if (pos.y < destroyY)
            Destroy(gameObject);
    }

    void HandleRotation()
    {
        transform.eulerAngles += new Vector3(
            rotateSpeed * Time.deltaTime,
            rotateSpeed * Time.deltaTime,
            rotateSpeed * Time.deltaTime
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isFading)
        {
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {
        isFading = true;

        float t = 0f;
        Color startColor = mat.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
            mat.color = new Color(
                startColor.r,
                startColor.g,
                startColor.b,
                alpha
            );
            yield return null;
        }

        Destroy(gameObject);
    }
}
