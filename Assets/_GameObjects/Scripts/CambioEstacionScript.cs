using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioEstacionScript : MonoBehaviour {
    float currentR;
    float currentG;
    float currentB;
    float targetRWinter = 0.10f;
    bool toWinter = false;

    private void Awake()
    {
        currentR = RenderSettings.ambientLight.r;
        currentG = RenderSettings.ambientLight.g;
        currentB = RenderSettings.ambientLight.b;
    }

    // Update is called once per frame
    void Update()
    {
        if (toWinter && currentR > targetRWinter)
        {
            currentR -= 0.01f;
            RenderSettings.ambientLight = new Color(currentR, currentG, currentB);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        toWinter = true;
    }

}
