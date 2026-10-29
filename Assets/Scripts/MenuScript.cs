using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void iniciar()
    {
        SceneManager.LoadScene(1);
    }

    public void sair()
    {
        Application.Quit();
    }
}