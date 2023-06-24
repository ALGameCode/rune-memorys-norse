using UnityEditor;
using UnityEngine;

public static class CustomEditorMenu
{
    [MenuItem("ALGC Custom Menu/Delete Save Data PlayerPrefs")]
    private static void DeleteSaveData()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Save data deleted!");
    }
}
