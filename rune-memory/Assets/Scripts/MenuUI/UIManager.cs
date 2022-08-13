using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using System;

/// <summary>
/// UI Element Manager
/// </summary>
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

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
    #region OthersButtons
    [Header("Mute BGM Sprites")]
    [Tooltip("At index 0 is equivalent to mute and 1 to playing")] 
    public Sprite[] muteBGMButtonSprites = new Sprite[2];
    public Image muteBgmImage;
    [Header("Mute SFX Sprites")]
    [Tooltip("At index 0 is equivalent to mute and 1 to playing")] 
    public Sprite[] muteSFXButtonSprites = new Sprite[2];
    public Image muteSfxImage;
    #endregion 

    [HideInInspector] public List<GameObject> slots = new List<GameObject>();

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
    }

    private void Update()
    {
        if(GameManager.instance.IsPlayGame)
        {
            ShowTimer();
        }
    }

    #endregion

    #region GridSlotsSettings

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

    public void SetRunesOnSlots(List<string> runes)
    {   
        if(runes != null)
        {
            if(runes.Count >= slots.Count)
            {
                for(int i = 0; i < slots.Count; i++)
                {
                    slots[i].GetComponent<Slot>().ThisRune = LevelGameManager.instance.GetRuneByName(runes[i]);
                }
            }
        }
    }

    #endregion
    
    #region ScreenUISettings

    public void ShowEndGameScreen()
    {

    }

    public void CreateWinnerScreen(TextMeshProUGUI textTitle, Image imageBackground)
    {
        textTitle.text = winnerText;

    }

    public void ShowVikingTextUI(int numVikingsAlive, int numVikingsTotal)
    {
        vikingsText.text = $"{numVikingsAlive} / {numVikingsTotal}";
    }

    public void ShowTreasuresTextUI(int numTreasures)
    {
        treasuresText.text = $"{numTreasures}";
    }

    public void ShowTimer()
    {
        int hour, minute, second;
        float timer = LevelGameManager.instance.GameTimer;
        minute = (int)timer/60;
        hour = minute/60;
        second = (int)timer % 60; //- (minute * 60);
        minute = minute - (hour * 60);

        timerText.text = $"{hour}:{minute}:{second}";
    }

    #endregion

    #region ButtonsOthers
    
    public void ChangeSpriteButtonMute(string type)
    {
        if(SoundManager.instance.SourcePlay.mute)
        {
            if(type.Equals("BGM")) muteBgmImage.sprite = muteBGMButtonSprites[0];
            else if(type.Equals("SFX")) muteSfxImage.sprite = muteSFXButtonSprites[0];
        }
        else
        {
            if(type.Equals("BGM")) muteBgmImage.sprite = muteBGMButtonSprites[1];
            else if(type.Equals("SFX")) muteSfxImage.sprite = muteSFXButtonSprites[1];
        }
    }

    #endregion
}
