using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Local save functions
/// </summary>
public class LocalSave : MonoBehaviour
{

    /// <summary>
    /// ...
    /// </summary>
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
    /// ...
    /// </summary>
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
    /// ...
    /// </summary>
    public void SaveGeneralGameInfoLocalSave()
    {

    }
    
    /// <summary>
    /// ...
    /// </summary>
    public void LoadPlayerInfoLocalSave(PlayerStatus player) //out PlayerStatus player
    {
        player.PlayerName = PlayerPrefs.GetString("PlayerName");
        player.PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");
        player.TotalVikings = PlayerPrefs.GetInt("TotalVikings");
        player.ActiveVikings = PlayerPrefs.GetInt("ActiveVikings");
        player.TotalEnergy = PlayerPrefs.GetInt("TotalEnergy");
        player.Treasures = PlayerPrefs.GetInt("Treasures");
    }

    /// <summary>
    /// ...
    /// </summary>
    public void LoadPlayerGameInfoLocalSave()
    {

    }

    /// <summary>
    /// ...
    /// </summary>
    public void LoadGeneralGameInfoLocalSave()
    {

    }

    /// <summary>
    /// ...
    /// </summary>
    public bool CheckLocalSave(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// ...
    /// </summary>
    public void ClearLocalSave()
    {
        PlayerPrefs.DeleteAll();
    }
}
