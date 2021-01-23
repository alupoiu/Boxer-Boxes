using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    // Defines an auidoclip to play
    public AudioSource music;

    public void Update()
    {
        // Plays the defines audioclip
        music.volume = OptionsMenu.Data.volume/100f;
    }
}
