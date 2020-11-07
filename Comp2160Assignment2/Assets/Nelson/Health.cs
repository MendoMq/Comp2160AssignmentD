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

    public float collisionCooldown = 1f;
    private float collisionCooldownTimer;

    CheckpointManager cm;
    ParticleSystem smokeParticle;
    public ParticleSystem deathExplosionParticle;

    void Start()
    {
        cm = FindObjectOfType<CheckpointManager>();
        smokeParticle = GetComponentInChildren<ParticleSystem>();

        CurrentHealth = maxHealth;
        PlayerDied = false;
        smokeParticle.Stop();
    }

    void Update()
    {
        // Player death
        if (CurrentHealth <= 0 && PlayerDied != true)
        {
            PlayerDied = true;
            Instantiate(deathExplosionParticle, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }

        // Start smoke when below certain amount
        if (CurrentHealth < (maxHealth * smokeThreshold))
        {
            if (smokeParticle.isStopped)
            {
                smokeParticle.Play();
            }
        }

        // Restore health
        if (cm.Checkpoints[cm.CheckpointTargetCount].CompletedCheckpoint
            && !cm.FinalCheckpointReached)
        {
            CurrentHealth += healthRestoreAmount;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);
        }

        // Countsdown before another collision can be detected
        if (collisionCooldownTimer > 0)
        {
            collisionCooldownTimer -= Time.deltaTime;
        }
        else
        {
            collisionCooldownTimer = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // If you collide with an obstacle, cooldown is 0, and you haven't won yet
        if (collision.gameObject.layer == 10 && collisionCooldownTimer == 0
            && !cm.FinalCheckpointReached)
        {
            collisionCooldownTimer = collisionCooldown;
            float collisionForce = collision.relativeVelocity.magnitude;

            if (collisionForce > collisionForceMinimum)
            {
                CurrentHealth -= collisionForce;
            }

        }
    }
}
