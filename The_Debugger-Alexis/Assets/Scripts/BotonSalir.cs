using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonSalir : MonoBehaviour
{
    public void Exit()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
