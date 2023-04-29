using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarRotacion : MonoBehaviour
{
    private Vector3 objetivo;

    private SpriteRenderer SpriteRenderer;

    [SerializeField] private Camera camara;
    [SerializeField] private float anguloInicial;
    public float anguloGrados;

    private Transform barrel;
    private Transform effect;

    int y = 0;

    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        
        Transform childBarrel = transform.Find("ControladorDisparo");
        Transform childEffect = transform.Find("Gun_fire");

        barrel = childBarrel.GetComponent<Transform>();
        effect = childEffect.GetComponent<Transform>();
        
    }

    private void Update()
    {
        objetivo = camara.ScreenToWorldPoint(Input.mousePosition);

        float anguloRadianes = Mathf.Atan2(objetivo.y - transform.position.y, objetivo.x - transform.position.x);
        anguloGrados = (180 / Mathf.PI) * anguloRadianes - anguloInicial;
        transform.rotation = Quaternion.Euler(0, 0, anguloGrados);
    }

    void FixedUpdate()
    {
        if (anguloGrados < 80 && anguloGrados > -80)
        {
            SpriteRenderer.flipY = false;
            if(y == 1)
            {
                AdjustFireUp();
            }
        }
        else if (anguloGrados > 80 || anguloGrados < -80)
        {
            SpriteRenderer.flipY = true;
            if(y == 0)
            {
                AdjustFireDown();
            }
        }
    }

    private void AdjustFireDown()
    {
        effect.localPosition = new Vector3(effect.localPosition.x, -0.02f, effect.localPosition.z);
        barrel.localPosition = new Vector3(barrel.localPosition.x, -0.02f, barrel.localPosition.z);
        y = 1;
    }

    private void AdjustFireUp()
    {
        effect.localPosition = new Vector3(effect.localPosition.x, 0.02f, effect.localPosition.z);
        barrel.localPosition = new Vector3(barrel.localPosition.x, 0.02f, barrel.localPosition.z);
        y = 0;
    }
}