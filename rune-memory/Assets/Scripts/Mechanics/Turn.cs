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
        public int TotalTurns { get; private set;} = 1;
        public float EndTurnTimer = 1f;     

        /// <summary>
        /// Sum new turn to count at the end of the game
        /// </summary>
        public void SumTurns()
        {
            TotalTurns++;
        }

        /// <summary>
        /// Reset turn variables
        /// </summary>
        public void ResetTurnGame()
        {
            TotalTurns = 0;
            TurnController = TurnStep.IDLE;
        }

        /// <summary>
        /// Switch to next step after player play
        /// </summary>
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

        /// <summary>
        /// Executes actions every turn of a turn
        /// </summary>
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
                    SumTurns();
                    break;
                default:
                    break;
            }
        } 
    }
}

// TODO: Use NextStepAction to control specific actions that can happen in each step of the shift, eg tips, tutorials, release a new specific action, etc.