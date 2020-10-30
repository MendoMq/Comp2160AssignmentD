﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Light light;
    public float lightIntensity = 10f;
    public bool ActiveCheckpoint
    {
        private set;
        get;
    }

    void Start()
    {
        light = GetComponentInChildren<Light>();
        ActiveCheckpoint = false;
    }

    // Can't interact with this checkpoint anymore
    public void DeactivateLight()
    {
        light.intensity = 0;
        SphereCollider sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.enabled = false;
    }

    public void ActivateLight()
    {
        light.intensity = lightIntensity;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            Debug.Log("CHECKPOINT");
            ActiveCheckpoint = true;
        }
    }
}
