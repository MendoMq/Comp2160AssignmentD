using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Light checkpointLight;
    public float lightIntensity = 10f;
    public bool CompletedCheckpoint
    {
        private set;
        get;
    }

    SphereCollider sphereCollider;

    void Start()
    {
        checkpointLight = GetComponentInChildren<Light>();
        sphereCollider = GetComponent<SphereCollider>();

        sphereCollider.enabled = false;
        CompletedCheckpoint = false;
    }

    // Can't interact with this checkpoint anymore
    public void DeactivateLight()
    {
        checkpointLight.intensity = 0;
        sphereCollider.enabled = false;
    }

    public void ActivateLight()
    {
        checkpointLight.intensity = lightIntensity;
        sphereCollider.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("CHECKPOINT");
        CompletedCheckpoint = true;
    }
}
