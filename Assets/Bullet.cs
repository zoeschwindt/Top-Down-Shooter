using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5f); // destruye después de 5 segundos
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject); // o efectos de explosión
    }
}