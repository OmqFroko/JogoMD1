using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class Comportamento : MonoBehaviour
{
    public Rigidbody variavel;
    public float frente = 5;
    public float lado = 10;
    private const float DIVISOR_ECRA = 0.5f;

    public float vida = 10;
    public float coin = 0;

    public TMP_Text coins;
    public TMP_Text health;

    public AudioSource som;
    public AudioClip bater;
    public AudioClip coleta;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    void FixedUpdate()
    {
        variavel.AddForce(0, 0, frente);

        float direcao = LerDirecao();
        if (direcao != 0f)
        {
            variavel.AddForce(direcao * lado, 0, 0);
        }
    }

    private float LerDirecao()
    {
        float direcao = 0f;

        // Teclado (computador)
        Keyboard teclado = Keyboard.current;
        if (teclado != null)
        {
            if (teclado.aKey.isPressed) direcao -= 1f;
            if (teclado.dKey.isPressed) direcao += 1f;
        }

        // Toque (telemóvel)
        foreach (Touch toque in Touch.activeTouches)
        {
            if (toque.screenPosition.x < Screen.width * DIVISOR_ECRA)
                direcao -= 1f;
            else
                direcao += 1f;
        }

        return Mathf.Clamp(direcao, -1f, 1f);
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
