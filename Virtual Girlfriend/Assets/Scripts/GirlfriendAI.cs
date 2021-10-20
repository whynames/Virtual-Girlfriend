using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GirlfriendAI : MonoSingleton<GirlfriendAI>
{
    public float laugh, fear, surprise, sadness, anger;

    public EmotionStateMachine StateMachine { get; private set; }

    public FearfulState FearfulState { get; private set; }
    public JoyFulState JoyfulState { get; private set; }
    public SadState SadState { get; private set; }
    public SurprisedState SurprisedState { get; private set; }
    public AngryState AngryState { get; private set; }



    public float Max
    {
        get
        {
            return Mathf.Max(laugh, surprise, fear, sadness, anger);
        }
    }

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

    public string asdadasd()
    {
        Debug.Log("sas");
        return "sa";          
    }

    private void Awake()
    {
        StateMachine = new EmotionStateMachine();
        FearfulState = new FearfulState(this,StateMachine);
        JoyfulState = new JoyFulState(this,StateMachine);
        SadState = new SadState(this,StateMachine);
        AngryState = new AngryState(this,StateMachine);
        SurprisedState = new SurprisedState(this,StateMachine);

        StateMachine.Initialize(JoyfulState);
    }

    private void Start()
    {
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }
}
