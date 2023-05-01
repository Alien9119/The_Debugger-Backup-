using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Text_Survive : MonoBehaviour
{
    private TMP_Text messageText;

    void Start()
    {
        messageText = transform.Find("DialogueManager").Find("Character_dialogue").GetComponent<TMP_Text>();
        StartCoroutine(EventsTimeline());
    }

    IEnumerator EventsTimeline()
    {
        messageText.enabled = true;

        yield return new WaitForSeconds(6f);

        messageText.enabled = false;
    }
}
