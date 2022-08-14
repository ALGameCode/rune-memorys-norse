/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Abstract and generalist singleton class to facilitate 
/// the application of the singleton pattern in other classes
/// </summary>
public abstract class Singleton<T> where T : Singleton<T>, new()
{
    private static T instance = new T();
    private static readonly object padlock = new object();
    public static T Instance
    {
        get
        {  
            lock (padlock)
            {
                return instance;
            }
        }   
    }
}

