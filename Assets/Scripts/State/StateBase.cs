
using UnityEngine;

public class StateBase<T> where T : StateMachineBase<T>
{
    public T machine;

    public StateBase(T _machine)
    {
        machine = _machine;
    }

    /// <summary>
	/// ステートを開始した時に呼ばれる
	/// </summary>
    public virtual void OnEnterState() { }
    /// <summary>
    /// 毎フレーム呼ばれる
    /// </summary>
    public virtual void OnUpdate() { }
    /// <summary>
	/// ステートを終了した時に呼ばれる
	/// </summary>
    public virtual void OnExitState() { }
}
