/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using ALGC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rune registration and configuration
/// </summary>
namespace ALGC
{
    [CreateAssetMenu(fileName = "RuneConfiguration", menuName = "Configurations/NewRuneConfiguration", order = 1)]
    public class RuneConfiguration : ScriptableObject
    {
        [Header("Runes Settings")]
        [SerializeField] private List<Rune> runes = new List<Rune>();
        
        public Dictionary<string, Rune> runesDictionary = new Dictionary<string, Rune>();

        /// <summary>
        /// Configure runes as a dictionary for easy access
        /// O(n)
        /// </summary>
        public void ConfigureDictionary()
        {
            if(runes != null)
            {
                foreach (var rune in runes)
                {
                    runesDictionary.Add(rune.runeName, rune);
                }
            }
        }
    }
}
