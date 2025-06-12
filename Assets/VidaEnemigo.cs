using UnityEngine;
using UnityEngine.UI;

public class VidaEnemigo : MonoBehaviour
{
    [Header("Vida")]
    public float vidaMaxima = 100f;
    private float vidaActual;

    [Header("Da�o recibido")]
    public float da�oRecibidoPorBala = 20f;

    [Header("UI")]
    public GameObject barraVidaPrefab;
    public Transform puntoBarraVida;

    private Image barraVida;
    private GameObject instanciaBarra;

    void Start()
    {
        vidaActual = vidaMaxima;

        if (barraVidaPrefab != null && puntoBarraVida != null)
        {
            instanciaBarra = Instantiate(barraVidaPrefab, puntoBarraVida.position, Quaternion.identity, puntoBarraVida);

            // ?? Cambio importante aqu�:
            barraVida = instanciaBarra.transform.Find("HealthFill")?.GetComponent<Image>();

            if (barraVida == null)
                Debug.LogWarning("No se encontr� el componente Image llamado 'HealthFill'");
        }

        ActualizarBarra();
    }

    public void RecibirDa�o(float cantidad)
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
        if (GameManager.instancia != null)
            GameManager.instancia.SumarPuntoEnemigo();

        Destroy(instanciaBarra);
        Destroy(gameObject);
    }
}
