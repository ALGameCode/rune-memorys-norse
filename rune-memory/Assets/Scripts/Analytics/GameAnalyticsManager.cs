/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using ALGC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using GameAnalyticsSDK;

/// Import Game Analytics
namespace ALGC.Analytics
{
    public class GameAnalyticsManager : MonoBehaviour //, IGameAnalyticsATTListener
    {
        public static GameAnalyticsManager instance;

        //private bool loaded = false;
        #region ClassInitialization

        void Awake()
        {
            if (instance == null)
            {
                DontDestroyOnLoad(gameObject);
                instance = this;
                //loaded = false;
            } 
            else
            {
                Destroy(this.gameObject);
            }
        }

        void Start()
        {
            /*if(Application.platform == RuntimePlatform.IPhonePlayer)
            {
                GameAnalytics.RequestTrackingAuthorization(this);
            }
            else
            {
                GameAnalytics.Initialize();
            }*/
        }

        #endregion
    }
}
