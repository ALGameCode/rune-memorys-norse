/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using ALGC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using ALGC.MenuUI;
using ALGC.Mechanics.Component;

/// <summary>
/// Level Game Manager and Constructor
/// </summary>
namespace ALGC.Mechanics
{
    public class LevelGameManager : SingletonMono<LevelGameManager>
    {      
        [Header("Level Settings")]
        public LevelDifficultyTag levelDifficulty = LevelDifficultyTag.EASY;
        public float turnTimer = 0f;

        private Difficulty difficulty;        
        [HideInInspector] public List<int> runeSlotShowerIndex = new List<int>();
        public List<string> RunesGrid { get; private set; }
        public float GameTimer { get; private set; } = 0f;
        public bool Result { get; set; } // True = Correct ;  False = Wrong
        public int treasures { get; private set; } = 0;
        private bool showingAllRunes = false;
        private const int treasuresPerRune = 10; // TODO: Define on setup level/difficulty
        private int foundRunes = 0;
        private int numRunes = 0;
        
        #region ClassInitialization

        private void Start()
        {
            if(ScenesManager.Instance.ReturnCurrentSceneName() == "Game")
            {
                StartLevel();
                UIManager.instance.ShowVikingTextUI(GameManager.Instance.playerStatus.ActiveVikings, GameManager.Instance.playerStatus.TotalVikings);
                UIManager.instance.ShowTreasuresTextUI(treasures);
            }
            /*else if(ScenesManager.Instance.ReturnCurrentSceneName() == "Menu")
            {
                Destroy(this.gameObject);
            }*/
        }

        private void Update() 
        {
            
            if(ScenesManager.Instance.ReturnCurrentSceneName() == "Game") 
            {
                if(!GameManager.Instance.IsPlayGame)
                {
                    StartLevel();
                }
                else if (GameManager.Instance.IsPlayGame)
                {
                    GameTimer += Time.deltaTime;
                    StartMemorization(GameTimer, difficulty.startingTimeShowRunes);
                    if(Turn.Instance.TurnController == TurnStep.SECOND_PIECE)
                    {
                        turnTimer += Time.deltaTime;
                        EndTurnGame();
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// Start creating the level
        /// </summary>
        public void StartLevel()
        {
            if(GameManager.Instance.levelController != null)
            {
                levelDifficulty = GameManager.Instance.levelController.GetLevelDifficultyTag();
            }
            if(GameManager.Instance.runesConfiguration.runesDictionary.Count <= 0)
            {
                GameManager.Instance.runesConfiguration.ConfigureDictionary();
            }
            ChooseRunes(GetRunes());
            ConfigureGrid();
            GameManager.Instance.IsPlayGame = true;
            ResetRunesSkin();
            numRunes = difficulty.quantityPieces / 2;
        }

        /// <summary>
        /// End and reset game variables
        /// </summary>
        public void FinishLevel()
        {
            GameTimer = 0f;
            treasures = 0;
            foundRunes = 0;
            runeSlotShowerIndex.Clear();
            RunesGrid.Clear();

            Turn.Instance.ResetTurnGame();
            
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

        /// <summary>
        /// Returns the list of shuffled runes
        /// </summary>
        /// <returns>List of shuffled runes</returns>
        private List<string> GetRunes()
        {
            List<string> list = new List<string>();
            if(GameManager.Instance.levelDifficultyConfiguration != null)
            {
                for(int x = 0; x < GameManager.Instance.runesConfiguration.runesDictionary.Count; x++)
                {
                    list.Add(GameManager.Instance.runesConfiguration.runesDictionary.ElementAt(x).Key);
                }
            }
            return GameManager.Instance.BlendList(list);
        }

        /// <summary>
        /// Choose, duplicate and shuffle the runes, finally saving them on the grid
        /// </summary>
        /// <param name="newList">New list of runes to pick and shuffle</param>
        private void ChooseRunes (List<string> newList)
        {
            RunesGrid = new List<string>();
            List<string> list = new List<string>();

            if(GameManager.Instance.levelDifficultyConfiguration != null)
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
                RunesGrid = GameManager.Instance.BlendList(list);
            }

        }

        /// <summary>
        /// Browse or choose difficulty setting
        /// </summary>
        /// <param name="levelDifficultySet">Difficulty type selected by tag</param>
        /// <returns>Selected difficulty setup</returns>
        public Difficulty GetDifficultySettings(LevelDifficultyTag levelDifficultySet)
        {
            foreach(var dif in GameManager.Instance.levelDifficultyConfiguration.difficulties)
            {
                if(dif.levelDifficultyTag == levelDifficultySet)
                {
                    return dif;
                }
            }
            return null;
        }    

        
        #region OnGameFunctions

        /// <summary>
        /// Check if the runes are the same
        /// </summary>
        /// <param name="slotsIndex">index of selected slot</param>
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

        /// <summary>
        /// Actions if you miss the rune
        /// </summary>
        public void WrongResult()
        {
            HideSelectedRunes(runeSlotShowerIndex);
            runeSlotShowerIndex.Clear();
            GameManager.Instance.playerStatus.ActiveVikings--;
            UIManager.instance.ShowVikingTextUI(GameManager.Instance.playerStatus.ActiveVikings, GameManager.Instance.playerStatus.TotalVikings);
        }

        /// <summary>
        /// Actions if you turn correct rune
        /// </summary>
        public void CorrectResult()
        {
            MarkFoundRunes(runeSlotShowerIndex);
            runeSlotShowerIndex.Clear();
            foundRunes++;
            treasures += treasuresPerRune; 
            UIManager.instance.ShowTreasuresTextUI(treasures);
        }

        /// <summary>
        /// Hide rune in selected slot
        /// </summary>
        /// <param name="slotsIndex">index of selected slot</param>
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

        /// <summary>
        /// Mark rune and slot as found by keeping face up and deactivating the slot
        /// </summary>
        /// <param name="slotsIndex">index of selected slot</param>
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

        /// <summary>
        /// End the turn and check if it was a correct or wrong
        /// </summary>
        private void EndTurnGame()
        {
            if(turnTimer >= Turn.Instance.EndTurnTimer)
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
                Turn.Instance.NextStep();
                EndGame();
                turnTimer = 0f;
            }
        }

        /// <summary>
        /// Check conditions to call end of game
        /// </summary>
        private void EndGame()
        {
            if(foundRunes == numRunes)
            {
                UIManager.instance.CreateWinnerScreen();
            }
            else if(GameManager.Instance.playerStatus.ActiveVikings <= 0)
            {
                UIManager.instance.CreateDefeatScreen();
            }

            GameManager.Instance.SaveAllPlayerInfo();
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
            return GameManager.Instance.runesConfiguration.runesDictionary[name];
        }

        /// <summary>
        /// Show all runes on the grid
        /// </summary>
        /// <param name="slotObjects">Slot where the rune is</param>
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

        /// <summary>
        /// Hide all grid runes
        /// </summary>
        /// <param name="slotObjects">Slot where the rune is</param>
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

        /// <summary>
        /// Reset rune skins to default
        /// </summary>
        public void ResetRunesSkin()
        {
            if(GameManager.Instance.runesConfiguration.runesDictionary != null)
            {
                for(int i = 0; i < GameManager.Instance.runesConfiguration.runesDictionary.Count; i++)
                {
                    GameManager.Instance.runesConfiguration.runesDictionary.ElementAt(i).Value.useSkin = GameManager.Instance.runesConfiguration.runesDictionary.ElementAt(i).Value.RuneMainSkin;
                }
            }
        }

        #endregion
    }
}

/* TODO:
 * Refactor this class, it's too big and full of dependencies
 * Pass ResetRunesSkin() function to other code
 * Create success and error effects and animations and call functions CorrectResult() and WrongResult()
 * Improve the ChooseRunes function, break it into parts and check for possible failures with missing values ​​and variables
 * 
*/
