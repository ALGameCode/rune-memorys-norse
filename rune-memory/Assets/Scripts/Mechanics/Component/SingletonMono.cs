/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using ALGC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Singleton pattern for monobehaviour classes
/// References:
/// https://gist.github.com/whitebull/a5262e57579f42333899#file-singleton-cs-L24
/// https://answers.unity.com/questions/17916/singletons-with-coroutines.html
/// </summary>
namespace ALGC
{
    public class SingletonMono<T> : MonoBehaviour where T : SingletonMono<T>
    {
        
        public bool isDontDestructiveOnLoad = false;
        public bool takeRoot = false;
        private static T instance = null;
        // NOTE: So, an instance inside get will only be created when it is called, so this can cause problems
        public static T Instance 
        {
            get
            {
                if(instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));
                    if(instance == null)
                    {
                        string goName = typeof(T).ToString();
                        GameObject go = GameObject.Find(goName);
                        if(go == null)
                        {
                            go = new GameObject();
                            go.name = goName;
                        }
                        instance = go.AddComponent<T>();
                    }
                }
                return instance;
            }   
        }

        protected virtual void Awake() 
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }

            if(isDontDestructiveOnLoad)
            {
                if(takeRoot)
                {
                    DontDestroyOnLoad(transform.root.gameObject);
                }
                else
                {
                    DontDestroyOnLoad(this.gameObject);
                }
            }
        }

        protected virtual void OnApplicationQuit() 
        {
            instance = null;
        }
    }
}