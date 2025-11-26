using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public Camera cam;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCoinAtMouse();
        }
    }

    void SpawnCoinAtMouse()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // HARUS ADA OBJEK COLLIDER DI SCENE
        if (Physics.Raycast(ray, out hit))
        {
            Instantiate(coinPrefab, hit.point, Quaternion.identity);
        }
        else
        {
            Debug.Log("Raycast TIDAK mengenali apa pun! Tambahkan plane ber-collider.");
        }
    }
}
