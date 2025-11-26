using UnityEngine;

public class FallObject : MonoBehaviour
{
    public float fallSpeed = 3f;   // kecepatan jatuh (ubah kapan aja)
    public float destroyY = -10f;  // posisi di mana objek akan dihancurkan

    void Update()
    {
        // Translasi manual: mengurangi y position secara halus
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y - fallSpeed * Time.deltaTime,
            transform.position.z
        );

        // Hapus kalau sudah jatuh terlalu jauh
        if (transform.position.y < destroyY)
        {
            Destroy(gameObject);
        }
    }
}
