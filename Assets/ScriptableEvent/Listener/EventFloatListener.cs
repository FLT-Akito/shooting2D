using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[AddComponentMenu("Events/Event Float Listener")]
public class FloatEventListener : ScriptableEventListener<float>
{
    [SerializeField]
    protected EventFloat eventObject;

    [SerializeField]
    protected UnityEventFloat eventAction;

    protected override ScriptableEvent<float> ScriptableEvent
    {
        get
        {
            return eventObject;
        }
    }

    protected override UnityEvent<float> Action
    {
        get
        {
            return eventAction;
        }
    }
}
