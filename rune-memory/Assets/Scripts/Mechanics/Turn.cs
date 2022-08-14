/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Turn controller functions
/// </summary>
namespace Mechanics
{
    public class Turn : Singleton<Turn>
    {
        public TurnStep TurnController { get; private set; }

        public float EndTurnTimer = 2f;

        public int TotalTurns { get; private set;} = 0;

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
}