using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [Space]

    [Header("Audio Settings")]
    public AudioSource musicPlayer; //public reference
    public AudioSource sfxPlayer; //public reference
    public SoundLibrary sounds;
    public ScoreHandler scoreHandler;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    
}