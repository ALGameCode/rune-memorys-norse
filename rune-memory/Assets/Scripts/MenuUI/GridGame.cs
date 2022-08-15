/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using System;
using Mechanics;

/// <summary>
/// ...
/// </summary>
namespace MenuUI
{
    public class GridGame : Singleton<GridGame>
    {
        [HideInInspector] public List<GameObject> slots = new List<GameObject>();

        /// <summary>
        /// ...
        /// </summary>
        public void CreateSlotsGrid(int quantityPieces, GameObject slotPrefab, GridLayoutGroup grid)
        {
            if(slotPrefab != null && quantityPieces > 0)
            {
                Transform transformParent = grid.gameObject.GetComponent<Transform>();
                int count = 0;
                while(slots.Count < quantityPieces)
                {
                    GameObject newSlot = MonoBehaviour.Instantiate(slotPrefab, new Vector3(0,0,0), Quaternion.identity, transformParent);
                    newSlot.GetComponent<Slot>().SlotId = count;
                    slots.Add(newSlot);
                    count++;
                }
            }
        }

        /// <summary>
        /// ...
        /// </summary>
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
        /// ...
        /// </summary>
        public void ConfigureGrid(ref GridLayoutGroup grid, int gridPaddingLeft, int gridPaddingRight, int gridPaddingTop, int gridPaddingBotton, float gridCellSizeX, float gridCellSizeY, float gridSpacingX, float gridSpacingY)
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
        /// ...
        /// </summary>
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
    }
}