using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
using Unity.Services.Core.Environments;

public class UnityAnalyticsManager : MonoBehaviour
{
    public static UnityAnalyticsManager instance;

    private bool loaded = false;

    #region ClassInitialization

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
            loaded = false;
        } 
        else
        {
            Destroy(this.gameObject);
        }
    }

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
