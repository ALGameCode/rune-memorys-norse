// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Levels Difficulty registration and configurations
/// </summary>
namespace Mechanics
{
    [CreateAssetMenu(fileName = "LevelDifficultyConfiguration", menuName = "Configurations/NewLevelDifficultyConfiguration", order = 2)]
    public class LevelDifficultyConfiguration : ScriptableObject
    {
        [Header("Difficulties Settings")]
        public List<Difficulty> difficulties = new List<Difficulty>();

        /// <summary>
        /// Check you have all the requirements to start the difficulty
        /// </summary>
        public bool CheckRequirements(Difficulty dif, int energy, int vikings)
        {
            if((energy >= dif.energyRequirements) && (vikings >= dif.vikingsRequirements))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
