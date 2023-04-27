using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_InvasionEnd : MonoBehaviour
{
    public Enemy_Spawning spawnScript;

    public RawImage DialoguePanelPlayer;
    public RawImage DialoguePanelAI;
    private TMP_Text messageText;

    private bool x;

    void Start()
    {
        x = true;
        messageText = transform.Find("DialogueManager").Find("Character_dialogue").GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (spawnScript.spawnerDone && spawnScript.enemiesInRoom == 0)
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
        yield return new WaitForSeconds(1f);
        messageText.enabled = true;
        DialoguePanelAI.enabled = true;
        yield return new WaitForSeconds(4f);
        DialoguePanelAI.enabled = false;
        messageText.enabled = false;
    }
}
