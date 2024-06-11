using ALGC.timeSystem;
using UnityEngine;

namespace ALGC.techArt.vfx.scriptManipulators
{
    /// <summary>
    /// System Object
    /// Description: ...
    /// </summary>
    public static class CanvaObjectManipulator
    {

        public static void ObjectScaleAction(SpriteRenderer spriteRenderer, float minScale = 0f, float maxScale = 1f, float waitTime = 1000f, float scalingSpeed = 0.1f)
        {

            for (float scale = minScale; scale <= maxScale; scale += scalingSpeed)
            {
                spriteRenderer.transform.localScale = new Vector3(scale, scale, 1f);
                GameTimeManager.Instance.DelayExecuteCoroutine(waitTime);
            }

            // Garantir que o sprite tenha a escala final exata
            spriteRenderer.transform.localScale = new Vector3(maxScale, maxScale, 1f);
        }


        public static void ObjectScaleAction(Sprite sprite, float scale = 1f)
        {

        }
    }
}