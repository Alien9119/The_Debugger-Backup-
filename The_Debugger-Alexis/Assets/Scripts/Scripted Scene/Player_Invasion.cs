using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Invasion : MonoBehaviour
{

    public GameObject Gun;
    public GameObject InvasionTrigger;

    private Disparo shootScript;
    private CharMovements moveScript;

    private bool PlayerDetected;
    private bool x;

    void Start()
    {
        x = true;
        InvasionTrigger = GameObject.Find("Invasion_Trigger");
        shootScript = GetComponentInChildren<Disparo>();
        moveScript = GetComponent<CharMovements>();
    }

    void Update()
    {
        PlayerDetected = InvasionTrigger.GetComponent<Detector>().playerDetected;
        if (PlayerDetected)
        {
            if (x)
            {
                StartCoroutine(EventsTimeline());
            }
            x = false;
        }
    }

    IEnumerator EventsTimeline()
    {
        moveScript.canMove = false;
        shootScript.canShoot = false;
        yield return new WaitForSeconds(17f);
        moveScript.canMove = true;
        shootScript.canShoot = true;
    }
}