using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GirlfriendAI : MonoSingleton<GirlfriendAI>
{
    public float Max
    {
        get
        {
            return Mathf.Max(JoyfulState.laugh, SurprisedState.surprise, FearfulState.fear, SadState.sadness, AngryState.anger);
        }
    }
    public EmotionStateMachine StateMachine { get; private set; }

    public FearfulState FearfulState { get; private set; }
    public JoyFulState JoyfulState { get; private set; }
    public SadState SadState { get; private set; }
    public SurprisedState SurprisedState { get; private set; }
    public AngryState AngryState { get; private set; }

    public string[] inputs;
    public string[] Joyanswers;
    public string[] Sadanswers;
    public string[] Surprisedanswers;
    public string[] Angryanswers;
    public string[] Fearanswers;



    public List<string> highLaughAnswers = new List<string>()
    {
        "Of Course!", "lol", 
    }
    ;

    public static string GetAnswerFromAI(string input)
    {
        string answer;

        answer = string.Empty;
        return answer;
    }


    private void Awake()
    {
        SplitText("Inputs", ref inputs);
        StateMachine = new EmotionStateMachine();
        FearfulState = new FearfulState(this,StateMachine, inputs, Fearanswers);
        JoyfulState = new JoyFulState(this,StateMachine, inputs, Joyanswers);
        SadState = new SadState(this,StateMachine,inputs, Sadanswers);
        AngryState = new AngryState(this,StateMachine, inputs, Angryanswers);
        SurprisedState = new SurprisedState(this,StateMachine, inputs, Surprisedanswers);

        StateMachine.Initialize(JoyfulState);
    }

    private void Start()
    {        
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

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();

        Debug.Log(StateMachine.CurrentState);
        if (Max == JoyfulState.laugh)
        {
            StateMachine.ChangeState(JoyfulState);
        }
        else if (Max == AngryState.anger)
        {
            StateMachine.ChangeState(AngryState);
        }
        else if (Max == FearfulState.fear)
        {
            StateMachine.ChangeState(FearfulState);
        }
        else if (Max == SadState.sadness)
        {
            StateMachine.ChangeState(SadState);
        }
        else
        {
            StateMachine.ChangeState(SurprisedState);
        }
    }

    public void SplitText(string TextfileName, ref string[] answers)
    {
        answers = System.IO.File.ReadAllLines(@"Assets\Scripts\TextFiles\" + TextfileName + ".txt");
    }
}
