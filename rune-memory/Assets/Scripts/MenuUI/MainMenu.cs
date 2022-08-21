/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using System;
using ALGC.Mechanics;
using ALGC.Player;

/// <summary>
/// UI Element Min Menu Manager
/// </summary>
namespace ALGC.MenuUI
{
    public class MainMenu : MonoBehaviour //SingletonMono<MainMenu>
    {
        #region MainMenu

        [Header("Player Info Settings")]
        public TextMeshProUGUI energyText;
        public TextMeshProUGUI treasuresText;
        public TextMeshProUGUI vikingsText;

        [Header("Start Game Buttons")]
        public Button buttonStartGameEasy;
        public Button buttonStartGameMedium;
        public Button buttonStartGameHard;

        #endregion

        private void Start()
        {
            buttonStartGameEasy.onClick.AddListener(delegate {StartNewLevel(LevelDifficultyTag.EASY);});
            buttonStartGameMedium.onClick.AddListener(delegate {StartNewLevel(LevelDifficultyTag.MEDIUM);});
            buttonStartGameHard.onClick.AddListener(delegate {StartNewLevel(LevelDifficultyTag.HARD);});
        }

        private void FixedUpdate()
        {
            UpdateMenuUI(GameManager.Instance.playerStatus);
        }

        /// <summary>
        /// Select and set difficulty to start new game
        /// </summary>
        /// <param name="difficulty">Difficulty Tag</param>
        public void StartNewLevel(LevelDifficultyTag difficulty)
        {
            GameManager.Instance.levelController.SetSelectedDifficulty(difficulty);
        }

        /// <summary>
        /// Update main menu UI text info
        /// </summary>
        /// <param name="player">Player Information</param>
        public void UpdateMenuUI(PlayerStatus player)
        {
            if(player != null)
            {
                energyText.text = $"{player.TotalEnergy}";
                treasuresText.text = $"{player.Treasures}";
                vikingsText.text = $"{player.ActiveVikings}/{player.TotalVikings}";
            }
        }
    }
}