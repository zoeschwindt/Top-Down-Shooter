using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5f); // destruye la bala despu�s de 5 segundos
    }

    void OnCollisionEnter(Collision other)
    {
        // Verifica si lo que golpe� tiene el script VidaEnemigo
        VidaEnemigo enemigo = other.collider.GetComponent<VidaEnemigo>();
        if (enemigo != null)
        {
            enemigo.RecibirDa�o(enemigo.da�oRecibidoPorBala); // Aplica da�o
        }

        Destroy(gameObject); // destruye la bala
    }
}
