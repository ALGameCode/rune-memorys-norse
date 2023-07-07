using UnityEngine;

namespace ALGC.sceneSystem
{
    /// <summary>
    /// Entity Object
    /// Description: Splash Screen Entity Descriptor Components
    /// </summary>
    [CreateAssetMenu(fileName = "New Splash Screen Entity Descriptor", menuName = "ALGC Custom/CreateSplashScreenEntityDescriptor")]
    public class SplashScreenEntity : ScriptableObject
    {
        [Header("Splash Screeen Entity Descriptor")]
        [Space(10)]

        [Tooltip("Splash Screen Reference Name")]
        [SerializeField]
        private string splashScreenEntityName;

        [Tooltip("Prefab with splash screen sprite and configurations")]
        [SerializeField]
        private GameObject splashScreenEntityPrefab;

        [Space(20)]
        [Header("Animation Settings")]
        [Space(10)]

        [Tooltip("Choose one of the animation types, and choose a name for a non-animated image")]
        [SerializeField]
        private SplashAnimationType splashAnimationType;

        #region Encapsulation

        public string SplashScreenEntityName
        {
            get { return splashScreenEntityName; }
            private set { splashScreenEntityName = value; }
        }

        public GameObject SplashScreenEntityPrefab
        {
            get { return splashScreenEntityPrefab; }
            private set { splashScreenEntityPrefab = value; }
        }

        public SplashAnimationType SplashAnimationType
        {
            get { return splashAnimationType; }
            private set { splashAnimationType = value; }
        }

        #endregion Encapsulation
    }

    public enum SplashAnimationType
    {
        None,
        FadeIn,
        FadeOut,
        ZoonIn,
        ZoonOut,
        Animator,
        Video,
    }
}