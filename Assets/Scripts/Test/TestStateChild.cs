using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStateChild : TestState
{
    public int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(new SetUp(this));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private class SetUp : StateBase<TestState>
    {
        TestStateChild child;
        public SetUp(TestState _machine) : base(_machine)
        {
            child = (TestStateChild)_machine;
        }

        public override void OnEnterState()
        {
            int a = child.num;
        }
    }
}
