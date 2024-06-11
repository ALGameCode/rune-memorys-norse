/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Control and settings for in-game music and sounds
/// </summary>
namespace Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : SingletonMono<SoundManager>
    {
        [Header("Sound Settings Object")]
        public SoundConfiguration soundConfiguration;

        public AudioSource SourcePlayBGM;
        public AudioSource SourcePlaySFX;

        public AudioMixer mixer;
        
        #region ClassInitialization

        private void Start()
        {
            //SourcePlayBGM = GetComponent<AudioSource>();
        }

        private void FixedUpdate()
        {
            if(!SourcePlayBGM.isPlaying)
            {
                ChooseNewSong();
            }
        }

        #endregion

        /// <summary>
        /// Choose a random sound from BGM list, and playing that sound
        /// </summary>
        private void ChooseNewSong()
        {
            List<AudioClip> list = soundConfiguration.bgmSongs; //GameManager.instance.BlendList(soundConfiguration.bgmSongs);
            PlaySongBGM(list[Random.Range(0, list.Count)], soundConfiguration.volumeBGM);
        }

        /// <summary>
        /// Plays a specific audioclip also set the volume
        /// </summary>
        /// <param name="audio">Audioclip</param>
        /// <param name="volume">value if volume</param>
        private void PlaySongBGM(AudioClip audio, float volume)
        {
            SourcePlayBGM.clip = audio;
            SourcePlayBGM.volume = volume;
            SourcePlayBGM.Play();
        }

        private void PlaySongSFX(AudioClip audio, float volume)
        {
            SourcePlaySFX.clip = audio;
            SourcePlaySFX.volume = volume;
            SourcePlaySFX.Play();
        }

        /// <summary>
        /// Stop playing sound from a specific audiosource
        /// </summary>
        /// <param name="source">Audio Source to stop</param>
        private void StopSong(AudioSource source)
        {
            source.Stop();
        }

        /// <summary>
        /// Mute specific audio source sound
        /// </summary>
        public void MuteBackgroundMusic()
        {
            if(SourcePlayBGM.mute)
            {
                SourcePlayBGM.mute = false;
            }
            else
            {
                SourcePlayBGM.mute = true;
            }
        }
    }
}

/// TODO: Add functions for separate sfx operations and put audiosource as parameter in all functions