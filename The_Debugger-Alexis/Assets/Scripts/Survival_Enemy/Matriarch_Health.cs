using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matriarch_Health : MonoBehaviour
{
    public GameObject mainEnemy;

    private Matriarch scriptEnemy;
    Vector3 localScale;

    void Start()
    {
        localScale = transform.localScale;
        scriptEnemy = mainEnemy.GetComponent<Matriarch>();
    }

    void Update()
    {
        if (scriptEnemy.vida <= 0)
        {
            Destroy(gameObject);
        }

        localScale.y = scriptEnemy.vida / 300;
        transform.localScale = localScale;
    }
}
