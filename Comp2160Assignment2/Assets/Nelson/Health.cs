using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;

    public LayerMask checkpoint;
    public LayerMask[] obstacles;

    [Range(0,1)]
    public float smokeThreshold;

    public float healthRestoreAmount;

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Smoke when health is below " + (maxHealth * smokeThreshold));
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            float collisionForce = collision.relativeVelocity.magnitude;
            currentHealth -= collisionForce;
            Debug.Log("Health -= " + collisionForce + ". Current health: " + currentHealth);
        }
    }

    public void RestoreHealth()
    {
        currentHealth += healthRestoreAmount;
        Debug.Log("Health increased by " + healthRestoreAmount);
    }
}
