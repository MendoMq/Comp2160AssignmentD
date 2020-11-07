using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float CurrentHealth
    {
        private set;
        get;
    }
    public float healthRestoreAmount;


    [Range(0, 1)]
    public float smokeThreshold;
    public float collisionForceMinimum = 3f;
    public bool PlayerDied
    {
        private set;
        get;
    }

    CheckpointManager cm;

    void Start()
    {
        cm = FindObjectOfType<CheckpointManager>();
        CurrentHealth = maxHealth;
        PlayerDied = false;
        Debug.Log("Smoke when health is below " + (maxHealth * smokeThreshold));
    }

    void Update()
    {
        // Player death
        if (CurrentHealth <= 0 && PlayerDied != true)
        {
            PlayerDied = true;
        }

        // Restore health
        if (cm.Checkpoints[cm.CheckpointTargetCount].ActiveCheckpoint
            && !cm.FinalCheckpointReached)
        {
            CurrentHealth += healthRestoreAmount;
            Debug.Log("Health increased by " + healthRestoreAmount);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10) // Obstacle layer
        {
            Debug.Log("COLLISION!");
            float collisionForce = collision.relativeVelocity.magnitude;
            if (collisionForce > collisionForceMinimum)
            {
                Debug.Log("Collision force " + collisionForce + " is higher than " +
                    collisionForceMinimum + ". Health minus " + collisionForce);
                CurrentHealth -= collisionForce;
                
            }
            else
            {
                Debug.Log("Collision force " + collisionForce + " is lower than " +
                    collisionForceMinimum + ". No health lost");
            }
        }
    }
}
