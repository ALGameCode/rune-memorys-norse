/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using ALGC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System;

/// <summary>
/// General information and game states
/// </summary>
namespace ALGC.Mechanics
{
    public class GameStatus : Singleton<GameStatus>
    {
        public bool GameSoundBGMIsMute { get; set; } = false;
        public bool GameSoundSFXIsMute { get; set; } = false;
        public DateTime LastAcessDateTime { get; set; } = DateTime.Now;
        public DateTime totalTimeOfflineLastSection { get; set; }
        public float totalTimeOfflineLastSectionInSeconds { get; set; } = 0f;
        //public GameLanguage language = GameLanguage.PT_BR; // Language selected
    }
}