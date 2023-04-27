using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Portal : MonoBehaviour
{
    public GameObject PortalTrigger;

    public RawImage DialoguePanelPlayer;
    public RawImage DialoguePanelAI;
    private TMP_Text messageText;

    private bool PlayerDetected;
    private bool x;

    void Start()
    {
        x = true;
        PortalTrigger = GameObject.Find("Portal_Trigger");
        messageText = transform.Find("DialogueManager").Find("Character_dialogue").GetComponent<TMP_Text>();
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
        yield return new WaitForSeconds(0.5f);
        messageText.enabled = true;
        DialoguePanelPlayer.enabled = true;
        yield return new WaitForSeconds(3f);
        DialoguePanelAI.enabled = true;
        DialoguePanelPlayer.enabled = false;
        yield return new WaitForSeconds(15f);
        DialoguePanelAI.enabled = false;
        DialoguePanelPlayer.enabled = true;
        yield return new WaitForSeconds(4f);
        DialoguePanelAI.enabled = true;
        DialoguePanelPlayer.enabled = false;
        yield return new WaitForSeconds(8f);
        DialoguePanelAI.enabled = false;
        messageText.enabled = false;
    }
}
