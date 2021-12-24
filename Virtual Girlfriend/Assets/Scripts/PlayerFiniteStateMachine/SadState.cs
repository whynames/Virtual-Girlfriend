using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadState : EmotionState
{
    public SadState(GirlfriendAI girlFriendAI, EmotionStateMachine stateMachine, string[] inputs, string[] answers) : base(girlFriendAI, stateMachine, inputs, answers)
    {
        SplitText("SadAnswers", ref answers);

        SetUpDictionary(ref answers, ref inputs);
    }


    // Start is called before the first frame update

    public override void DoEmotionMath(string input)
    {
        sadness += emotionKeyValue[input]; ;

        base.DoEmotionMath(input);
    }
}
