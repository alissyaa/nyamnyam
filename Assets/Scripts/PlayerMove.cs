using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        Vector3 pos = transform.position;
        pos.x += input * speed * Time.deltaTime;
        transform.position = pos;
    }
}
