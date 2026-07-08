using System;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public enum TEAM
    {
        PLAYER,
        AI
    }


    [Header("Who marked the point")]
    public TEAM ScorerTeam;

    
    public static event Action<TEAM> MarkedGoal;
    public static event Action ResetBoard;


    void OnTriggerEnter2D(Collider2D collision)
    {
        MarkedGoal?.Invoke(ScorerTeam);
        ResetBoard?.Invoke();
    }
}
