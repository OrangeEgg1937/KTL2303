using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float timeLeft = 900;
    public bool startCountdown = false;

    private TextMeshProUGUI displayTime;
    [SerializeField] private GameEndProcess gameEndProcess;



    // Start is called before the first frame update
    void Start()
    {
        startCountdown = true;
        displayTime = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startCountdown && timeLeft >= 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateTIme(timeLeft);
        }else if(timeLeft <= 0){
            gameEndProcess.gameEnd(1);
        }
    }

    void UpdateTIme(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        displayTime.text = "Time left: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
