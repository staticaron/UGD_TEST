using UnityEngine;
using System;

public enum TimerState { ON, OFF };

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    [SerializeField] float maxTime;
    [SerializeField] float timeLeft;

    [SerializeField] TimerState timerState = TimerState.OFF;

    private void Awake()
    {
        #region Maintain a single instance
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
        #endregion
    }

    public void Start()
    {
        //TODO Do some sort of counting
        timeLeft = maxTime;
        timerState = TimerState.ON;
    }

    private void Update()
    {
        if (timerState == TimerState.ON)
        {
            timeLeft -= Time.deltaTime;
        }
    }

    public string GetTimeLeft()
    {
        string t;

        t = Convert.ToString(Math.Round((double)timeLeft, 2));

        return t;
    }
}
