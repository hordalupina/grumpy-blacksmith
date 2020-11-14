using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLibrary : MonoBehaviour
{
    [Header("Music Files")]
    public AudioClip song_theme;
    public AudioClip song_bg;

    [Space]

    [Header("Sound Effects")]
    public AudioClip forgeUp;
    public AudioClip forgeDown;
    public AudioClip forgeLeft;
    public AudioClip forgeRight;
    public AudioClip miss;
}
