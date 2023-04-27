using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue_Portal : MonoBehaviour
{
    public GameObject PortalTrigger;

    private Queue<string> messages;
    private float[] seconds;
    private float[] velocity;
    private TMP_Text messageText;

    private bool PlayerDetected;
    private bool x;

    void Awake()
    {
        x = true;

        seconds = new float[8] { 3, 5, 5, 5, 4, 2, 4 ,2 };
        velocity = new float[8] { 0.06f, 0.05f, 0.05f, 0.05f, 0.05f, 0.06f, 0.05f, 0.06f };
        messages = new Queue<string>();

        messageText = transform.Find("Character_dialogue").GetComponent<TMP_Text>();
        PortalTrigger = GameObject.Find("Portal_Trigger");
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
        messages.Enqueue("Un portal, voy a poder salir de aqui?");
        messages.Enqueue("Lo siento pero la unica manera de salir es acabando la mision");
        messages.Enqueue("El hecho que hayan invadido este lugar significa que se han vuelto muy fuertes");
        messages.Enqueue("Si no los detenemos puede ser desastroso para computadoras alrededor del mundo");
        messages.Enqueue("Muy bien, supongo que no tengo otra opcion...");
        messages.Enqueue("Entonces comencemos");
        messages.Enqueue("Este portal te llevara a otro mundo infestado por bugs");
        messages.Enqueue("Buena suerte");

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
