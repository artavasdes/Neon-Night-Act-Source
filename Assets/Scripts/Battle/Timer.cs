using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public float TimeLeft = 200.0F;
    public bool TimerOn = false;

    public TextMeshProUGUI TimerText;
    // void Start()
    // {
    //     TimerOn = true;
    // }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                updateTimer(TimeLeft);
                TimeLeft -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time is Up!");
                TimeLeft = 0;
                TimerOn = false;
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime -= 1;

        TimerText.text = currentTime.ToString("N0");
    }

}
