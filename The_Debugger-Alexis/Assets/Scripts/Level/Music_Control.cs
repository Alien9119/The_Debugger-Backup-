using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Control : MonoBehaviour
{
    public AudioSource Track1;
    public AudioSource Track2;

    void Start()
    {
        StartCoroutine(Track1Duration());
    }

    IEnumerator Track1Duration()
    {
        yield return new WaitForSeconds(180);
        Track1.Stop();
        Track2.Play();
    }
}
