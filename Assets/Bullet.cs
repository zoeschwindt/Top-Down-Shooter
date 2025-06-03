using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5f); // destruye despu�s de 5 segundos
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject); // o efectos de explosi�n
    }
}