using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countDownTimer;
    public GameManager gamemanager;
    private float counter = 100;

    // Start is called before the first frame update
    void Start()
    {
        countDownTimer.text = $"Time: {counter}";
    }

    private void Update()
    {
        if (counter == 0)
        {
            countDownTimer.color = Color.red;
        }
        else if (counter <= 10)
        {
            countDownTimer.color = Color.yellow;
        }
    }

    public void runTimer()
    {
        if (counter > 0)
        {
            counter -= Time.deltaTime;
            countDownTimer.text = $"Time: {Mathf.Round(counter)}";
        }
        else
        {
            gamemanager.Failed();
        }
        
    }
}
