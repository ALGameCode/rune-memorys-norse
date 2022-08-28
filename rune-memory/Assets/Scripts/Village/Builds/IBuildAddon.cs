/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Interface for buildings that modify the total amount of a status
/// </summary>
namespace ALGC.Village.Builds
{
    public interface IBuildAddon
    {
        void AddToTotalStatus(int value);
    }
}