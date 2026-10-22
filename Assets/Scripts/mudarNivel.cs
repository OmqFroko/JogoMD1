using UnityEngine;
using UnityEngine.SceneManagement;

public class mudarNivel : MonoBehaviour
{
    public void carregarProxNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
