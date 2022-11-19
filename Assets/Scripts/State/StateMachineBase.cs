
using UnityEngine;

public class StateMachineBase<T> : MonoBehaviour where T : StateMachineBase<T>
{
    private StateBase<T> currentState;
    private StateBase<T> nextState;

    public bool ChangeState(StateBase<T> _nextState)
    {
        bool bRet = nextState == null;
        nextState = _nextState;
        return bRet;
    }


    private void Update()
    {
        if(nextState != null)
        {
            if(currentState != null)
            {
                currentState.OnEnterState();
            }
            currentState = nextState;
            currentState.OnEnterState();
            nextState = null;
        }

        if(currentState != null)
        {
            currentState.OnUpdate();

        }
    }
}
