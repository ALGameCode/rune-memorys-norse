/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using System;
using Mechanics;

/// <summary>
/// UI Element Min Menu Manager
/// </summary>
namespace MenuUI
{
    public class MainMenu : SingletonMono<MainMenu>
    {
        #region MainMenu

        [Header("Start Game Buttons")]
        public Button buttonStartGameEasy;
        public Button buttonStartGameMedium;
        public Button buttonStartGameHard;

        #endregion

        #region OthersButtons
        [Header("Mute BGM Sprites")]
        [Tooltip("At index 0 is equivalent to mute and 1 to playing")] 
        public Sprite[] muteBGMButtonSprites = new Sprite[2];
        public Image muteBgmImage;
        [Header("Mute SFX Sprites")]
        [Tooltip("At index 0 is equivalent to mute and 1 to playing")] 
        public Sprite[] muteSFXButtonSprites = new Sprite[2];
        public Image muteSfxImage;
        #endregion 

        private void Start()
        {
            buttonStartGameEasy.onClick.AddListener(delegate {StartNewLevel(LevelDifficultyTag.EASY);});
            buttonStartGameMedium.onClick.AddListener(delegate {StartNewLevel(LevelDifficultyTag.MEDIUM);});
            buttonStartGameHard.onClick.AddListener(delegate {StartNewLevel(LevelDifficultyTag.HARD);});
        }

        #region LevelSelection

        public void StartNewLevel(LevelDifficultyTag difficulty)
        {
            GameManager.Instance.levelController.SetSelectedDifficulty(difficulty);
        }

        #endregion

        #region ButtonsOthers
        
        public void ChangeSpriteButtonMute(string type)
        {
            if(Sound.SoundManager.Instance.SourcePlay.mute)
            {
                if(type.Equals("BGM")) muteBgmImage.sprite = muteBGMButtonSprites[0];
                else if(type.Equals("SFX")) muteSfxImage.sprite = muteSFXButtonSprites[0];
            }
            else
            {
                if(type.Equals("BGM")) muteBgmImage.sprite = muteBGMButtonSprites[1];
                else if(type.Equals("SFX")) muteSfxImage.sprite = muteSFXButtonSprites[1];
            }
        }

        #endregion
    }
}