using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Description of the Runes
/// </summary>
[Serializable]
public class Rune
{
    [Header("Rune Setting")]
    [Tooltip("Rune name")]
    public string runeName = "name";
    [Tooltip("Short text describing the rune")]
    public string runeDescription = "description";
    [Tooltip("Main skin sprite of this rune")]
    public Sprite RuneMainSkin;
    [Header("Rune Skins")]
    public List<RuneSkin> runeSkins = new List<RuneSkin>();

    public int RuneId {get; set;}
    public Sprite useSkin {get; set;}
}

[Serializable]
public class RuneSkin
{
    [Tooltip("This name refers to the name of the skin collection")]
    public string skinName = "skin name";
    [Tooltip("Rune skin sprite in this collection")]
    public Sprite skinSprite;
    public int SkinId {get; set;}
}
