using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShotState : StateMachineBase<LaserShotState>
{
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(new Neutral(this));
    }

    private class Neutral : StateBase<LaserShotState>
    {
        public Neutral(LaserShotState _laser) : base(_laser)
        {
        }


    }

    private class Firing : StateBase<LaserShotState>
    {
        public Firing(LaserShotState _laser) :  base(_laser)
        {
        }
    }

    private class Afterlaunch : StateBase<LaserShotState>
    {
        public Afterlaunch(LaserShotState _laser) : base(_laser)
        {
        }
    }
}
