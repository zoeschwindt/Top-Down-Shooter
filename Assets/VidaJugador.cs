using UnityEngine;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour
{
    public int vidaMaxima = 100;
    private int vidaActual;

    public Image barraVida;
    public GameObject panelPerdiste;

    
    public AudioClip sonidoDa�o;
    private AudioSource audioSource;

    void Start()
    {
        vidaActual = vidaMaxima;
        ActualizarBarra();

        if (panelPerdiste != null)
            panelPerdiste.SetActive(false);

        // ?? Inicializar el AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void RecibirDa�o(int cantidad)
    {
        vidaActual -= cantidad;

        // ?? Reproducir sonido de da�o
        if (sonidoDa�o != null && audioSource != null)
            audioSource.PlayOneShot(sonidoDa�o);

        if (vidaActual <= 0)
        {
            vidaActual = 0;
            Morir();
        }

        ActualizarBarra();
    }

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

        Animator anim = GetComponent<Animator>();
        if (anim != null)
            anim.SetTrigger("Morir");

        if (panelPerdiste != null)
            panelPerdiste.SetActive(true);

        Time.timeScale = 0f;
    }
}
