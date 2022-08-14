// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class with description and information about the player and his game history
/// </summary>
public class PlayerStatus
{
    public string PlayerName { get; set; } = "name";
    public int PlayerLevel { get; set; } = 1;

    public int TotalVikings { get; set; } = 30;
    public int ActiveVikings { get; set; } = 30;
    public int TotalEnergy { get; set; } = 0;
    public int Treasures { get; set; } = 0;

    public int TotalWin { get; set; } = 0;
    public int TotalDefeat { get; set; } = 0;
    public int TotalEscape { get; set; } = 0;

    public int TotalPlayEasy { get; set; } = 0;
    public int TotalWinEasy { get; set; } = 0;
    public int TotalDefeatEasy { get; set; } = 0;
    public int TotalEscapeEasy { get; set; } = 0;
    public float BestTimeEasy { get; set; } = 0f;
    public int BestMinTurnEasy { get; set; } = 0;

    public int TotalPlayMedium { get; set; } = 0;
    public int TotalWinMedium { get; set; } = 0;
    public int TotalDefeatMedium { get; set; } = 0;
    public int TotalEscapeMedium { get; set; } = 0;
    public float BestTimeMedium { get; set; } = 0f;
    public int BestMinTurnMedium { get; set; } = 0;

    public int TotalPlayHard { get; set; } = 0;
    public int TotalWinHard { get; set; } = 0;
    public int TotalDefeatHard { get; set; } = 0;
    public int TotalEscapeHard { get; set; } = 0;
    public float BestTimeHard { get; set; } = 0f;
    public int BestMinTurnHard { get; set; } = 0;
}

// TODO: considering future features, is this better as singleton or not?
