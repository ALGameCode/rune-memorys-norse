/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using ALGC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ALGC.Mechanics.Component;

/// <summary>
/// Control that will function as a mediator of information between scenes
/// </summary>
namespace ALGC.Mechanics
{
    public class LevelController
    {
        public static LevelDifficultyTag LevelDifficulty { get; private set; } = LevelDifficultyTag.EASY;
        private const string gameScene = "Game";

        /// <summary>
        /// Selects difficulty of the game to be created
        /// TODO: use event with buttons to call this function button.OnClick += SetSelectedDifficulty
        /// </summary>
        public void SetSelectedDifficulty(LevelDifficultyTag difficulty)
        {
            if(CheckDifficultyRequirements(difficulty))
            {
                LevelDifficulty = difficulty;
                StartNewGameLevel();
            }
            else
            {
                // TODO: Show message 
            }
        }

        /// <summary>
        /// Check energy requirements and vikings to enter and create selected level stage
        /// </summary>
        private bool CheckDifficultyRequirements(LevelDifficultyTag difficulty)
        {
            int viking = GameManager.Instance.playerStatus.ActiveVikings;
            int energy = GameManager.Instance.playerStatus.TotalEnergy;
            Difficulty dif = GameManager.Instance.levelDifficultyConfiguration.GetDifficultySettings(difficulty);
            if(GameManager.Instance.levelDifficultyConfiguration.CheckRequirements(dif, energy, viking))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Change scene to start game
        /// </summary>
        private void StartNewGameLevel()
        {
            MenuUI.ScenesManager.Instance.ChangeSceneByName(gameScene);
        }

        /// <summary>
        /// Get the selected level or difficulty tag
        /// </summary>
        public LevelDifficultyTag GetLevelDifficultyTag()
        {
            return LevelDifficulty;
        }
    }
}