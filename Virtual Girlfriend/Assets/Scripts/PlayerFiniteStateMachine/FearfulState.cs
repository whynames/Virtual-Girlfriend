using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearfulState : EmotionState
{
    public FearfulState(GirlfriendAI girlFriendAI, EmotionStateMachine stateMachine) : base(girlFriendAI, stateMachine)
    {
    }

    // Start is called before the first frame update
    public override string DoStringMath(string input)
    {
        return "fear";
    }

    public override void DoEmotionMath(string input)
    {
        base.DoEmotionMath(input);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }
}
