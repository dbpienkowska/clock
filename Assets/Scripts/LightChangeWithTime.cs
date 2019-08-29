using UnityEngine;

public class LightChangeWithTime : MonoBehaviour
{
    public AnimationCurve curve;

    [SerializeField]
    private Light _light;
    [SerializeField]
    private ClockTime _time;

    private Vector3 _initEulers;

    private void Awake()
    {
        _initEulers = _light.transform.localEulerAngles;
    }

    private void Update()
    {
        float evaluation = _time.totalHours / ClockTime.HOURS_PER_DAY;
        float curveValue = curve.Evaluate(evaluation);

        _light.intensity = curveValue;

        if(evaluation < 0.5f)
            _light.transform.localRotation = Quaternion.Euler(_initEulers.x, 180f - curveValue * 180f, _initEulers.z);
        else
            _light.transform.localRotation = Quaternion.Euler(_initEulers.x, curveValue * 180f - 180f, _initEulers.z);
    }
}
