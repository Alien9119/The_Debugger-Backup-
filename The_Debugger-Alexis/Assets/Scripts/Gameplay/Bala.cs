using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float daño;

    [SerializeField] private Transform bulletPosition;
    [SerializeField] private GameObject hitEffect;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);

        if (!spriteRenderer.isVisible)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TomarDaño(daño);
            Instantiate(hitEffect, bulletPosition.position, bulletPosition.rotation);
            Destroy(gameObject);
        }
        else if (other.CompareTag("RangedEnemy"))
        {
            other.GetComponent<RangedEnemy>().TomarDaño(daño);
            Instantiate(hitEffect, bulletPosition.position, bulletPosition.rotation);
            Destroy(gameObject);
        }
        else if (other.CompareTag("HeavyEnemy"))
        {
            other.GetComponent<RangedEnemy_Heavy>().TomarDaño(daño);
            Instantiate(hitEffect, bulletPosition.position, bulletPosition.rotation);
            Destroy(gameObject);
        }
        else if(other.CompareTag("Collider"))
        {
            Instantiate(hitEffect, bulletPosition.position, bulletPosition.rotation);
            Destroy(gameObject);
        }
    }
}
