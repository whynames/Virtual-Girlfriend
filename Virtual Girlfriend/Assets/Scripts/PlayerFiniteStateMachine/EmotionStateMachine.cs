using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionStateMachine
{
    public EmotionState CurrentState { get; private set; }

    public void Initialize(EmotionState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(EmotionState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
