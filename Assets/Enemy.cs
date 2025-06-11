using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [Header("Parámetros desde el Inspector")]
    public Transform objetivo;              // Jugador (se asigna desde el Inspector)
    public float distanciaParaPerseguir = 10f;
    public float distanciaMinimaAlJugador = 2f;
    public float tiempoDeChequeo = 0.5f;

    [Header("Disparo")]
    public GameObject proyectilPrefab;      // Prefab del proyectil
    public Transform puntoDisparo;          // Desde dónde sale el disparo
    public float distanciaDeDisparo = 8f;
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

                if (distancia <= distanciaParaPerseguir && distancia > distanciaMinimaAlJugador)
                {
                    agente.SetDestination(objetivo.position);
                }
                else
                {
                    agente.ResetPath();

                    // Mira al jugador cuando está cerca
                    Vector3 direccion = (objetivo.position - transform.position).normalized;
                    direccion.y = 0;

                    if (direccion != Vector3.zero)
                    {
                        Quaternion rotacion = Quaternion.LookRotation(direccion);
                        transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, Time.deltaTime * 5f);
                    }
                }

                // Disparar si está dentro del rango de disparo y fuera del mínimo
                if (distancia <= distanciaDeDisparo && distancia > distanciaMinimaAlJugador)
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
        if (proyectilPrefab != null && puntoDisparo != null)
        {
            GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);
            Rigidbody rb = proyectil.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = puntoDisparo.forward * 50f; // Velocidad del proyectil
            }
        }
    }
}
