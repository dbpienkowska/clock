using UnityEngine;

public class AnalogClock : MonoBehaviour
{
    public ClockTime time;

    public bool isHourUpdateContinuous = true;
    public bool isMinuteUpdateContinuous = true;
    public bool isSecondUpdateContinuous = false;
    
    [SerializeField]
    private Transform _hoursTransform;
    [SerializeField]
    private Transform _minutesTransform;
    [SerializeField]
    private Transform _secondsTransform;

    private const float _degreesPerHour = 360f / 12f; 
    private const float _degreesPerMinute = 360f / 60f;
    private const float _degreesPerSecond = 360f / 60f;

    private void Update()
    {
        float hourDegrees = (isHourUpdateContinuous ? time.totalHours: time.hour) * _degreesPerHour;
        float minuteDegrees = (isMinuteUpdateContinuous ? time.totalMinutes: time.minute) * _degreesPerMinute;
        float secondDegress = (isSecondUpdateContinuous ? time.totalSeconds : time.second) * _degreesPerSecond;

        _Rotate(hourDegrees, minuteDegrees, secondDegress);
    }

    private void _Rotate(float hourDegrees, float minuteDegrees, float secondDegrees)
    {
        _hoursTransform.localRotation = Quaternion.Euler(0f, hourDegrees, 0f);
        _minutesTransform.localRotation = Quaternion.Euler(0f, minuteDegrees, 0f);
        _secondsTransform.localRotation = Quaternion.Euler(0f, secondDegrees, 0f);
    }
}
