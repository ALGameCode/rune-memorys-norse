using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Control that will function as a mediator of information between scenes
/// </summary>
public class LevelController
{
    public LevelDifficultyTag LevelDifficulty { get; private set; } = LevelDifficultyTag.EASY;

    // Seleciona dificuldade


    // Verificar requisitos energia e vikings
    private bool CheckDifficultyRequirements(LevelDifficultyTag difficulty)
    {

        return false;
    }

    // Iniciar ou mostrar mensagens

}
