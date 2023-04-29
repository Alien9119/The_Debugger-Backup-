using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Enemigo.cs The_Debugger - Benji Brench
public class Enemy : MonoBehaviour
{
    [SerializeField] public float vida;
    [SerializeField] private float daño2; //Hace daño tomando la función de la clase Jugador

    private Animator anim;
    private Enemy_Spawning enemySpawning;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            enemySpawning = FindObjectOfType<Enemy_Spawning>();
            StartCoroutine(DeathDelay());
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //print("Colisión del enemigo");
        if (other.CompareTag("Player"))
        {
            //print("Colisión con el jugador");
            other.GetComponent<Jugador>().TomarDaño2(daño2);
            //Hacer un timer para dar el daño dependiendo del collider
            print("El jugador ha recibido daño");
            FollowPlayer.instance.persiguiendo = false;
            //Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        FollowPlayer.instance.persiguiendo = true;
    }

    IEnumerator DeathDelay()
    {
        anim.SetTrigger("Muerte");
        yield return new WaitForSeconds(0.7f);
        enemySpawning.enemiesInRoom--;
        Destroy(gameObject);
        if (enemySpawning.spawnTime <= 0 && enemySpawning.enemiesInRoom <= 0)
        {
            enemySpawning.spawnerDone = true;
        }
    }
}