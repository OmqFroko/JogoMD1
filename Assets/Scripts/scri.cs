using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class Comportamento : MonoBehaviour
{
    public Rigidbody variavel;
    public float frente = 5;
    public float lado = 10;

    public float vida = 10;
    public float coin = 0;

    public TMP_Text coins;
    public TMP_Text health;

    void FixedUpdate()
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

    private void OnCollisionEnter(Collision quem)
    {
        if (quem.gameObject.tag == "Mau")
        {
            vida -= 1;
            health.text = vida.ToString();
        }
    }
    private void OnTriggerEnter(Collider quem)
    {
        if (quem.gameObject.tag == "Bom")
        {
            coin += 1;
            coins.text = coin.ToString();
        }
    }
}
