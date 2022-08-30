/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ALGC.Mechanics.Component;

/// <summary>
/// Levels Difficulty registration and configurations
/// </summary>
namespace ALGC
{
    [CreateAssetMenu(fileName = "LevelDifficultyConfiguration", menuName = "Configurations/NewLevelDifficultyConfiguration", order = 2)]
    public class LevelDifficultyConfiguration : ScriptableObject
    {
        [Header("Difficulties Settings")]
        public List<Difficulty> difficulties = new List<Difficulty>();

        /// <summary>
        /// Check you have all the requirements to start the difficulty
        /// O(1)
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

        /// <summary>
        /// Browse or choose difficulty setting
        /// </summary>
        /// <param name="levelDifficultySet">Difficulty type selected by tag</param>
        /// <returns>Selected difficulty setup</returns>
        public Difficulty GetDifficultySettings(LevelDifficultyTag levelDifficultySet)
        {
            foreach(var dif in difficulties)
            {
                if(dif.levelDifficultyTag == levelDifficultySet)
                {
                    return dif;
                }
            }
            return null;
        }
    }
}