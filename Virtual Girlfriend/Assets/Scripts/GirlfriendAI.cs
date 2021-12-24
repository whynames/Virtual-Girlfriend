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
            return Mathf.Max(JoyfulState.feeling, SurprisedState.feeling, FearfulState.feeling, SadState.feeling, AngryState.feeling);
        }
    }
    public EmotionStateMachine StateMachine { get; private set; }


    public FearfulState FearfulState { get; private set; }
    public JoyFulState JoyfulState { get; private set; }
    public SadState SadState { get; private set; }
    public SurprisedState SurprisedState { get; private set; }
    public AngryState AngryState { get; private set; }

    private EmotionCommons emotionCommons;    
    
    [SerializeField]
    private EmotionSpecs fearfulSpecs;
    [SerializeField]
    private EmotionSpecs angrySpecs;
    [SerializeField]
    private EmotionSpecs joyfulSpecs;
    [SerializeField]
    private EmotionSpecs sadSpecs;
    [SerializeField]
    private EmotionSpecs surprisedSpecs;                 


    private void Awake()
    {
        emotionCommons.girlFriendAI = this;
        StateMachine = new EmotionStateMachine();
        FearfulState = new FearfulState(emotionCommons, fearfulSpecs);
        JoyfulState = new JoyFulState(emotionCommons, joyfulSpecs);
        SadState = new SadState(emotionCommons, sadSpecs);
        AngryState = new AngryState(emotionCommons, angrySpecs);
        SurprisedState = new SurprisedState(emotionCommons, surprisedSpecs);

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
    }

    public void ControlStateChange()
    {
        if (Max == JoyfulState.feeling)
        {
            StateMachine.ChangeState(JoyfulState);
        }
        else if (Max == AngryState.feeling)
        {
            StateMachine.ChangeState(AngryState);
        }
        else if (Max == FearfulState.feeling)
        {
            StateMachine.ChangeState(FearfulState);
        }
        else if (Max == SadState.feeling)
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
        answers = System.IO.File.ReadAllLines(@"Assets/Scripts/TextFiles/" + TextfileName + ".txt");
    }
}
