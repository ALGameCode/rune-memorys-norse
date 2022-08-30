/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using ALGC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Slot Description and Functions
/// </summary>
namespace ALGC.Mechanics
{
    [RequireComponent(typeof(Image), typeof(Button))]
    public class Slot : MonoBehaviour
    {
        [Header("Slot Settings")]
        public Rune ThisRune;

        [HideInInspector] public SlotStatus slotStatus = SlotStatus.HIDDEN;
        public int SlotId { get; set; } = 0;
        private Sprite hiddenSprite;

        #region ClassInitialization

        private void Start() 
        {
            hiddenSprite = this.gameObject.GetComponent<Image>().sprite;
        }

        #endregion

        /// <summary>
        /// External call on this object.
        /// Ask to see a rune turned
        /// </summary>
        public void SeeRune()
        {
            if(ValidTurnMovement())
            {
                ShowRune();
                Turn.Instance.NextStep();
                GameManager.Instance.levelManager.runeSlotShowerIndex.Add(SlotId);
            }
        }

        /// <summary>
        /// Show slot rune
        /// </summary>
        public void ShowRune()
        {
            TurnRune(SlotStatus.SHOWING, ThisRune.useSkin);
        }

        /// <summary>
        /// Hide slot rune
        /// </summary>
        public void HideRune()
        {
            TurnRune(SlotStatus.HIDDEN, hiddenSprite);
        }

        /// <summary>
        /// If you find the pair, show the rune and make the 
        /// button (slot) non-iterative so you don't move the piece anymore
        /// </summary>
        public void FoundRune()
        {
            TurnRune(SlotStatus.FOUND, ThisRune.useSkin);
            this.gameObject.GetComponent<Button>().interactable = false;
        }

        /// <summary>
        /// Flip slot/rune to show or hide
        /// </summary>
        /// <param name="newStatus">New slot state</param>
        /// <param name="sprite">New sprite</param>
        private void TurnRune(SlotStatus newStatus, Sprite sprite)
        {
            if((slotStatus != newStatus) 
            && (slotStatus != SlotStatus.FOUND))
            {
                slotStatus = newStatus;
                ChangeSprite(sprite);
            }
        }

        /// <summary>
        /// Change slot sprite
        /// </summary>
        private void ChangeSprite(Sprite sprite)
        {
            this.gameObject.GetComponent<Image>().sprite = sprite;
        }

        /// <summary>
        /// Check if the move can be made
        /// O(1)
        /// </summary>
        /// <returns>If yes return true, if not return false</returns>
        private bool ValidTurnMovement()
        {
            if(slotStatus == SlotStatus.HIDDEN)
            {
                if(Turn.Instance.TurnController != TurnStep.SECOND_PIECE)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
