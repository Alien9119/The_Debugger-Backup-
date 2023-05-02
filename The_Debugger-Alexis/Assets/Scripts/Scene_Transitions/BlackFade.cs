using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackFade : MonoBehaviour
{
    [SerializeField] public float TimeDisable;
    private Image square;
    
    void Start()
    {
        square = GetComponent<Image>();
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(TimeDisable);
        square.enabled = false;
    }
}
