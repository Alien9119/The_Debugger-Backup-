using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**

public class CameraShake : MonoBehaviour
{
    private Vector3 originPosition;
    private Quaternion originRotation;
 
    float shake_decay;
    float shake_intensity;
 
    void OnGUI()
    {
        if (GUI.Button(Rect(20, 40, 80, 20), "Shake"))
        {
            Shake();
        }
    }

    void Update()
    {
        if (shake_intensity > 0)
        {
            transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
            transform.rotation = Quaternion(
                            originRotation.x + Random.Range(-shake_intensity, shake_intensity) * .2,
                            originRotation.y + Random.Range(-shake_intensity, shake_intensity) * .2,
                            originRotation.z + Random.Range(-shake_intensity, shake_intensity) * .2,
                            originRotation.w + Random.Range(-shake_intensity, shake_intensity) * .2);
            shake_intensity -= shake_decay;
        }
    }

    private void Shake()
    {
        originPosition = transform.position;
        originRotation = transform.rotation;
        shake_intensity = .3;
        shake_decay = 0.002;
    }
}

**/