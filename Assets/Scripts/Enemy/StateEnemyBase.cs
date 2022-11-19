using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class StateEnemyBase : StateMachineBase<StateEnemyBase>
{
    public ZakoStopAndGo zakoStopGo;
    public static ZakoStopAndGo ZakoStopGo => ZakoStopGo;
    private Vector3 dir;

    private void Start()
    {

        ChangeState(new StateEnemyBase.MoveLeft(this));
    }

    

    private sealed class MoveLeft : StateBase<StateEnemyBase>
    {
        public MoveLeft(StateEnemyBase _machine) : base(_machine)
        {
        }

        public override void OnUpdate()
        {
           if(ZakoStopGo.IsCameraVeiw())
            {
                Debug.Log("aaa");
            }
        }
    }
}
