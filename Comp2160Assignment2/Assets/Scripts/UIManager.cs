using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Slider healthBar;
    public Health player;
    private float timer;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = player.CurrentHealth / player.maxHealth;

        timer += Time.deltaTime;
        timerText.text = timer.ToString("F2");
    }
}
