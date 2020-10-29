using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

    private List<Checkpoint> checkpoints = new List<Checkpoint>();

    private int checkpointCount = 0;

    Health playerHealth;

    bool finalCheckpointReached = false;

    void Start()
    {
        playerHealth = FindObjectOfType<Health>();

        for (int i = 0; i < transform.childCount; i++)
        {
            // If the child is a checkpoint
            Checkpoint checkpoint = transform.GetChild(i).GetComponent<Checkpoint>();
            if (checkpoint)
            {
                checkpoints.Add(checkpoint);
            }
        }
    }

    void Update()
    {
        if (checkpoints[checkpointCount].ActiveCheckpoint && !finalCheckpointReached)
        {
            playerHealth.RestoreHealth();

            if (checkpointCount == 0) // First checkpoint
            {
                checkpoints[checkpointCount].ActivateLight();
                checkpointCount++;
            }
            else if (checkpointCount >= checkpoints.Count - 1) // Final checkpoint
            {
                checkpoints[checkpointCount].ActivateLight();
                checkpoints[checkpointCount - 1].DeactivateLight();
                finalCheckpointReached = true;
                Debug.Log("Level completed");
            }
            else // Checkpoints in between
            {
                checkpoints[checkpointCount].ActivateLight();
                checkpoints[checkpointCount - 1].DeactivateLight();
                checkpointCount++;
            }
        }
    }
}
