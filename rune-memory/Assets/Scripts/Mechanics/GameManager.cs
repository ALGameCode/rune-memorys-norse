/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Save;
using MenuUI;

/// <summary>
/// General Game Manager
/// </summary>
namespace Mechanics
{
    public class GameManager : SingletonMono<GameManager>
    {
        public RuneConfiguration runesConfiguration;
        public LevelDifficultyConfiguration levelDifficultyConfiguration;

        [HideInInspector] public LevelController levelController = null;
        [HideInInspector] public PlayerStatus playerStatus = null;

        public bool IsPaused { get; private set; } = false;
        public bool IsPlayGame { get; set; } = false;
        public bool IsSoundMute { get; set; } = false;

        #region ClassInitialization

        private void Start()
        {
            levelController = new LevelController();
            playerStatus = new PlayerStatus();
            // LocalSave.ClearLocalSave(); 
            LoadPlayerInfo();

            if(IsPaused)
            {
                PauseGame();
            }
        }

        private void Update()
        {
            if(ScenesManager.Instance.ReturnCurrentSceneName() != "Game" && IsPlayGame)
            {
                IsPlayGame = false;
            }
        }

        #endregion

        /// <summary>
        /// Load Saved Player and Game Info
        /// </summary>
        private void LoadPlayerInfo()
        {
            if(LocalSave.CheckLocalSave("PlayerName"))
            {
                LocalSave.LoadPlayerInfoLocalSave(ref playerStatus);
                LocalSave.LoadPlayerGameInfoLocalSave(ref playerStatus);
                LocalSave.LoadGeneralGameInfoLocalSave();
            }
            else
            {
                LocalSave.SavePlayerInfoLocalSave(playerStatus);
                LocalSave.SavePlayerGameInfoLocalSave(playerStatus);
                LocalSave.SaveGeneralGameInfoLocalSave();
            }
            // TODO: Get and Set Cloud Save
        }

        /// <summary>
        /// Save Player and Game Info
        /// </summary>
        public void SaveAllPlayerInfo()
        {
            LocalSave.SavePlayerInfoLocalSave(playerStatus);
            LocalSave.SavePlayerGameInfoLocalSave(playerStatus);
            LocalSave.SaveGeneralGameInfoLocalSave();
        }

        /// <summary>
        /// Shuffle any input list
        /// </summary>
        /// <param name="list">list to be shuffled</param>
        /// <returns>List with their randomly shuffled values</returns>
        public List<T> BlendList<T> (List<T> list)
        {
            var query =
                from i in list
                let r = Random.Range(0, list.Count)
                orderby r
                select i;

            return query.ToList();
        }

        /// <summary>
        /// Pause and Resume Game
        /// </summary>
        public void PauseGame()
        {
            if(IsPaused)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
            IsPaused = !IsPaused;
        }
    }
}