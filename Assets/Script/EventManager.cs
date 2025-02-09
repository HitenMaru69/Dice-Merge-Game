using System;
using UnityEngine;

public class ScoreUpdateEventArgs : EventArgs
{
    public int number1;
    public int number2;
}
public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    public event EventHandler SpwanNewObjectEvent;
    public event EventHandler<ScoreUpdateEventArgs> ScoreUpdateEvent;
    public event EventHandler GameOverEvent;
    private void Awake()
    {
        Instance = this;
    }

    public void InvokeSpwanNewObjectEvent()
    {
        SpwanNewObjectEvent?.Invoke(this,EventArgs.Empty);
    }

    public void InvokeScoreUpdateEvent(int number1,int number2)
    {
        ScoreUpdateEvent?.Invoke(this,new ScoreUpdateEventArgs
        {
            number1 = number1,
            number2 = number2
        });
    }

    public void InvokeGameOverEvent()
    {
        GameOverEvent?.Invoke(this,EventArgs.Empty);
    }


}
