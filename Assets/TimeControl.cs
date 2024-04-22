using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using Inworld;

public class TimeControl : MonoBehaviour
{
    public float timeLeft = 180;
    public bool startCountdown = true;

    [SerializeField] private TextMeshProUGUI m_countdownText;
    [SerializeField] private bool isSkip = false;
    [SerializeField] private GameProcesser process;

    void Update()
    {
        if (startCountdown)
        {
            if (timeLeft >= 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTIme(timeLeft);
            }
            else
            {
                startCountdown = false;
                process.ProcessPostMurderEvent();
            }
        }
    }

    public void endCountDownNow()
    {

        isSkip = true;
    }

    void UpdateTIme(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        m_countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if(isSkip)
        {
            timeLeft = -1;
            m_countdownText.text = string.Format("{0:00}:{1:00}", 0, 0);
        }
    }
}
