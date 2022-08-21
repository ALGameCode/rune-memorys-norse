/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using System;
using ALGC.Mechanics;

/// <summary>
/// UI Element Manager
/// </summary>
namespace ALGC.MenuUI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance = null;

        #region GameScreenConfigVars

        [Header("Grid Game Settings")]
        public GridLayoutGroup grid;
        public GameObject slotPrefab;

        [Header("Game Info Settings")]
        public TextMeshProUGUI levelNameText;
        public TextMeshProUGUI timerText;
        public TextMeshProUGUI treasuresText;
        public TextMeshProUGUI vikingsText;

        [Header("Game Popup Settings")]
        public Button pauseGameButton;
        public GameObject pauseGamePopup;
        public GameObject helpGamePopup;

        #endregion
        #region EndScreenConfigVars

        [Header("End Game Screen Settings")]
        public GameObject endGamePopupPainel;
        public TextMeshProUGUI endResultText;
        public GameObject endGamePopupInfo;
        public Button endNewGameButton;

        [Header("End Game Info Settings")]
        public TextMeshProUGUI endTreasuresText;
        public TextMeshProUGUI endVikingsText;
        public TextMeshProUGUI endTimeText;
        public TextMeshProUGUI endRoundsText;
        public TextMeshProUGUI endExperienceText;

        [Header("Winner Screen Settings")]
        [SerializeField] private string winnerText = "Successful Incursion";
        [SerializeField] private Color winnerColor;
        [SerializeField] private GameObject winnerBackgroundImage;

        [Header("Defeat Screen Settings")]
        [SerializeField] private string defeatText = "Defeated";
        [SerializeField] private Color defeatColor;
        [SerializeField] private GameObject defeatBackgroundImage;

        [Header("Escaped Screen Settings")]
        [SerializeField] private string escapedText = "You Escaped";
        [SerializeField] private Color escapedColor;
        [SerializeField] private GameObject escapedBackgroundImage;

        #endregion

        [HideInInspector] public List<GameObject> slots = new List<GameObject>();

        #region ClassInitialization

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        private void Start() 
        {
            pauseGameButton.onClick.AddListener(GameManager.Instance.PauseGame);
        }

        private void Update()
        {
            if(GameManager.Instance.IsPlayGame && ScenesManager.Instance.CurrentSceneName == "Game")
            {
                ShowTimer();
            }
        }

        #endregion

        #region GridSlotsSettings

        /// <summary>
        /// Create the slots on the grid
        /// </summary>
        /// <param name="quantityPieces">Quantity of pieces that must be created</param>
        public void CreateSlotsGrid(int quantityPieces)
        {
            if(slotPrefab != null && quantityPieces > 0)
            {
                Transform transformParent = grid.gameObject.GetComponent<Transform>();
                int count = 0;
                while(slots.Count < quantityPieces)
                {
                    GameObject newSlot = Instantiate(slotPrefab, new Vector3(0,0,0), Quaternion.identity, transformParent);
                    newSlot.GetComponent<Slot>().SlotId = count;
                    slots.Add(newSlot);
                    count++;
                }
            }
        }

        /// <summary>
        /// Get and store all grid slots
        /// </summary>
        /// <param name="quantityPieces">Quantity of pieces that must be created</param>
        public void GetAllSlotsGrid(int quantityPieces)
        {
            slots = GameObject.FindGameObjectsWithTag("Slot").ToList();
            while(slots.Count > quantityPieces)
            {
                int val = slots.Count - quantityPieces;
                for(int i = 0; i < val; i++)
                {
                    if(i >= slots.Count) break;
                    slots[i].SetActive(false);
                    slots.RemoveAt(i);
                }
            }

        }

        /// <summary>
        /// Configure grid visually
        /// </summary>
        public void ConfigureGrid(int gridPaddingLeft, int gridPaddingRight, int gridPaddingTop, int gridPaddingBotton, float gridCellSizeX, float gridCellSizeY, float gridSpacingX, float gridSpacingY)
        {
            if(grid != null)
            {
                grid.padding.left = gridPaddingLeft;
                grid.padding.right = gridPaddingRight;
                grid.padding.top = gridPaddingTop;
                grid.padding.bottom = gridPaddingBotton;
                grid.cellSize = new Vector2(gridCellSizeX, gridCellSizeY);
                grid.spacing = new Vector2(gridSpacingX, gridSpacingY);
            }
        }

        /// <summary>
        /// Put each rune in a slot
        /// </summary>
        /// <param name="runes">list of runes</param>
        public void SetRunesOnSlots(List<string> runes)
        {   
            if(runes != null)
            {
                if(runes.Count >= slots.Count)
                {
                    for(int i = 0; i < slots.Count; i++)
                    {
                        slots[i].GetComponent<Slot>().ThisRune = LevelGameManager.Instance.GetRuneByName(runes[i]);
                    }
                }
            }
        }

        #endregion
        
        #region ScreenUISettings

        /// <summary>
        /// Fill score and status values, and create endgame screen
        /// </summary>
        public void ShowEndGameScreen()
        {
            endTreasuresText.text = $"+ {LevelGameManager.Instance.treasures}";
            endVikingsText.text = $"{GameManager.Instance.playerStatus.ActiveVikings}/{GameManager.Instance.playerStatus.TotalVikings}";
            endTimeText.text = timerText.text.ToString();
            endRoundsText.text = Turn.Instance.TotalTurns.ToString();
            //endExperienceText = ; // TODO: Calculate experience based on lost treasures, time, rounds and vikings
            GameManager.Instance.playerStatus.Treasures += LevelGameManager.Instance.treasures;
        }

        /// <summary>
        /// Create end screen of player won
        /// </summary>
        public void CreateWinnerScreen()
        {
            ShowEndGameScreen();
            endResultText.text = winnerText;
            endResultText.color = winnerColor;
            endGamePopupInfo.SetActive(true);
            endGamePopupPainel.SetActive(true);
            winnerBackgroundImage.SetActive(true);
            //endNewGameButton.gameComponent.SetActive(true);
            pauseGameButton.interactable = false;
            GameManager.Instance.PauseGame();
            GameManager.Instance.SaveAllPlayerInfo(); // TODO: When adding bonus call this later
            LevelGameManager.Instance.FinishLevel();
        }

        /// <summary>
        /// Create lost player end screen
        /// </summary>
        public void CreateDefeatScreen()
        {
            endResultText.text = defeatText;
            endResultText.color = defeatColor;
            defeatBackgroundImage.SetActive(true);
            endGamePopupPainel.SetActive(true);
            pauseGameButton.interactable = false;
            GameManager.Instance.PauseGame();
            GameManager.Instance.SaveAllPlayerInfo();
            LevelGameManager.Instance.FinishLevel();
        }

        /// <summary>
        /// Create escaped player end screen
        /// </summary>
        public void CreateEscapedScreen()
        {
            ShowEndGameScreen();
            endResultText.text = escapedText;
            endResultText.color = escapedColor;
            endGamePopupInfo.SetActive(true);
            endGamePopupPainel.SetActive(true);
            escapedBackgroundImage.SetActive(true);
            //GameManager.Instance.PauseGame();
            GameManager.Instance.SaveAllPlayerInfo(); // TODO: When adding bonus call this later
            LevelGameManager.Instance.FinishLevel();
        }

        /// <summary>
        /// Adds to the text in the ui the amount of vikings remaining
        /// </summary>
        /// <param name="numVikingsAlive">Living or active Vikings</param>
        /// <param name="numVikingsTotal">Total Vikings the player owns</param>
        public void ShowVikingTextUI(int numVikingsAlive, int numVikingsTotal)
        {
            vikingsText.text = $"{numVikingsAlive} / {numVikingsTotal}";
        }

        /// <summary>
        /// Adds to the text in the UI the amount of treasures
        /// </summary>
        /// <param name="numTreasures">Quantity of treasures</param>
        public void ShowTreasuresTextUI(int numTreasures)
        {
            treasuresText.text = $"{numTreasures}";
        }

        /// <summary>
        /// temporary function
        /// Pause when calling this function by click event
        /// </summary>
        public void PauseGameOnClick()
        {
            GameManager.Instance.PauseGame();
        }

        /// <summary>
        /// Back to main menu
        /// </summary>
        public void ReturnToMainMenu()
        {
            ScenesManager.Instance.ChangeSceneByName("Menu");
        }

        /// <summary>
        /// Updates and shows game timer
        /// </summary>
        public void ShowTimer()
        {
            int hour, minute, second;
            float timer = LevelGameManager.Instance.GameTimer;
            minute = (int)timer/60;
            hour = minute/60;
            second = (int)timer % 60;
            minute = minute - (hour * 60);

            timerText.text = $"{hour}:{minute}:{second}";
        }

        #endregion
    }
}

/* TODO:
 * Refactor this class, it's too big and full of dependencies.
 * How does mainmenu.cs transform this class into UI actions only and pass functions that are called from 
 * others by the instance to own classes.
 */