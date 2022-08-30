/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Ref.: https://learn.unity.com/tutorial/editor-scripting#5c7f8528edbc2a002053b5f8
/// </summary>
public class MenuTools
{
    [MenuItem("ALGC Tools/Clear PlayerPrefs")]
    private static void NewMenuOption()
    {
        PlayerPrefs.DeleteAll();
    }
}
