using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    // Checkpoints to get (0 being first, the end being last)
    public List<Checkpoint> Checkpoints
    {
        private set;
        get;
    }
    // What checkpoint is next? 0 = first checkpoint, 1 = second, etc
    public int CheckpointTargetCount
    {
        private set;
        get;
    }
    public bool FinalCheckpointReached
    {
        private set;
        get;
    }

    Health playerHealth;

    void Start()
    {
        Checkpoints = new List<Checkpoint>();
        playerHealth = FindObjectOfType<Health>();
        FinalCheckpointReached = false;
        CheckpointTargetCount = 0;

        if (transform.childCount < 1)
        {
            Debug.Log("Make sure there is at least 2 children that are Checkpoints");
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            // If the child is a checkpoint
            Checkpoint checkpoint = transform.GetChild(i).GetComponent<Checkpoint>();
            if (checkpoint)
            {
                Checkpoints.Add(checkpoint);
            }
        }

        Checkpoints[0].ActivateLight();
    }

    void Update()
    {
        // Waits until x checkpoint becomes active
        if (Checkpoints[CheckpointTargetCount].ActiveCheckpoint && !FinalCheckpointReached)
        {
            playerHealth.RestoreHealth();

            if (CheckpointTargetCount == 0) // First checkpoint
            {
                Checkpoints[CheckpointTargetCount].DeactivateLight();
                CheckpointTargetCount++;
                Checkpoints[CheckpointTargetCount].ActivateLight();
            }
            else if (CheckpointTargetCount >= Checkpoints.Count - 1) // Final checkpoint
            {
                Checkpoints[CheckpointTargetCount].DeactivateLight();
                FinalCheckpointReached = true;
                Debug.Log("Level completed");
            }
            else // Checkpoints in between
            {
                Checkpoints[CheckpointTargetCount].DeactivateLight();
                CheckpointTargetCount++;
                Checkpoints[CheckpointTargetCount].ActivateLight();
            }
        }
    }
}
