using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EmotionState
{
    protected GirlfriendAI girlFriendAI;
    protected EmotionStateMachine stateMachine;

    protected bool isExitingState;
    protected float startTime;

    public EmotionState(GirlfriendAI girlFriendAI, EmotionStateMachine stateMachine)
    {
        this.girlFriendAI = girlFriendAI;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        DoChecks();
        startTime = Time.time;
        //Debug.Log(animBoolName);
        isExitingState = false;
    }

    public virtual void Exit()
    {
        isExitingState = true;
    }

    public virtual void LogicUpdate()
    {
        if(girlFriendAI.Max == girlFriendAI.laugh)
        {
            stateMachine.ChangeState(girlFriendAI.JoyfulState);
        }
        else if (girlFriendAI.Max == girlFriendAI.anger)
        {
            stateMachine.ChangeState(girlFriendAI.AngryState);
        }
        else if (girlFriendAI.Max == girlFriendAI.fear)
        {
            stateMachine.ChangeState(girlFriendAI.FearfulState);
        }
        else if (girlFriendAI.Max == girlFriendAI.sadness)
        {
            stateMachine.ChangeState(girlFriendAI.SadState);
        }
        else
        {
            stateMachine.ChangeState(girlFriendAI.SurprisedState);
        }
    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }
    public virtual string DoStringMath(string input)
    {
        return "no!";
    }

    public virtual void DoEmotionMath(string input)
    {

    }

    public virtual void DoChecks() { }

    

}
