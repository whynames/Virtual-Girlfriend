using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmotionState
{

    public float feeling;
    public Dictionary<string, string[]> answerKeyValue = new Dictionary<string, string[]>();
    public Dictionary<string, float> emotionKeyValue = new Dictionary<string, float>();


    protected EmotionCommons emotionCommons;
    protected EmotionSpecs emotionSpecs;
    protected GirlfriendAI girlFriendAI;
    protected EmotionStateMachine stateMachine;

    protected string[] randomAnswers;

    protected bool isExitingState;
    protected float startTime;

    public EmotionState(EmotionCommons emotionCommons, EmotionSpecs emotionSpecs)
    {
        this.emotionCommons = emotionCommons;
        this.emotionSpecs = emotionSpecs;
        this.girlFriendAI = emotionCommons. girlFriendAI;
        this.stateMachine = emotionCommons.stateMachine;
        SplitText("AngryAnswers", ref emotionSpecs.answers);
        SplitText("Inputs", ref emotionCommons.inputs);
        SplitText("Random", ref emotionCommons.randomAnswers);
        this.randomAnswers = emotionCommons.randomAnswers;
        SetUpDictionary(ref emotionSpecs.answers, ref emotionCommons.inputs);        
        SetUpEmotionDictionary(SetUpFloatsFromText("feelingvalues"), emotionCommons.inputs);

    }

    public string[][] MakeArrayofArray(string[] array)
    {
        string[][] arrayofarray = new string[array.Length][];

        for (int i = 0; i < array.Length; i++)
        {
            arrayofarray[i] = array[i].Split(',');
        }

        return arrayofarray;
    }
    public void SplitText(string TextfileName, ref string[] answers)
    {
        answers = System.IO.File.ReadAllLines(@"Assets/Scripts/TextFiles/" + TextfileName + ".txt");
    }
    public void SetUpDictionary(ref string[] answers, ref string[] inputs)
    {
        string[][] arrayofarray = MakeArrayofArray(answers);
        for (int i = 0; i < inputs.Length; i++)
        {
            answerKeyValue.Add(inputs[i], arrayofarray[i]);
        }
    }
    public float[] SetUpFloatsFromText(string FileName)
    {
        string[] mathstext = System.IO.File.ReadAllLines(@"Assets/Scripts/TextFiles/" + FileName + ".txt");
        float[] maths = new float[mathstext.Length];
        for (int i = 0; i < mathstext.Length; i++)
        {
            maths[i] = int.Parse(mathstext[i]);
        }
        return maths;
    }
    public void SetUpEmotionDictionary(float[] maths, string[] inputs)
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            emotionKeyValue.Add(inputs[i], maths[i]);
        }
    }

    public string RandomGetter(string[] possibleAnswers)
    {
        return possibleAnswers[Random.Range(0, possibleAnswers.Length)];
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
    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }
    public string DoStringMath(string input)
    {
        string[] answer;
        if(answerKeyValue.ContainsKey(input))
        {
            answer = answerKeyValue[input];
        }
        else
        {
            answer = randomAnswers;
        }
        return RandomGetter(answer);
    }

    public virtual void DoEmotionMath(string input)
    {
        if(emotionKeyValue.ContainsKey(input))
        {
            feeling += emotionKeyValue[input];
        }
        else
        {
            feeling --;
        }
        emotionSpecs.slider.value = (feeling/30) +0.5f;
        girlFriendAI.ControlStateChange();
    }

    public virtual void DoChecks() { }
}

[System.Serializable]
public struct EmotionSpecs
{
    public string[] answers;

    public Slider slider;
}

[System.Serializable]
public struct EmotionCommons
{
    public string[] inputs;

    public string[] randomAnswers;
    public GirlfriendAI girlFriendAI; 
    public EmotionStateMachine stateMachine;
}
