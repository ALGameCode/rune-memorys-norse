/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Control that will function as a mediator of information between scenes
/// </summary>
namespace Mechanics
{
    public class LevelController
    {
        public static LevelDifficultyTag LevelDifficulty { get; private set; } = LevelDifficultyTag.EASY;
        private const string gameScene = "Game";

        // Seleciona dificuldade // TODO: usar evento com botoes para chamar essa função button.OnClick += SetSelectedDifficulty
        public void SetSelectedDifficulty(LevelDifficultyTag difficulty)
        {
            if(CheckDifficultyRequirements(difficulty))
            {
                LevelDifficulty = difficulty;
                StartNewGameLevel();
            }
        }

        // Verificar requisitos energia e vikings
        private bool CheckDifficultyRequirements(LevelDifficultyTag difficulty)
        {
            int viking = GameManager.Instance.playerStatus.ActiveVikings;
            int energy = GameManager.Instance.playerStatus.TotalEnergy;
            Mechanics.Difficulty dif = LevelGameManager.Instance.GetDifficultySettings(difficulty);
            if(GameManager.Instance.levelDifficultyConfiguration.CheckRequirements(dif, energy, viking))
            {
                return true;
            }
            return false;
        }

        // Iniciar ou mostrar mensagens
        private void StartNewGameLevel()
        {
            MenuUI.ScenesManager.Instance.ChangeSceneByName(gameScene);
        }

        public LevelDifficultyTag GetLevelDifficultyTag()
        {
            return LevelDifficulty;
        }
    }
}