using UnityEngine;

public class CherryBombPulse : MonoBehaviour
{
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        float pulse = (Mathf.Sin(Time.time * 4f) + 1f) / 2f;
        mat.SetFloat("_Pulse", pulse);
    }
}
