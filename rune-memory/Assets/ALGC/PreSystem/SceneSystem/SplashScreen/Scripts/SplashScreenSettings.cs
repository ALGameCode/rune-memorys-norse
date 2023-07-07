using System.Collections.Generic;
using UnityEngine;

namespace ALGC.sceneSystem
{
    /// <summary>
    /// Setting Object
    /// Description: ...
    /// </summary>
    [CreateAssetMenu(fileName = "New Splash Screen Settings", menuName = "ALGC Custom/CreateSplashScreenSettings")]
    public class SplashScreenSettings : ScriptableObject
    {
        [Header("")]
        [Tooltip("")]
        [SerializeField]
        private List<SplashScreenEntity> splashScreeenEntities;

        public List<SplashScreenEntity> SplashScreeenEntities
        {
            get { return splashScreeenEntities; }
            private set { splashScreeenEntities = value; }
        }

    }
}