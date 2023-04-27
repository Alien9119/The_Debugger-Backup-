using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * Autor: Alexis Hernández
 * Código que vincula el botón el el menu que dice "jugar" para empezar el juego
 **/

public class BotonJugar : MonoBehaviour
{
    public Image black;
    public Animator anim;

    public void RunGame()
    {
        black.enabled = true;
        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("StartingGame");
    }
}
