using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

    public List<Checkpoint> checkpoints = new List<Checkpoint>();

    int checkpointCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (checkpointCount >= checkpoints.Count)
            {
                Debug.Log("completed");
            }
            else
            {
                if (checkpointCount == 0)
                {
                    checkpoints[checkpointCount].ActivateLight();
                    checkpointCount++;
                }
                else
                {
                    checkpoints[checkpointCount].ActivateLight();
                    checkpoints[checkpointCount - 1].DeactivateLight();
                    checkpointCount++;
                }
            }
        }
    }
}
