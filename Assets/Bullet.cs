using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5f); // destruye la bala después de 5 segundos
    }

    void OnCollisionEnter(Collision other)
    {
        // Verifica si lo que golpeó tiene el script VidaEnemigo
        VidaEnemigo enemigo = other.collider.GetComponent<VidaEnemigo>();
        if (enemigo != null)
        {
            enemigo.RecibirDaño(enemigo.dañoRecibidoPorBala); // Aplica daño
        }

        Destroy(gameObject); // destruye la bala
    }
}
