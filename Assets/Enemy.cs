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

    private NavMeshAgent agente;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.updateRotation = true; // Asegura que el agente rote al moverse
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
                    agente.SetDestination(objetivo.position); // Lo persigue
                }
                else
                {
                    agente.ResetPath(); // Se detiene

                    // Mira al jugador
                    Vector3 direccion = (objetivo.position - transform.position).normalized;
                    direccion.y = 0; // No mirar arriba/abajo

                    if (direccion != Vector3.zero)
                    {
                        Quaternion rotacion = Quaternion.LookRotation(direccion);
                        transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, Time.deltaTime * 5f);
                    }
                }
            }

            yield return new WaitForSeconds(tiempoDeChequeo);
        }
    }
}
