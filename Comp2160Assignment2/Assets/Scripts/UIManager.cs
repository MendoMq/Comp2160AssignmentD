using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    Slider healthBar;
    Health player;
    private float timer;
    public Text uiTimer;
    string timeText;
    bool gameOver=false;

    CheckpointManager checkpointManager;

    List<string> TimeList = new List<string>();
    int targetCount =0;

    public Text resultText;
    public Text checkpointText;
    string checkpointString;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        checkpointManager = FindObjectOfType<CheckpointManager>();
        healthBar = FindObjectOfType<Slider>();
        player = FindObjectOfType<Health>();
    }

    // Update is called once per frame
    void Update()
    {


        healthBar.value = player.CurrentHealth / player.maxHealth;
        if(!gameOver)
        {
            timer += Time.deltaTime;
        }
        

        int intTimer = (int)timer;
        int minutes = intTimer / 60;
        int seconds = intTimer % 60;
        float fraction = timer * 1000;
        fraction = (fraction % 1000);
        string timeText = string.Format ("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
        
        uiTimer.text = timeText;

        if(checkpointManager.Checkpoints[targetCount].CompletedCheckpoint && !checkpointManager.FinalCheckpointReached)
        {
            Debug.Log("POINT NUMBER "+ (targetCount+1) +" REACHED");

            TimeList.Add(timeText);
            Debug.Log(TimeList[targetCount]);
            if(targetCount < checkpointManager.Checkpoints.Count-1){
                Debug.Log("increment");
                targetCount++;
            }
        }

        if(checkpointManager.FinalCheckpointReached && !gameOver)
        {
            Debug.Log("FINAL POINT REACHED");
            TimeList.Add(timeText);
            Debug.Log(TimeList[TimeList.Count-1]);
            gameOverScreen();
        }

        if(player.PlayerDied && !gameOver)
        {
            gameOverScreen();
        }
    }

    public void gameOverScreen()
    {
        gameOver = true;
        if(player.PlayerDied)
        {
            resultText.text = "You Lost!";
        }
        else
        {
            resultText.text = "You Won!";
        }
        gameOverPanel.SetActive(true);
        for(int i =0;i<TimeList.Count;i++){
            checkpointString += "Checkpoint "+(i+1)+": "+TimeList[i] + "\n";
        }
        checkpointText.text = checkpointString;
    }
}
