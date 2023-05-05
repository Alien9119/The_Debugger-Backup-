using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Control : MonoBehaviour
{
    public AudioSource Track1;
    public AudioSource Track2;
    public AudioSource Track3;
    //public AudioSource Track4;

    void Start()
    {
        StartCoroutine(TracksDuration());
    }

    IEnumerator TracksDuration()
    {
        yield return new WaitForSeconds(8f);
        Track1.Play();
        yield return new WaitForSeconds(164f);
        Track1.Stop();
        Track2.Play();
        yield return new WaitForSeconds(112f);
        Track2.Stop();
        Track3.Play();
        //yield return new WaitForSeconds(112f);
        //Track4.Play();
        //Track3.Stop();
    }
}
