using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System;

/// <summary>
/// General information and game states
/// </summary>
public class GeneralGameInfo // sealed 
{
    private static GeneralGameInfo instance = null;

    public bool GameSoundBGMIsMute { get; set; } = false;
    public bool GameSoundSFXIsMute { get; set; } = false;
    public DateTime LastAcessDateTime { get; set; } = DateTime.Now;

    #region Singleton

    private GeneralGameInfo(){}

    public static GeneralGameInfo Instance
    {
        get // lock (padlock)
        {
            if (instance == null)
            {
                instance = new GeneralGameInfo();
            }
            return instance;
        }
    }

    #endregion
}
