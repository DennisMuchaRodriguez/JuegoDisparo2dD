using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : MonoBehaviour
{
     public float bulletSpeed = 20f;
    public Rigidbody2D rb;
    public float lifeTime = 4f; // Duraci�n de la vida de la bala

    void Start()
    {
        rb.velocity = transform.up * bulletSpeed;
        Destroy(gameObject, lifeTime); // Destruir la bala despu�s de 4 segundos
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == ("Enemy"))
        {
            Destroy(hitInfo.gameObject); // Destruir enemigo
            Destroy(gameObject);         // Destruir bala
            GameManager.instance.IncreaseScore(); // Aumentar puntuaci�n
        }
    }
}
