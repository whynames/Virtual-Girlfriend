using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyFulState : EmotionState
{
    public float joy;
    public JoyFulState(GirlfriendAI girlFriendAI, EmotionStateMachine stateMachine) : base(girlFriendAI, stateMachine)
    {
    }


    // Start is called before the first frame update
    public override string DoStringMath(string input)
    {
        switch (input)
        {
            case var s when input.Contains("!"):
                return "really!"; 
            case var s when input.Contains("?"):
                return "I hope so<sprite=15>";
            case var s when input.Contains("I love you"):
                return "I guess, mm.. me too!";
            case var s when input.Contains("What do you do?"):
                return "I listen music";
            case var s when input.Contains("!"):
                return "really!";
            case var s when input.Contains("?"):
                return "I hope so";
            case var s when input.Contains("!"):
                return "really!";
            case var s when input.Contains("?"):
                return "I hope so";
            case var s when input.Contains("!"):
                return "really!";
            case var s when input.Contains("?"):
                return "I hope so";
            default:
                return "I am soooo happpyyy";
        }
    }
    public override void DoEmotionMath(string input)
    {
        base.DoEmotionMath(input);
        switch (input)
        {
            case var s when input.Contains("!"):
                girlFriendAI.anger += 20;
                break;
            case var s when input.Contains("?"):
                break;
            default:
                break;
        }
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }
}