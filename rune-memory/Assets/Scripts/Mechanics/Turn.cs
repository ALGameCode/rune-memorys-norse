using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Turn controller functions
/// </summary>
public class Turn
{
    private static Turn instance = null;

    public TurnStep TurnController { get; private set; }

    public float EndTurnTimer = 2f;

    public int TotalTurns { get; private set;} = 0;
    
    #region Singleton

    private Turn(){}

    public static Turn Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Turn();
            }
            return instance;
        }
    }

    #endregion

    public void StartTurn()
    {
        TotalTurns++;
    }

    public void EndTurn()
    {
        
    }

    public void NextTurn()
    {

    }

    public void NextStep()
    {
        switch (TurnController)
        {
            case TurnStep.IDLE:
                TurnController = TurnStep.FIRST_PIECE;
                break;
            case TurnStep.FIRST_PIECE:
                TurnController = TurnStep.SECOND_PIECE;
                break;
            case TurnStep.SECOND_PIECE:
                TurnController = TurnStep.IDLE;
                break;
            default:
                break;
        }

        NextStepAction();
    }

    public void NextStepAction()
    {
        switch (TurnController)
        {
            case TurnStep.IDLE:
                // ...
                break;
            case TurnStep.FIRST_PIECE:
                // ...
                break;
            case TurnStep.SECOND_PIECE:
                // Verificar resultado
                break;
            default:
                break;
        }
    }
    
}