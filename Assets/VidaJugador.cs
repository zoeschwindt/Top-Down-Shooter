using UnityEngine;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour
{
    public int vidaMaxima = 100;
    private int vidaActual;

    public Image barraVida;
    public GameObject panelPerdiste;  // Referencia al panel de "Perdiste"

    void Start()
    {
        vidaActual = vidaMaxima;
        ActualizarBarra();

        if (panelPerdiste != null)
            panelPerdiste.SetActive(false);  // Asegurarse que el panel est� oculto al inicio
    }

    public void RecibirDa�o(int cantidad)
    {
        vidaActual -= cantidad;
        if (vidaActual <= 0)
        {
            vidaActual = 0;
            Morir();
        }
        ActualizarBarra();
    }

    // M�TODO NUEVO para sumar vida
    public void RecibirVida(int cantidad)
    {
        vidaActual += cantidad;
        if (vidaActual > vidaMaxima)
            vidaActual = vidaMaxima;

        ActualizarBarra();
    }

    void ActualizarBarra()
    {
        if (barraVida != null)
        {
            barraVida.fillAmount = (float)vidaActual / vidaMaxima;
        }
    }

    void Morir()
    {
        Debug.Log("El jugador ha muerto");

        if (panelPerdiste != null)
            panelPerdiste.SetActive(true);  // Mostrar el panel de "Perdiste"

        Time.timeScale = 0f;  // Pausar el juego
    }
}
