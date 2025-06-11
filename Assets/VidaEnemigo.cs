using UnityEngine;
using UnityEngine.UI;

public class VidaEnemigo : MonoBehaviour
{
    [Header("Vida")]
    public float vidaMaxima = 100f;
    private float vidaActual;

    [Header("UI")]
    public Image barraVida; // asignar la imagen de relleno (BarraVida)

    void Start()
    {
        vidaActual = vidaMaxima;
        ActualizarBarra();
    }

    public void RecibirDaño(float cantidad)
    {
        vidaActual -= cantidad;
        if (vidaActual <= 0)
        {
            vidaActual = 0;
            Morir();
        }
        ActualizarBarra();
    }

    void ActualizarBarra()
    {
        if (barraVida != null)
        {
            barraVida.fillAmount = vidaActual / vidaMaxima;
        }
    }

    void Morir()
    {
        // Acá podés agregar animación, efectos, destrucción, etc.
        Destroy(gameObject);
    }
}
