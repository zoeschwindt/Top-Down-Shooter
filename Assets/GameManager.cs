using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    public int puntosEnemigos = 0;
    public int puntosItems = 0;
    public int puntosParaGanar = 10;

    public TextMeshProUGUI textoPuntosEnemigos;
    public TextMeshProUGUI textoPuntosItems;

    public GameObject panelRojo;
    public GameObject panelGanaste;

    private void Awake()
    {
        if (instancia == null) instancia = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        if (panelRojo != null) panelRojo.SetActive(false);
        if (panelGanaste != null) panelGanaste.SetActive(false);

        ActualizarTextoPuntosEnemigos();
        ActualizarTextoPuntosItems();
    }

    public void SumarPuntoEnemigo()
    {
        puntosEnemigos++;
        ActualizarTextoPuntosEnemigos();
        if (panelRojo != null) StartCoroutine(MostrarPanelRojo());
        if (puntosEnemigos >= puntosParaGanar) MostrarPanelGanaste();
    }

    public void SumarPuntoItem()
    {
        puntosItems++;
        ActualizarTextoPuntosItems();
        // Si querés, podés chequear acá si puntosItems >= puntosParaGanar para ganar con ítems.
    }

    void ActualizarTextoPuntosEnemigos()
    {
        if (textoPuntosEnemigos != null)
            textoPuntosEnemigos.text = puntosEnemigos.ToString();
    }

    void ActualizarTextoPuntosItems()
    {
        if (textoPuntosItems != null)
            textoPuntosItems.text = puntosItems.ToString();
    }

    IEnumerator MostrarPanelRojo()
    {
        panelRojo.SetActive(true);
        yield return new WaitForSeconds(1f);
        panelRojo.SetActive(false);
    }

    void MostrarPanelGanaste()
    {
        if (panelGanaste != null) panelGanaste.SetActive(true);
        Time.timeScale = 0f;
    }
}
