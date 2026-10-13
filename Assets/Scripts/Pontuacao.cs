using TMPro;
using UnityEngine;

public class Pontuacao : MonoBehaviour
{
    public Transform jogador;
    public TMP_Text contar;
    void Update()
    {
        contar.text = jogador.position.z.ToString("0");
    }
}
