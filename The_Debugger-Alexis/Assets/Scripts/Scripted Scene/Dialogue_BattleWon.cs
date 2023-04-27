using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue_BattleWon : MonoBehaviour
{
    public Enemy_Spawning spawnScript;

    private Queue<string> messages;
    private float[] seconds;
    private float[] velocity;
    private TMP_Text messageText;


    private bool x;

    void Awake()
    {
        x = true;

        seconds = new float[2] { 2, 2 };
        velocity = new float[2] { 0.05f, 0.06f };
        messages = new Queue<string>();

        messageText = transform.Find("Character_dialogue").GetComponent<TMP_Text>();
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
        messages.Enqueue("Buen trabajo");
        messages.Enqueue("Prosigue al siguiente cuarto");

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
