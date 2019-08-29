using UnityEngine;
using UnityEngine.Events;

public class FloatChangedWatcher : MonoBehaviour
{
    public FloatChangedEvent floatChangedEvent;
    public FloatAction action;

    public void OnFloatChanged(float value)
    {
        action.Invoke(value);
    }

    private void OnEnable()
    {
        floatChangedEvent.AddWatcher(this);
    }

    private void OnDisable()
    {
        floatChangedEvent.RemoveWatcher(this);
    }
}

[System.Serializable]
public class FloatAction : UnityEvent<float> {}
