using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Comportamento : MonoBehaviour
{
    public Rigidbody variavel;
    public float frente = 1;
    public float lado = 10;
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
