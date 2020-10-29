using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Light light;
    public float lightIntensity = 10f;

    void Start()
    {
        light = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivateLight()
    {
        light.intensity = 0;

    }

    public void ActivateLight()
    {
        light.intensity = lightIntensity;
    }
}
