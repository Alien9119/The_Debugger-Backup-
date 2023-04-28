using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Projectile : MonoBehaviour
{
    [SerializeField] private float daño2;

    public float bulletSpeed;
    public float lifeTime;

    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Jugador>().TomarDaño2(daño2);
        }
    }
}
