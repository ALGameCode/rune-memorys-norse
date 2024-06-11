using System.Collections;
using UnityEngine;

namespace ALGC.timeSystem
{
    public static class DelayedExecutionAction //  : Singleton<DelayedExecutionAction>
    {
        // Intervalo de atraso em milissegundos

        public static IEnumerator ExecuteDelayedSteps(float delayTime = 1000f)
        {
            // Aguarda o intervalo de tempo especificado
            yield return new WaitForSeconds(delayTime / 1000f);
        }
    }
}