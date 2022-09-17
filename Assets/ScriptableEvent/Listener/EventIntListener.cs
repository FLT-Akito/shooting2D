using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[AddComponentMenu("Events/Event Int Listener")]
public class EventIntListener : ScriptableEventListener<int>
{
    [SerializeField]
    protected EventInt eventObject;

    [SerializeField]
    protected UnityEventInt eventAction;

    protected override ScriptableEvent<int> ScriptableEvent
    {
        get
        {
            return eventObject;
        }
    }

    protected override UnityEvent<int> Action
    {
        get
        {
            return eventAction;
        }
    }
}
