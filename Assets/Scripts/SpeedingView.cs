using UnityEngine;
using UnityEngine.UI;

public class SpeedingView : MonoBehaviour
{
    [SerializeField]
    private Text _speedText;

    public void UpdateSpeed(float updatedSpeed)
    {
        _speedText.text = "Speed: " + updatedSpeed.ToString("F1");
    }
}
