
using UnityEngine;

public class StateBase<T> where T : StateMachineBase<T>
{
    public T machine;

    public StateBase(T _machine)
    {
        machine = _machine;
    }

    /// <summary>
	/// �X�e�[�g���J�n�������ɌĂ΂��
	/// </summary>
    public virtual void OnEnterState() { }
    /// <summary>
    /// ���t���[���Ă΂��
    /// </summary>
    public virtual void OnUpdate() { }
    /// <summary>
	/// �X�e�[�g���I���������ɌĂ΂��
	/// </summary>
    public virtual void OnExitState() { }
}
