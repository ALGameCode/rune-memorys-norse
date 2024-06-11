/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sound;
using Mechanics;

/// <summary>
/// Music action buttons behavior
/// </summary>
namespace MenuUI
{
    [RequireComponent(typeof(Button))]
    public class SoundButtons : MonoBehaviour
    {
        [Header("Mute Sound Sprites")]
        [Tooltip("At index 0 is equivalent to mute and 1 to playing")] 
        public Sprite[] muteSoundButtonSprites = new Sprite[2];
        [Tooltip("Image present as child object of button object")] 
        public Image muteSoundImage;
        [Tooltip("Image present as child object of button object")] 
        public string type = "BGM";
        private Button button;

        private void Start()
        {
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(CallMuteSound);
            ChangeSpriteButtonMute();
        }

        /// <summary>
        /// Mute or unmute the sound
        /// </summary>
        public void CallMuteSound()
        {
            switch (type)
            {
                case "BGM":
                    SoundManager.Instance.MuteBackgroundMusic();
                    GameManager.Instance.IsSoundMute = Sound.SoundManager.Instance.SourcePlayBGM.mute;
                    ChangeSpriteButtonMute();
                    break;
                case "SFX":
                    // ... SFX
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Change the button icon
        /// </summary>
        public void ChangeSpriteButtonMute()
        {            
            if(GameManager.Instance.IsSoundMute)
            {
                muteSoundImage.sprite = muteSoundButtonSprites[0];
            }
            else
            {
                muteSoundImage.sprite = muteSoundButtonSprites[1];
            }
        }
    }
}

// TODO: generalize this class to any type of button that changes the sprite