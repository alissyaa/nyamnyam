using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    public float rotationSpeed = 90f;

    void Update()
    {
        Vector3 rot = transform.eulerAngles;

        rot.y += rotationSpeed * Time.deltaTime; // putar Y
        rot.x = 15f;                             // sedikit miring

        transform.eulerAngles = rot;             // <- WAJIB
    }
}
