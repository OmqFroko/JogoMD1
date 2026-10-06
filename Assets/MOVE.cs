using UnityEngine;

public class MOVE : MonoBehaviour
{
    public Transform esfera;
    public Vector3 distancia;
    void Update()
    {
        transform.position = esfera.position + distancia;
    }
}
