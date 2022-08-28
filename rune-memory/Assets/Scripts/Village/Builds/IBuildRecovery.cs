/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Interface for builds that modify recovery time and amount recovered each time
/// </summary>
namespace ALGC.Village.Builds
{
    public interface IBuildRecovery
    {
        void ModifyRecoveryTime(float modifyTime);
        void ModifyRecoveryQuantity(int value);
    }
}