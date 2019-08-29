using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatChangedEvent : ScriptableObject
{
    private List<FloatChangedWatcher> _watchers = new List<FloatChangedWatcher>();

    public void Raise(float value)
    {
        for(int i = _watchers.Count - 1; i >= 0; i--)
            _watchers[i].OnFloatChanged(value);
    }

    public void AddWatcher(FloatChangedWatcher watcher)
    {
        _watchers.Add(watcher);
    }

    public void RemoveWatcher(FloatChangedWatcher watcher)
    {
        int lastIndex = _watchers.LastIndexOf(watcher);
        _watchers.RemoveAt(lastIndex);
    }
}
