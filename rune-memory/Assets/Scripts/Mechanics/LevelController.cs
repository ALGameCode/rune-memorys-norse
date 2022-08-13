using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Control that will function as a mediator of information between scenes
/// </summary>
public class LevelController
{
    public LevelDifficultyTag LevelDifficulty { get; private set; } = LevelDifficultyTag.EASY;
    private const string gameScene = "Game";

    // Seleciona dificuldade // TODO: usar evento com botoes para chamar essa função button.OnClick += SetSelectedDifficulty
    public void SetSelectedDifficulty(LevelDifficultyTag difficulty)
    {
        if(CheckDifficultyRequirements(difficulty))
        {
            StartNewGame();
        }
    }

    // Verificar requisitos energia e vikings
    private bool CheckDifficultyRequirements(LevelDifficultyTag difficulty)
    {
        //GameManager.instance.playerStatus
        return false;
    }

    // Iniciar ou mostrar mensagens
    private void StartNewGame()
    {
        ScenesManager.instance.ChangeSceneByName(gameScene);
    }
}
