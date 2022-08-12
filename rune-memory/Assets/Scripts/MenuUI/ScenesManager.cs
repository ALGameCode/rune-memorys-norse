using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// General scene manager
/// </summary>
public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance;

    public string CurrentSceneName { get; private set; }
    
    #region ClassInitialization

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    #endregion
   
    /// <summary>
    /// Change scene by name
    /// </summary>
    /// <param name="sceneName">Scene name</param>
    public void ChangeSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Change scene by id/index
    /// </summary>
    /// <param name="sceneId">id/index</param>
    public void ChangeSceneById(string sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    /// <summary>
    /// Get index from the next scene, check if the index is valid and move to the next scene.
    /// </summary>
    public void ChangeToNextScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        index++;
        if(CheckChangeToNext(index))
        {
            SceneManager.LoadScene(index);
        }
    }

    /// <summary>
    /// Checks if the next scene index exists
    /// </summary>
    /// <param name="index">Next scene index</param>
    /// <returns>Boolean value, if exists true, if not false</returns>
    public bool CheckChangeToNext(int index)
    {
        if(index < SceneManager.sceneCountInBuildSettings)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Get the name of the current scene and store it in the CurrentSceneName variable leaving it available for the system to use.
    /// </summary>
    public void GetCurrentSceneName() 
    {
        CurrentSceneName = SceneManager.GetActiveScene().name;
    }
}
