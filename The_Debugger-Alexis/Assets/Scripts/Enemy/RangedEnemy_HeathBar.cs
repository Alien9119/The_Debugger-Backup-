using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy_HeathBar : MonoBehaviour
{
    public GameObject mainEnemy;

    private RangedEnemy scriptEnemy;
    Vector3 localScale;

    void Start()
    {
        localScale = transform.localScale;
        scriptEnemy = mainEnemy.GetComponent<RangedEnemy>();
    }

    void Update()
    {
        if (scriptEnemy.vida <= 0)
        {
            Destroy(gameObject);
        }

        localScale.y = scriptEnemy.vida / 100;
        transform.localScale = localScale;
    }
}
