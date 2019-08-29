using System;
using UnityEngine;

public class ClockTime : MonoBehaviour
{
    public const int HOURS_PER_DAY = 24;
    public const int MINUTES_PER_HOUR = 60;
    public const int SECONDS_PER_MINUTE = 60;
    public const int SECONDS_PER_HOUR = SECONDS_PER_MINUTE * MINUTES_PER_HOUR;
    public const int SECONDS_PER_DAY = HOURS_PER_DAY * MINUTES_PER_HOUR * SECONDS_PER_MINUTE;

    public int hour => (int)totalHours;
    public int minute => (int)(totalMinutes % MINUTES_PER_HOUR);
    public int second => (int)(totalSeconds % SECONDS_PER_MINUTE);

    public bool initWithCurrentTime;

    public float totalHours;
    public float totalMinutes;
    public float totalSeconds;

    public float speed { get => _speed; private set { _speed = value; } }

    [SerializeField]
    private float _speed;

    [SerializeField]
    private FloatChangedEvent _onSpeedChanged;

    private void Awake()
    {
        if(initWithCurrentTime)
        {
            TimeSpan span = DateTime.Now.TimeOfDay;
            totalSeconds = (float)span.TotalSeconds;
            totalMinutes = (float)span.TotalMinutes;
            totalHours = (float)span.TotalHours;
        }
    }

    private void Update()
    {
        AddSeconds(Time.deltaTime * speed);
    }

    public void AddSpeed(float value)
    {
        speed += value;
        _onSpeedChanged?.Raise(speed);
    }

    public void SetSpeed(float value)
    {
        speed = value;
        _onSpeedChanged?.Raise(speed);
    }

    public void SetTime(int hour, int minute, int second)
    {
        totalSeconds = SECONDS_PER_HOUR * hour + SECONDS_PER_MINUTE * minute + second;
        totalMinutes = totalSeconds / SECONDS_PER_MINUTE;
        totalHours = totalMinutes / MINUTES_PER_HOUR;
    }

    public void AddSeconds(float seconds)
    {
        if(totalSeconds + seconds < 0)
            totalSeconds = SECONDS_PER_DAY + totalSeconds + seconds;
        else
            totalSeconds = (totalSeconds + seconds) % SECONDS_PER_DAY;
        totalMinutes = totalSeconds / SECONDS_PER_MINUTE;
        totalHours = totalMinutes / MINUTES_PER_HOUR;
    }
}
