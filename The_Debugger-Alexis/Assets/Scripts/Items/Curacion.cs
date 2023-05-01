using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curacion : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(DeleteAfter());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Jugador>().Curar(30);
            Destroy(gameObject);
        }   
    }

    IEnumerator DeleteAfter()
    {
        yield return new WaitForSeconds(30f);
        Destroy(gameObject);
    }
}
