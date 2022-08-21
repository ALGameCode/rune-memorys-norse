/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using ALGC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Difficulty Descriptions
/// </summary>
namespace ALGC.Mechanics.Component
{
    [Serializable]
    public class Difficulty
    {
        [Space(10)]
        [Header("Runes Settings")]
        [Tooltip("Select a default difficulty type compatible with the description created.")]
        public LevelDifficultyTag levelDifficultyTag = LevelDifficultyTag.EASY;
        [Tooltip("Name or Short Description of Difficulty.")]
        public string difficultyDescriptionName = "simple";
        [Tooltip("Total number of pieces in the grid. The total value of different runes in the grid will be different from this.")]
        [Range (6,48)]
        public int quantityPieces = 20;
        [Tooltip("Initial time to see and memorize runes.")]
        public float startingTimeShowRunes = 10f;

        [Header("Settings Requirements")]
        public int energyRequirements = 10;
        public int vikingsRequirements = 1;

        [Space(10)]
        [Header("Grid Padding Settings")]
        public int gridPaddingLeft = 30;
        public int gridPaddingRight = 30;
        public int gridPaddingTop = 10;
        public int gridPaddingBotton = 10;
        [Space(10)]
        [Header("Grid Size and Space Settings")]
        public float gridCellSizeX = 162;
        public float gridCellSizeY = 270;

        public float gridSpacingX = 50;
        public float gridSpacingY = 50;
    }
}