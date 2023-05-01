using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue_Surviv : MonoBehaviour
{
    private Queue<string> messages;
    private float[] seconds;
    private float[] velocity;
    private TMP_Text messageText;

    void Awake()
    {
        seconds = new float[1] { 6 };
        velocity = new float[1] { 0.12f };
        messages = new Queue<string>();
        messageText = transform.Find("Character_dialogue").GetComponent<TMP_Text>();
    }

    void Start()
    {
        StartCoroutine(EventsTimeline());
    }

    IEnumerator EventsTimeline()
    {
        yield return new WaitForSeconds(2f);
        messages.Enqueue("OBJETIVO: SOBREVIVE");

        int index = 0;
        int index1 = 0;

        while (messages.Count > 0)
        {
            float textSpeed = velocity[index1];
            string message = messages.Dequeue();
            DialogueWriter.AddWriter_Static(messageText, message, textSpeed, true);
            yield return new WaitForSeconds(seconds[index]);
            index = (index + 1) % seconds.Length;
            index1 = (index1 + 1) % velocity.Length;
        }
    }
}