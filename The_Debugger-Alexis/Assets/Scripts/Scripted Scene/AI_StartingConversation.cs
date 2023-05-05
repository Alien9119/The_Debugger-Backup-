using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_StartingConversation : MonoBehaviour
{
    private SpriteRenderer SpriteR;
    private AudioSource AIAppear;

    void Start()
    {
        SpriteR = GetComponent<SpriteRenderer>();
        StartCoroutine(EventsTimeline());
        AIAppear = GetComponent<AudioSource>();
    }

    IEnumerator EventsTimeline()
    {
        yield return new WaitForSeconds(8f);
        SpriteR.enabled = true;
        AIAppear.Play();
        yield return new WaitForSeconds(44f);
        SpriteR.enabled = false;
    }
}
