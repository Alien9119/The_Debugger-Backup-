using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala_Survival : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float da�o;

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
            other.GetComponent<Robo_Spider_Tier1>().TomarDa�o(da�o);
            Instantiate(hitEffect, bulletPosition.position, bulletPosition.rotation);
            Destroy(gameObject);
        }
        else if (other.CompareTag("RangedEnemy"))
        {
            other.GetComponent<Robo_Hornet_Tier1>().TomarDa�o(da�o);
            Instantiate(hitEffect, bulletPosition.position, bulletPosition.rotation);
            Destroy(gameObject);
        }
        else if (other.CompareTag("HeavyEnemy"))
        {
            other.GetComponent<Heavy_Spider_Tier1>().TomarDa�o(da�o);
            Instantiate(hitEffect, bulletPosition.position, bulletPosition.rotation);
            Destroy(gameObject);
        }
        else if (other.CompareTag("HeathEnemy"))
        {
            other.GetComponent<Health_Spider>().TomarDa�o(da�o);
            Instantiate(hitEffect, bulletPosition.position, bulletPosition.rotation);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Matriarch"))
        {
            other.GetComponent<Matriarch>().TomarDa�o(da�o);
            Instantiate(hitEffect, bulletPosition.position, bulletPosition.rotation);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Collider"))
        {
            Instantiate(hitEffect, bulletPosition.position, bulletPosition.rotation);
            Destroy(gameObject);
        }
    }
}
