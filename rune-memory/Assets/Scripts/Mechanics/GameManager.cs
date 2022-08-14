/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

        #region ClassInitialization

        private void Start()
        {
            levelController = new LevelController();
            playerStatus = new PlayerStatus();
            
            if(IsPaused)
            {
                PauseGame();
            }
        }

        #endregion

        private void LoadInfo()
        {
            // Existe save de perfil?

            // Existe Save de jogo?

            //Se Sim carregar

            //Se não Criar e salvar

            // TODO: Get Cloud Save
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