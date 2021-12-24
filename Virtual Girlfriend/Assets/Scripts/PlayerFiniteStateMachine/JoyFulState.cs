using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyFulState : EmotionState
{
    public JoyFulState(EmotionCommons emotionCommons, EmotionSpecs emotionSpecs) : base(emotionCommons, emotionSpecs)
    {
    }

    // This code is no longer in use, but I wanted to keep it to show it is another way do it.
    //public override string DoStringMath(string input)
    //{
    //    switch (input)
    //    {
    //        case var s when input.Contains("!"):
    //            return "really!"; 
    //        case var s when input.Contains("?"):
    //            return "I hope so<sprite=15>";
    //        case var s when input.Contains("I love you"):
    //            return "I guess, mm.. me too!";
    //        case var s when input.Contains("What do you do?"):
    //            return "I listen music";
    //        case var s when input.Contains("!"):
    //            return "really!";
    //        case var s when input.Contains("?"):
    //            return "I hope so";
    //        case var s when input.Contains("!"):
    //            return "really!";
    //        case var s when input.Contains("?"):
    //            return "I hope so";
    //        case var s when input.Contains("!"):
    //            return "really!";
    //        case var s when input.Contains("?"):
    //            return "I hope so";
    //        default:
    //            return "I am soooo happpyyy";
    //    }
    //}

}
