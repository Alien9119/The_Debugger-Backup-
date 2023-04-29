using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedHeavy_HalthBar : MonoBehaviour
{
    public GameObject mainEnemy;

    private RangedEnemy_Heavy scriptEnemy;
    Vector3 localScale;

    void Start()
    {
        localScale = transform.localScale;
        scriptEnemy = mainEnemy.GetComponent<RangedEnemy_Heavy>();
    }

    void Update()
    {
        if (scriptEnemy.vida <= 0)
        {
            Destroy(gameObject);
        }

        localScale.y = scriptEnemy.vida / 200;
        transform.localScale = localScale;
    }
}
