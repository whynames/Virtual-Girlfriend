using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryState : EmotionState
{
    public AngryState(GirlfriendAI girlFriendAI, EmotionStateMachine stateMachine) : base(girlFriendAI, stateMachine)
    {
    }


    // Start is called before the first frame update
    public override string DoStringMath(string input)
    {
        return "Angry" ;
    }
    public override void DoEmotionMath(string input)
    {
        base.DoEmotionMath(input);
    }
}
