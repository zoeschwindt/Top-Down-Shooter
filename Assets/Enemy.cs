using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [Header("Par�metros desde el Inspector")]
    public Transform objetivo;
    public float distanciaParaPerseguir = 40f; // AJUSTADO a 40
    public float distanciaMinimaAlJugador = 2f;
    public float tiempoDeChequeo = 0.5f;

    [Header("Disparo")]
    public GameObject proyectilPrefab;
    public Transform puntoDisparo;
    public Transform puntoDisparoSecundario;
    public float tiempoEntreDisparos = 1.5f;

    private NavMeshAgent agente;
    private float tiempoUltimoDisparo;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.updateRotation = true;
        StartCoroutine(RevisarDistancia());
    }

    IEnumerator RevisarDistancia()
    {
        while (true)
        {
            if (objetivo != null)
            {
                float distancia = Vector3.Distance(transform.position, objetivo.position);

                // Movimiento solo si est� dentro del rango de persecuci�n y fuera del rango m�nimo
                if (distancia <= distanciaParaPerseguir && distancia > distanciaMinimaAlJugador)
                {
                    agente.SetDestination(objetivo.position);
                }
                else
                {
                    agente.ResetPath();
                }

                // Siempre mira al jugador si hay uno asignado
                Vector3 direccion = (objetivo.position - transform.position).normalized;
                direccion.y = 0;

                if (direccion != Vector3.zero)
                {
                    Quaternion rotacion = Quaternion.LookRotation(direccion);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, Time.deltaTime * 40f);
                }

                // Disparar solo si est� dentro del rango de persecuci�n y fuera del m�nimo
                if (distancia <= distanciaParaPerseguir && distancia > distanciaMinimaAlJugador)
                {
                    if (Time.time >= tiempoUltimoDisparo)
                    {
                        Disparar();
                        tiempoUltimoDisparo = Time.time + tiempoEntreDisparos;
                    }
                }
            }

            yield return new WaitForSeconds(tiempoDeChequeo);
        }
    }

    void Disparar()
    {
        if (proyectilPrefab != null)
        {
            // Primer punto de disparo
            if (puntoDisparo != null)
            {
                GameObject proyectil1 = Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);
                Rigidbody rb1 = proyectil1.GetComponent<Rigidbody>();
                if (rb1 != null)
                {
                    rb1.linearVelocity = puntoDisparo.forward * 50f; 
                }
            }

            // Segundo punto de disparo
            if (puntoDisparoSecundario != null)
            {
                GameObject proyectil2 = Instantiate(proyectilPrefab, puntoDisparoSecundario.position, puntoDisparoSecundario.rotation);
                Rigidbody rb2 = proyectil2.GetComponent<Rigidbody>();
                if (rb2 != null)
                {
                    rb2.linearVelocity = puntoDisparoSecundario.forward * 50f; 
                }
            }
        }
    }
}
