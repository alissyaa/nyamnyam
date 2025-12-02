using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float fallSpeed = 3f;
    public float destroyY = -10f;

    public float rotateSpeed = 120f; // rotasi 3D
    private float fixedZ;            // Z tetap, biar selalu sejajar dengan player

    void Start()
    {
        fixedZ = transform.position.z;   // ambil Z awal
    }

    void Update()
    {
        HandleFall();
        HandleRotation();
    }

    void HandleFall()
    {
        // Ambil posisi sekarang
        Vector3 pos = transform.position;

        // Turun secara manual
        pos.y -= fallSpeed * Time.deltaTime;

        // KUNCI Z agar selalu sama
        pos.z = fixedZ;

        transform.position = pos;

        // Destroy bila jatuh terlalu jauh
        if (pos.y < destroyY)
            Destroy(gameObject);
    }

    void HandleRotation()
    {
        // rotasi 3D manual
        transform.eulerAngles += new Vector3(
            rotateSpeed * Time.deltaTime,
            rotateSpeed * Time.deltaTime,
            rotateSpeed * Time.deltaTime
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Destroy(gameObject);
    }
}
