using UnityEngine;
using UnityEngine.SceneManagement;

public class controlador : MonoBehaviour
{
   bool fim = false;
   public void acabou()
    {
        fim = true;
        recomecar();
    }

    void recomecar()
    {
        SceneManager.LoadScene("Nível 1");
    }
}
