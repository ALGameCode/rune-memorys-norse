/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
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
public class SingletonMono<T> : MonoBehaviour where T : SingletonMono<T>
{
    private static T instance = null;
    private static readonly object padlock = new object();
    public static T Instance
    {
        get
        {  
            lock (padlock)
            {
                if(instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T)); //new T();
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
    }

    protected virtual void Awake() 
    {
        if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(transform.root.gameObject);
    }

    protected virtual void OnApplicationQuit() 
    {
        instance = null;
    }
}
