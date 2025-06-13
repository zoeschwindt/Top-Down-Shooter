using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Este m�todo carga el nivel principal del juego
    public void Jugar()
    {
        // Asegurate de que la escena del juego est� a�adida en el Build Settings
        SceneManager.LoadScene("Nivel"); // Cambi� "Nivel1" por el nombre de tu escena
    }

    // Reinicia la escena actual
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Vuelve al men� principal
    public void IrAlMenu()
    {
        SceneManager.LoadScene("Menu"); // Cambi� "MenuPrincipal" por el nombre de tu men�
    }

    // Sale del juego
    public void Salir()
    {
        Debug.Log("Salir del juego...");
        Application.Quit();

        // Esto solo funciona en la build final, no en el editor
    }
}
