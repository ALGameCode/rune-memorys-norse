using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Local save functions
/// </summary>
public class LocalSave
{
    #region Singleton

    private static LocalSave instance = null;
    private LocalSave(){}

    public static LocalSave Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LocalSave();
            }
            return instance;
        }
    }

    #endregion

    /// <summary>
    /// Local save player information
    /// </summary>
    /// <param name="player">Player Information</param>
    public void SavePlayerInfoLocalSave(PlayerStatus player)
    {
        PlayerPrefs.SetString("PlayerName", player.PlayerName);
        PlayerPrefs.SetInt("PlayerLevel", player.PlayerLevel);
        PlayerPrefs.SetInt("TotalVikings", player.TotalVikings);
        PlayerPrefs.SetInt("ActiveVikings", player.ActiveVikings);
        PlayerPrefs.SetInt("TotalEnergy", player.TotalEnergy);
        PlayerPrefs.SetInt("Treasures", player.Treasures);
    }

    /// <summary>
    /// Local save player gameplay information
    /// </summary>
    /// <param name="player">Player Information</param>
    public void SavePlayerGameInfoLocalSave(PlayerStatus player)
    {
        PlayerPrefs.SetInt("TotalWin", player.TotalWin);
        PlayerPrefs.SetInt("TotalDefeat", player.TotalDefeat);
        PlayerPrefs.SetInt("TotalEscape", player.TotalEscape);

        PlayerPrefs.SetInt("TotalPlayEasy", player.TotalPlayEasy);
        PlayerPrefs.SetInt("TotalWinEasy", player.TotalWinEasy);
        PlayerPrefs.SetInt("TotalDefeatEasy", player.TotalDefeatEasy);
        PlayerPrefs.SetInt("TotalEscapeEasy", player.TotalEscapeEasy);
        PlayerPrefs.SetFloat("BestTimeEasy", player.BestTimeEasy);
        PlayerPrefs.SetInt("BestMinTurnEasy", player.BestMinTurnEasy);

        PlayerPrefs.SetInt("TotalPlayMedium", player.TotalPlayMedium);
        PlayerPrefs.SetInt("TotalWinMedium", player.TotalWinMedium);
        PlayerPrefs.SetInt("TotalDefeatMedium", player.TotalDefeatMedium);
        PlayerPrefs.SetInt("TotalEscapeMedium", player.TotalEscapeMedium);
        PlayerPrefs.SetFloat("BestTimeMedium", player.BestTimeMedium);
        PlayerPrefs.SetInt("BestMinTurnMedium", player.BestMinTurnMedium);

        PlayerPrefs.SetInt("TotalPlayHard", player.TotalPlayHard);
        PlayerPrefs.SetInt("TotalWinHard", player.TotalWinHard);
        PlayerPrefs.SetInt("TotalDefeatHard", player.TotalDefeatHard);
        PlayerPrefs.SetInt("TotalEscapeHard", player.TotalEscapeHard);
        PlayerPrefs.SetFloat("BestTimeHard", player.BestTimeHard);
        PlayerPrefs.SetInt("BestMinTurnHard", player.BestMinTurnHard);
    }

    /// <summary>
    /// Local save game and general application information
    /// </summary>
    public void SaveGeneralGameInfoLocalSave()
    {
        PlayerPrefs.SetInt("GameSoundBGMIsMute", GeneralGameInfo.Instance.GameSoundBGMIsMute ? 1 : 0);
        PlayerPrefs.SetInt("GameSoundSFXIsMute", GeneralGameInfo.Instance.GameSoundSFXIsMute ? 1 : 0);
        PlayerPrefs.SetString("LastAcessDateTime", System.DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss"));
    }
    
    /// <summary>
    /// Load local saved player information
    /// </summary>
    /// <param name="player">Player Information</param>
    public void LoadPlayerInfoLocalSave(ref PlayerStatus player) //out PlayerStatus player
    {
        player.PlayerName = PlayerPrefs.GetString("PlayerName");
        player.PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");
        player.TotalVikings = PlayerPrefs.GetInt("TotalVikings");
        player.ActiveVikings = PlayerPrefs.GetInt("ActiveVikings");
        player.TotalEnergy = PlayerPrefs.GetInt("TotalEnergy");
        player.Treasures = PlayerPrefs.GetInt("Treasures");
    }

    /// <summary>
    /// Load local saved player gameplay information
    /// </summary>
    /// <param name="player">Player Information</param>
    public void LoadPlayerGameInfoLocalSave(ref PlayerStatus player)
    {
        player.TotalWin = PlayerPrefs.GetInt("TotalWin");
        player.TotalDefeat = PlayerPrefs.GetInt("TotalDefeat");
        player.TotalEscape = PlayerPrefs.GetInt("TotalEscape");

        player.TotalPlayEasy = PlayerPrefs.GetInt("TotalPlayEasy");
        player.TotalWinEasy = PlayerPrefs.GetInt("TotalWinEasy");
        player.TotalDefeatEasy = PlayerPrefs.GetInt("TotalDefeatEasy");
        player.TotalEscapeEasy = PlayerPrefs.GetInt("TotalEscapeEasy");
        player.BestTimeEasy = PlayerPrefs.GetFloat("BestTimeEasy");
        player.BestMinTurnEasy = PlayerPrefs.GetInt("BestMinTurnEasy");

        player.TotalPlayMedium = PlayerPrefs.GetInt("TotalPlayMedium");
        player.TotalWinMedium = PlayerPrefs.GetInt("TotalWinMedium");
        player.TotalDefeatMedium = PlayerPrefs.GetInt("TotalDefeatMedium");
        player.TotalEscapeMedium = PlayerPrefs.GetInt("TotalEscapeMedium");
        player.BestTimeMedium = PlayerPrefs.GetFloat("BestTimeMedium");
        player.BestMinTurnMedium = PlayerPrefs.GetInt("BestMinTurnMedium");

        player.TotalPlayHard = PlayerPrefs.GetInt("TotalPlayHard");
        player.TotalWinHard = PlayerPrefs.GetInt("TotalWinHard");
        player.TotalDefeatHard = PlayerPrefs.GetInt("TotalDefeatHard");
        player.TotalEscapeHard = PlayerPrefs.GetInt("TotalEscapeHard");
        player.BestTimeHard = PlayerPrefs.GetFloat("BestTimeHard");
        player.BestMinTurnHard = PlayerPrefs.GetInt("BestMinTurnHard");
    }

    /// <summary>
    /// Load local saved game and general application information
    /// </summary>
    public void LoadGeneralGameInfoLocalSave()
    {
        GeneralGameInfo.Instance.GameSoundBGMIsMute = PlayerPrefs.GetInt("GameSoundBGMIsMute") == 1;
        GeneralGameInfo.Instance.GameSoundSFXIsMute = PlayerPrefs.GetInt("GameSoundSFXIsMute") == 1;
        GeneralGameInfo.Instance.LastAcessDateTime = System.DateTime.ParseExact(PlayerPrefs.GetString("LastAcessDateTime"), "yyyy-MM-dd_HH:mm:ss", null);
    }

    /// <summary>
    /// Check if there is local save
    /// </summary>
    /// <param name="key">Saved information key</param>
    public bool CheckLocalSave(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Delete all local save
    /// </summary>
    public void ClearLocalSave()
    {
        PlayerPrefs.DeleteAll();
    }
}