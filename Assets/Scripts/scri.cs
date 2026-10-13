using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Comportamento : MonoBehaviour
{
    public Rigidbody variavel;
    public float frente = 5;
    public float lado = 10;

    private void OnCollisionEnter(Collision quem)
    {
        if (quem.gameObject.tag == "Bom")
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

    void Update()
    {
        Keyboard teclado = Keyboard.current;
        variavel.AddForce(0, 0, frente);

        if (teclado.aKey.isPressed)
        {
            variavel.AddForce(-lado, 0, 0);
        }
        if (teclado.dKey.isPressed)
        {
            variavel.AddForce(lado, 0, 0);
        }
    }
}
