using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [SerializeField] public float vida;
    private Enemy_Spawning enemySpawning;
    private Animator anim;

    public float moveSpeed;
    public Transform shotPoint;
    public Transform gun;

    public GameObject enemyProjectile;

    private Transform objetivo;
    public float followPlayerRange;
    private bool inRange;
    public float attackRange;

    public float startTimeBtwnShots;
    private float timeBtwnShots;

    private SpriteRenderer spriteRenderer;

    
    private void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            objetivo = player.transform;
        }
    }

    void Update()
    {
        Vector3 differance = objetivo.position - gun.transform.position;
        float rotZ = Mathf.Atan2(differance.y, differance.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if (Vector2.Distance(transform.position, objetivo.position) <= followPlayerRange && Vector2.Distance(transform.position, objetivo.position) > attackRange)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }

        if (Vector2.Distance(transform.position, objetivo.position) <= attackRange)
        {
            if (timeBtwnShots <= 0)
            {
                Instantiate(enemyProjectile, shotPoint.position, shotPoint.transform.rotation);
                timeBtwnShots = startTimeBtwnShots;
            }
            else
            {
                timeBtwnShots -= Time.deltaTime;
            }
        }

        if (rotZ >= 90 || rotZ <= -90)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    public void TomarDa�o(float da�o)
    {
        vida -= da�o;
        if (vida <= 0)
        {
            StartCoroutine(DeathDelay());
            enemySpawning = FindObjectOfType<Enemy_Spawning>();
            enemySpawning.enemiesInRoom--;
            if (enemySpawning.spawnTime <= 0 && enemySpawning.enemiesInRoom <= 0)
            {
                enemySpawning.spawnerDone = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (inRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, objetivo.position, moveSpeed * Time.deltaTime);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, followPlayerRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    IEnumerator DeathDelay()
    {
        anim.SetTrigger("Muerte");
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }
}
