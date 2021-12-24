using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmotionState
{

    public float laugh, fear, surprise, sadness, anger;
    public float Max
    {
        get
        {
            return Mathf.Max(laugh, surprise, fear, sadness, anger);
        }
    }
    public Dictionary<string, string[]> answerKeyValue = new Dictionary<string, string[]>();
    public Dictionary<string, float> emotionKeyValue = new Dictionary<string, float>();


    protected GirlfriendAI girlFriendAI;
    protected EmotionStateMachine stateMachine;

    protected bool isExitingState;
    protected float startTime;


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
        answers = System.IO.File.ReadAllLines(@"Assets\Scripts\TextFiles\" + TextfileName + ".txt");
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
        string[] mathstext = System.IO.File.ReadAllLines(@"Assets\Scripts\TextFiles\" + FileName + ".txt");
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
    public EmotionState(GirlfriendAI girlFriendAI, EmotionStateMachine stateMachine, string[] inputs, string[] answers)
    {
        this.girlFriendAI = girlFriendAI;
        this.stateMachine = stateMachine;
        SetUpEmotionDictionary(SetUpFloatsFromText("feelingvalues"), inputs);
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
        //if(Max == laugh)
        //{
        //    stateMachine.ChangeState(girlFriendAI.JoyfulState);
        //}
        //else if (Max == anger)
        //{
        //    stateMachine.ChangeState(girlFriendAI.AngryState);
        //}
        //else if (Max == fear)
        //{
        //    stateMachine.ChangeState(girlFriendAI.FearfulState);
        //}
        //else if (Max == sadness)
        //{
        //    stateMachine.ChangeState(girlFriendAI.SadState);
        //}
        //else
        //{
        //    stateMachine.ChangeState(girlFriendAI.SurprisedState);
        //}
    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }
    public string DoStringMath(string input)
    {
        string[] answer = answerKeyValue[input];
        return RandomGetter(answer);
    }

    public virtual void DoEmotionMath(string input)
    {

    }

    public virtual void DoChecks() { }

    

}
