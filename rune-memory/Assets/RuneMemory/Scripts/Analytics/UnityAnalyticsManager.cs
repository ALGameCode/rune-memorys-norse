/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
using Unity.Services.Core.Environments;

namespace Analytics
{
    public class UnityAnalyticsManager : SingletonMono<UnityAnalyticsManager>
    {
        private bool loaded = false;

        #region ClassInitialization

        private void FixedUpdate()
        {
            if (loaded) return;
            if (UnityServices.State == ServicesInitializationState.Initialized)
            {
                loaded = true;
                ConsentRequest();
            }
        }

        #endregion

        async void ConsentRequest()
        {
            try
            {
                List<string> consentIdentifiers = await AnalyticsService.Instance.CheckForRequiredConsents(); //  check if any privacy consents are required
            }
            catch (ConsentCheckException e)
            {
                Debug.LogError($"Something went wrong when checking the GeoIP, check the e.Reason and handle appropriately: {e}");
            }
        }

        private void AnalyticsCreateCustomEvent(string eventName, Dictionary<string, object> eventParameters)
        {
            #if !UNITY_EDITOR && !DEVELOPMENT_BUILD

            AnalyticsService.Instance.CustomData(eventName, eventParameters); 
            AnalyticsService.Instance.Flush();

            #endif
        }
    }
}
