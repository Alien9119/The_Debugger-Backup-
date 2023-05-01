using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heavy_Spider_Tier1_Health : MonoBehaviour
{
    public GameObject mainEnemy;

    private Heavy_Spider_Tier1 scriptEnemy;
    Vector3 localScale;

    void Start()
    {
        localScale = transform.localScale;
        scriptEnemy = mainEnemy.GetComponent<Heavy_Spider_Tier1>();
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
