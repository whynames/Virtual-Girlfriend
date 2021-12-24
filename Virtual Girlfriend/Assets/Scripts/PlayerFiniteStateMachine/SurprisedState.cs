using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurprisedState : EmotionState
{
    public SurprisedState(GirlfriendAI girlFriendAI, EmotionStateMachine stateMachine, string[] inputs, string[] answers) : base(girlFriendAI, stateMachine, inputs, answers)
    {
        SplitText("SurprisedAnswers", ref answers);

        SetUpDictionary(ref answers, ref inputs);
    }


    public override void DoEmotionMath(string input)
    {
        surprise += emotionKeyValue[input];
        base.DoEmotionMath(input);
    }
}
