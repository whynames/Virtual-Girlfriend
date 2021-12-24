using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearfulState : EmotionState
{
    public FearfulState(GirlfriendAI girlFriendAI, EmotionStateMachine stateMachine, string[] inputs, string[] answers) : base(girlFriendAI, stateMachine, inputs, answers)
    {
        SplitText("FearfulAnswers", ref answers);

        SetUpDictionary(ref answers, ref inputs);
    }

    // Start is called before the first frame update

    public override void DoEmotionMath(string input)
    {
        fear += emotionKeyValue[input];
        base.DoEmotionMath(input);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }
}
