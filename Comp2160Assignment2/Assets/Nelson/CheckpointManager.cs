using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

    List<Checkpoint> checkpoints = new List<Checkpoint>();

    int checkpointCount = 0;

    void Start()
    {
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
        if (checkpoints[checkpointCount].ActiveCheckpoint)
        {
            if (checkpointCount == 0) // First checkpoint
            {
                checkpoints[checkpointCount].ActivateLight();
                checkpointCount++;
            }
            else if (checkpointCount >= checkpoints.Count - 1) // Final checkpoint
            {
                checkpoints[checkpointCount].ActivateLight();
                checkpoints[checkpointCount - 1].DeactivateLight();
                Debug.Log("completed");
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
