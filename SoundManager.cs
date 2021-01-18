using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioSource music;

    void Update()
    {
        music.volume = OptionsMenu.Data.volume/100f;
    }
}
