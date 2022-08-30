/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using ALGC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Abstract and generalist singleton class to facilitate 
/// the application of the singleton pattern in other classes
/// Undertand Singleton problems: https://pt.stackoverflow.com/questions/18860/por-que-n%C3%A3o-devemos-usar-singleton
/// Singleton Patterns: https://refactoring.guru/pt-br/design-patterns/singleton
/// </summary>
namespace ALGC
{
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
}
