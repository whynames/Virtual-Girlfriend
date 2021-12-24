using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryState : EmotionState
{
    public AngryState(GirlfriendAI girlFriendAI, EmotionStateMachine stateMachine, string[] inputs, string[] answers) : base(girlFriendAI, stateMachine, inputs, answers)
    {
        SplitText("AngryAnswers", ref answers);

        SetUpDictionary(ref answers, ref inputs);
    }


    // Start is called before the first frame update
    public override void DoEmotionMath(string input)
    {
        anger += emotionKeyValue[input];
        base.DoEmotionMath(input);
    }
}
