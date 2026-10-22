using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
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

    public AudioSource som;
    public AudioClip bater;
    public AudioClip coleta;

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
            som.PlayOneShot(bater);
            vida -= 1;
            health.text = vida.ToString();
            if (vida < 1)
            {
                FindAnyObjectByType<controlador>().acabou();
            }
        }
    }

    private void OnCollisionExit(Collision quem)
    {
        if (quem.gameObject.tag == "Platforma")
        {
            FindAnyObjectByType<controlador>().acabou();
        }
    }

    private void OnTriggerEnter(Collider quem)
    {
        if (quem.gameObject.tag == "Bom")
        {
            som.PlayOneShot(coleta);
            coin += 1;
            coins.text = coin.ToString();
            quem.gameObject.SetActive(false);
        }

        if (quem.gameObject.tag == "Finish")
        {
            FindAnyObjectByType<controlador>().passou();
        }

        if (quem.gameObject.tag == "Respawn")
        {
            FindAnyObjectByType<controlador>().acabou();
        }
    }
}
