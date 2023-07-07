using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ALGC.sceneSystem
{
    /// <summary>
    /// Manager Object
    /// Description: ...
    /// </summary>
    public class SplashScreenManager : MonoBehaviour
    {
        [Header("Splash Screen Settings")]
        [Space(10)]
        [Tooltip("Configuration object containing all splashscreen entities.")]
        [SerializeField]
        private SplashScreenSettings splashScreenSettings;

        [Space(20)]

        private Image splashImage;
        public bool useZoomEffect = true;
        public float zoomSpeed = 0.01f;
        public float fadeDuration = 1f;

        private int currentImageIndex = 0;
        private Sprite[] splashImages;

        #region Actions_Flow

        private void Awake()
        {
            
        }

        private void Start()
        {
            // StartCoroutine(ShowSplashImages());
            RunSplashScreens();
        }

        private void Update()
        {
            
        }

        private void FixedUpdate()
        {
            
        }

        #endregion Actions_Flow


        private void RunSplashScreens()
        {
            foreach(var splash in splashScreenSettings.SplashScreeenEntities)
            {
                GameObject instantiatePrefab = Instantiate(splash.SplashScreenEntityPrefab, this.transform);
                SplashAction(splash);
            }

            // TODO: Load Next Scene
        }

        private void SplashAction(SplashScreenEntity screenEntity)
        {
            switch(screenEntity.SplashAnimationType)
            {
                case SplashAnimationType.None:
                    break;
            }
        }


        public void SetSplashImages(Sprite[] images)
        {
            splashImages = images;
        }

        private IEnumerator ShowSplashImages()
        {
            if (splashImages != null && splashImages.Length > 0)
            {
                for (int i = 0; i < splashImages.Length; i++)
                {
                    // Mostrar imagem atual
                    splashImage.sprite = splashImages[i];

                    // Efeito de zoom gradual
                    if (useZoomEffect)
                    {
                        splashImage.transform.localScale = Vector3.zero;
                        yield return StartCoroutine(ZoomIn());
                    }

                    yield return new WaitForSeconds(fadeDuration);

                    // Fade out
                    yield return StartCoroutine(FadeOut());
                }
            }

            // Término da sequência de imagens
            // Você pode adicionar código aqui para carregar a próxima cena ou realizar outras ações após a tela de inicialização
        }

        private IEnumerator ZoomIn()
        {
            while (splashImage.transform.localScale.x < 1f)
            {
                splashImage.transform.localScale += new Vector3(zoomSpeed, zoomSpeed, 0f);
                yield return null;
            }
        }

        private IEnumerator FadeOut()
        {
            float alpha = 1f;
            while (alpha > 0f)
            {
                alpha -= Time.deltaTime / fadeDuration;
                splashImage.color = new Color(splashImage.color.r, splashImage.color.g, splashImage.color.b, alpha);
                yield return null;
            }

            splashImage.color = new Color(splashImage.color.r, splashImage.color.g, splashImage.color.b, 0f);
        }

        private IEnumerator FadeIn()
        {
            splashImage.color = new Color(splashImage.color.r, splashImage.color.g, splashImage.color.b, 0f);
            float alpha = 0f;
            while (alpha < 1f)
            {
                alpha += Time.deltaTime / fadeDuration;
                splashImage.color = new Color(splashImage.color.r, splashImage.color.g, splashImage.color.b, alpha);
                yield return null;
            }
        }
    }
}