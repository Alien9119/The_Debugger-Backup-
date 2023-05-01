using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HealthBar : MonoBehaviour
{
    public GameObject mainEnemy;

    private Enemy_2 scriptEnemy;
    Vector3 localScale;

    void Start()
    {
        localScale = transform.localScale;
        scriptEnemy = mainEnemy.GetComponent<Enemy_2>();
    }

    void Update()
    {
        if(scriptEnemy.vida <= 0)
        {
            Destroy(gameObject);
        }
        
        localScale.y = scriptEnemy.vida / 100; 
        transform.localScale = localScale;
    }
}
