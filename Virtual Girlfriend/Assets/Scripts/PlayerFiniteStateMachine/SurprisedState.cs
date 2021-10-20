using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurprisedState : EmotionState
{
    public SurprisedState(GirlfriendAI girlFriendAI, EmotionStateMachine stateMachine) : base(girlFriendAI, stateMachine)
    {
    }

    public override string DoStringMath(string input)
    {
        switch(input)
        {
            case var s when input.Contains("!"):
                girlFriendAI.anger += 20;
                return "Tabii ki!";
            case var s when input.Contains("?"):
                return "maybe tomorrow";
            default:
                return "Sooo happyyy";
        }
    }

    public override void DoEmotionMath(string input)
    {
        base.DoEmotionMath(input);
    }
}
