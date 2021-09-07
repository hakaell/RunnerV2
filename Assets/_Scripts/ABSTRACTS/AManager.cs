using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AManager : MonoBehaviour
{
    public State currentState { get; set; }
    public enum State
    {
        Idle,
        Running,
        InjuredRunning,
        Slide,
        GameOver,
        Win
    }
    public void SetIdleMOD()
    {
        currentState = State.Idle;
    }
    public void SetRunningMOD()
    {
        currentState = State.Running;
    }
    public void SetInjuredRunningMOD()
    {
        currentState = State.InjuredRunning;
    }
    public void SetSlideMOD()
    {
        currentState = State.Slide;
    }
    public void SetGameOverMOD()
    {
        currentState = State.GameOver;
    }
    public void SetWinMOD()
    {
        currentState = State.Win;
    }
}
