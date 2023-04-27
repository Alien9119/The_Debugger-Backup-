using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Portal : MonoBehaviour
{
    public GameObject Gun;
    public GameObject PortalTrigger;

    private Disparo_Delay shootScript;
    private CharMovements moveScript;
    public ActivateFireEffect effectScript;

    private bool PlayerDetected;
    private bool x;

    void Start()
    {
        x = true;
        PortalTrigger = GameObject.Find("Portal_Trigger");
        shootScript = Gun.GetComponentInChildren<Disparo_Delay>();
        moveScript = GetComponent<CharMovements>();
    }

    void Update()
    {
        PlayerDetected = PortalTrigger.GetComponent<Detector>().playerDetected;
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
        effectScript.canShoot = false;
        yield return new WaitForSeconds(28.5f);
        moveScript.canMove = true;
        shootScript.canShoot = true;
        effectScript.canShoot = true;
    }
}
