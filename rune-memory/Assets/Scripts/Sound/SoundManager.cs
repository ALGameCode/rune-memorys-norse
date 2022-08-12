using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Control and settings for in-game music and sounds
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("Sound Settings Object")]
    public SoundConfiguration soundConfiguration;

    public AudioSource SourcePlay { get; private set; }
    
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
        SourcePlay = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if(!SourcePlay.isPlaying)
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
        PlaySong(list[Random.Range(0, list.Count)], soundConfiguration.volumeBGM);
    }

    /// <summary>
    /// Plays a specific audioclip also set the volume
    /// </summary>
    /// <param name="audio">Audioclip</param>
    /// <param name="volume">value if volume</param>
    private void PlaySong(AudioClip audio, float volume)
    {
        SourcePlay.clip = audio;
        SourcePlay.volume = volume;
        SourcePlay.Play();
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
        if(SourcePlay.mute)
        {
            SourcePlay.mute = false;
        }
        else
        {
            SourcePlay.mute = true;
        }
    }
}

/// TODO: Add functions for separate sfx operations and put audiosource as parameter in all functions