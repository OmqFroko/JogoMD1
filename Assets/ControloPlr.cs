using UnityEngine;

public class ControloPlr : MonoBehaviour
{
    public Rigidbody batata;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            batata.AddForce(-10, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            batata.AddForce(10, 0, 0);
        }
    }
}
