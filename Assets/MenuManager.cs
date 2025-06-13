using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Este método carga el nivel principal del juego
    public void Jugar()
    {
        // Asegurate de que la escena del juego esté añadida en el Build Settings
        SceneManager.LoadScene("Nivel"); // Cambiá "Nivel1" por el nombre de tu escena
    }

    // Reinicia la escena actual
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Vuelve al menú principal
    public void IrAlMenu()
    {
        SceneManager.LoadScene("Menu"); // Cambiá "MenuPrincipal" por el nombre de tu menú
    }

    // Sale del juego
    public void Salir()
    {
        Debug.Log("Salir del juego...");
        Application.Quit();

        // Esto solo funciona en la build final, no en el editor
    }
}
