using UnityEngine;
using UnityEngine.UI;

public class DigitalClock : MonoBehaviour
{
    public Text text;

    public ClockTime time;

    private void Update()
    {
        text.text = string.Format("{0:D2}:{1:D2}:{2:D2}", time.hour, time.minute, time.second);
    }
}
