using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Timer timer;

    // Update is called once per frame
    void Update()
    {
        timer.runTimer();
    }

    public void Failed()
    { Debug.Log("You Failed!!");
    }
}
