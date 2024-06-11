using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxConfiguration : ScriptableObject
{
    [Header("")]
    [SerializeField]
    private List<BuildBox> boxes = new List<BuildBox>();

    public Dictionary<string, BuildBox> buildBoxes = new Dictionary<string, BuildBox>();
}

[Serializable]
public class BuildBox
{
    [Tooltip("")]
    [SerializeField]
    private string buildName;

    public string BuildName
    {
        get { return buildName; }
        private set { buildName = value; }
    }

    [Tooltip("")]
    [SerializeField] 
    private Coins coinType;

    public Coins CoinType 
    { 
        get { return coinType; } 
        private set { coinType = value; }
    }

    [Tooltip("")]
    [SerializeField]
    private int buildCost;

    public int BuildCost
    {
        get { return buildCost; }
        private set { buildCost = value; }
    }

    [Tooltip("")]
    [SerializeField]
    private int levelRequired;


}