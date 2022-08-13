using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Levels Difficulty registration and configurations
/// </summary>
[CreateAssetMenu(fileName = "LevelDifficultyConfiguration", menuName = "Configurations/NewLevelDifficultyConfiguration", order = 2)]
public class LevelDifficultyConfiguration : ScriptableObject
{
    [Header("Difficulties Settings")]
    public List<Difficulty> difficulties = new List<Difficulty>();

    [Header("Easy Settings Requirements")]
    public int energyEasy = 10;
    public int vikingsEasy = 1;

    [Header("Medium Settings Requirements")]
    public int energyMedium = 10;
    public int vikingsMedium = 1;

    [Header("Hard Settings Requirements")]
    public int energyHard = 10;
    public int vikingsHard = 1;

    /// <summary>
    /// Check you have all the requirements to start the difficulty
    /// </summary>
    public bool CheckRequirements(Difficulty dif, int energy, int vikings)
    {
        switch (dif.levelDifficultyTag)
        {
            case LevelDifficultyTag.EASY:
                if((energy >= energyEasy) && (vikings >= vikingsEasy))
                {
                    return true;
                }
                return false;
            case LevelDifficultyTag.MEDIUM:
                if((energy >= energyMedium) && (vikings >= vikingsMedium))
                {
                    return true;
                }
                return false;
            case LevelDifficultyTag.HARD:
                if((energy >= energyHard) && (vikings >= vikingsHard))
                {
                    return true;
                }
                return false;
            default:
                return false;
        }
    }
}



