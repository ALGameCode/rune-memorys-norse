/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Sound
{
    [CreateAssetMenu(fileName = "SoundConfiguration", menuName = "Configurations/NewSoundConfiguration", order = 1)]
    public class SoundConfiguration : ScriptableObject
    {
        [Header("Songs Settings")]
        public List<AudioClip> bgmSongs= new List<AudioClip>();
        public List<AudioClip> sfxSongs = new List<AudioClip>();

        [Header("Songs Volume")]
        [Range (0,1)]
        public float volumeBGM;
        [Range (0,1)]
        public float volumeSFX;
    }
}
