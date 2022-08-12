using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Level Game Manager and Constructor
/// </summary>
public class LevelGameManager : MonoBehaviour
{
    public static LevelGameManager instance;

    public LevelDifficultyTag levelDifficulty = LevelDifficultyTag.EASY;
    private Difficulty difficulty;

    public List<string> RunesGrid { get; private set; }
    [HideInInspector] public List<int> runeSlotShowerIndex = new List<int>();

    // Time
    public float GameTimer { get; private set; } = 0f;
    public float turnTimer = 0f;

    public bool Result { get; set; } // True = Correct ;  False = Wrong

    private bool showingAllRunes = false;

    // Player
    public float treasures = 0;
    public int vikings = 0;
    public float energy = 0;
    
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

    private void Start()
    {
        StartLevel();
        ResetRunesSkin();
    }

    private void Update() 
    {
        GameTimer += Time.deltaTime;
        StartMemorization(GameTimer, difficulty.startingTimeShowRunes);
        if(Turn.Instance().TurnController == TurnStep.SECOND_PIECE)
        {
            turnTimer += Time.deltaTime;
            EndTurnGame();
        }
    }

    #endregion

    public void StartLevel()
    {
        if(GameManager.instance.levelController != null)
        {
            levelDifficulty = GameManager.instance.levelController.LevelDifficulty;
        }
        GameManager.instance.runesConfiguration.ConfigureDictionary();
        ChooseRunes(GetRunes());
        ConfigureGrid();
        GameManager.instance.IsPlayGame = true;
    }
    
    /// <summary>
    /// Initializes the call of all functions responsible for creating and organizing the rune grid
    /// </summary>
    private void ConfigureGrid ()
    {
        UIManager.instance.CreateSlotsGrid(difficulty.quantityPieces);
        UIManager.instance.ConfigureGrid(difficulty.gridPaddingLeft, difficulty.gridPaddingRight, 
        difficulty.gridPaddingTop, difficulty.gridPaddingBotton, difficulty.gridCellSizeX, 
        difficulty.gridCellSizeY, difficulty.gridSpacingX, difficulty.gridSpacingY);
        UIManager.instance.SetRunesOnSlots(RunesGrid);
    }

    private List<string> GetRunes()
    {
        List<string> list = new List<string>();
        if(GameManager.instance.levelDifficultyConfiguration != null)
        {
            for(int x = 0; x < GameManager.instance.runesConfiguration.runesDictionary.Count; x++)
            {
                list.Add(GameManager.instance.runesConfiguration.runesDictionary.ElementAt(x).Key);
            }
        }
        return GameManager.instance.BlendList(list);
    }

    private void ChooseRunes (List<string> newList)
    {
        RunesGrid = new List<string>();
        List<string> list = new List<string>();

        if(GameManager.instance.levelDifficultyConfiguration != null)
        {
            list = newList;

            difficulty = GetDifficultySettings(levelDifficulty);

            // Get the result and remove the same number of items from the list
            int numRunesRemove = list.Count - (difficulty.quantityPieces / 2);

            for(int i = 0; i < numRunesRemove; i++)
            {
                list.RemoveAt(Random.Range(0, list.Count - 1));
            }

            // Duplicate all list items
            int val = list.Count;

            for(int i = 0; i < val; i++)
            {
                list.Add(list[i]);
            }

            // Blend and save in RunesGrid vector
            RunesGrid = GameManager.instance.BlendList(list);
        }

    }

    /// <summary>
    /// Browse or choose difficulty setting
    /// </summary>
    /// <param name="levelDifficultySet">Difficulty type selected by tag</param>
    /// <returns>Selected difficulty setup</returns>
    private Difficulty GetDifficultySettings(LevelDifficultyTag levelDifficultySet)
    {
        foreach(var dif in GameManager.instance.levelDifficultyConfiguration.difficulties)
        {
            if(dif.levelDifficultyTag == levelDifficultySet)
            {
                return dif;
            }
        }
        return null;
    }    

    
    #region OnGameFunctions

    public bool ValidRunes(List<int> slotsIndex)
    {
        if(slotsIndex.Count > 0)
        {
            string rune = UIManager.instance.slots[slotsIndex[0]].GetComponent<Slot>().ThisRune.runeName;
            foreach(int index in slotsIndex)
            {
                if(!rune.Equals(UIManager.instance.slots[index].GetComponent<Slot>().ThisRune.runeName))
                {
                    return false;
                }
            }
            return true;
        }
        return false; 
    }

    /// <summary>
    /// Initial memorization step
    /// </summary>
    /// <param name="timer">Playing time</param>
    /// <param name="limitTime">Timeout to memorize</param>
    private void StartMemorization(float timer, float limitTime)
    {
        if((timer <= limitTime) && (!showingAllRunes))
        {
            ShowAllRunes(UIManager.instance.slots);
            showingAllRunes = true;
        }
        else if ((timer >= limitTime) && (showingAllRunes))
        {
            HideAllRunes(UIManager.instance.slots);
            showingAllRunes = false;
        }
    }

    public void WrongResult()
    {
        HideSelectedRunes(runeSlotShowerIndex);
        runeSlotShowerIndex.Clear();
        // Perder pontos
        // NextStep();
    }

    public void CorrectResult()
    {
        MarkFoundRunes(runeSlotShowerIndex);
        runeSlotShowerIndex.Clear();
        // Mostrar PopUp
        // Somar Pontos
        // NextStep();
    }

    private void HideSelectedRunes(List<int> slotsIndex)
    {
        if(slotsIndex.Count > 0)
        {
            foreach(int index in slotsIndex)
            {
                UIManager.instance.slots[index].GetComponent<Slot>().HideRune();
            }
        }
    }

    private void MarkFoundRunes(List<int> slotsIndex)
    {
        if(slotsIndex.Count > 0)
        {
            foreach(int index in slotsIndex)
            {
                UIManager.instance.slots[index].GetComponent<Slot>().FoundRune();
            }
        }
    }

    private void EndTurnGame()
    {
        if(turnTimer >= Turn.Instance().EndTurnTimer)
        {
            bool result = ValidRunes(runeSlotShowerIndex);
            if(result)
            {
                CorrectResult();
            }
            else
            {
                WrongResult();
            }
            Turn.Instance().NextStep();
            turnTimer = 0f;
        }
    }

    #endregion

    #region RunesOthersFunctions

    /// <summary>
    /// Find a rune in the registered runes dictionary
    /// </summary>
    /// <param name="name">name of the rune you are search</param>
    /// <returns>Rune</returns>
    public Rune GetRuneByName(string name)
    {
        return GameManager.instance.runesConfiguration.runesDictionary[name];
    }

    public void ShowAllRunes(List<GameObject> slotObjects)
    {
        if(slotObjects != null)
        {
            foreach(var slot in slotObjects)
            {
                slot.GetComponent<Slot>().ShowRune();
            }
        }
    }

    public void HideAllRunes(List<GameObject> slotObjects)
    {
        if(slotObjects != null)
        {
            foreach(var slot in slotObjects)
            {
                slot.GetComponent<Slot>().HideRune();
            }
        }
    }

    public void ResetRunesSkin()
    {
        if(GameManager.instance.runesConfiguration.runesDictionary != null)
        {
            for(int i = 0; i < GameManager.instance.runesConfiguration.runesDictionary.Count; i++)
            {
                GameManager.instance.runesConfiguration.runesDictionary.ElementAt(i).Value.useSkin = GameManager.instance.runesConfiguration.runesDictionary.ElementAt(i).Value.RuneMainSkin;
            }
        }
        
    }

    #endregion
}

/* TODO:
 * Pass ResetRunesSkin() function to other code
 * Create success and error effects and animations and call functions CorrectResult() and WrongResult()
 * Improve the ChooseRunes function, break it into parts and check for possible failures with missing values ​​and variables
 * 
*/
