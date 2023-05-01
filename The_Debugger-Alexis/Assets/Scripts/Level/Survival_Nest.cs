using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survival_Nest : MonoBehaviour
{
    public Survival_Spawner spawnScript;
    public GameObject Child;

    private SpriteRenderer SpriteR;
    private SpriteRenderer SpriteR_Hijo;

    private bool InvT;
    private bool x;

    private float max;

    private Vector3 escala = new Vector3(0, 0, 1);

    void Start()
    {
        x = true;
        max = 0.5f;
        Child = transform.Find("Nest1").gameObject;
        SpriteR = GetComponent<SpriteRenderer>();
        SpriteR_Hijo = Child.GetComponentInChildren<SpriteRenderer>();

        gameObject.transform.localScale = escala;
    }

    void Update()
    {
        InvT = spawnScript.canSpawn;
        if (InvT)
        {
            if (x)
            {
                SpriteR.enabled = true;
                SpriteR_Hijo.enabled = true;
            }
            x = false;
            if (escala.x < max && !spawnScript.spawnerDone)
            {
                escala.x += 0.005f;
                escala.y += 0.005f;
                gameObject.transform.localScale = escala;
            }
            if (escala.x > 0 && spawnScript.spawnerDone)
            {
                escala.x -= 0.007f;
                escala.y -= 0.007f;
                gameObject.transform.localScale = escala;
            }
        }
    }
}
