using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [Space]

    public bool canPlay = true;

    [Header("Audio Settings")]
    public AudioSource musicPlayer; 
    public AudioSource sfxPlayer;
    public AudioSource forgePlayer;
    public AudioSource ambiencePlayer;
    public SoundLibrary sounds;
    public ScoreHandler scoreHandler;

    [Header("Characters")]
    public Animator readerAnimator;

    [Header("Scroll")]
    public Transform scroll;
    public Transform playerUi;

    [Header("UI")]
    public Image fadeImage;
    public SpriteRenderer gameoverScreen;

    private void Awake()
    {
        Time.timeScale = 1;
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        fadeImage.DOFade(1, 0);
        fadeImage.DOFade(0, .3f);
        float musicVolume = musicPlayer.volume;
        musicPlayer.volume = 0;
        musicPlayer.DOFade(musicVolume, .4f);

        if (readerAnimator != null)
        {
            StartCoroutine(Delay());
            IEnumerator Delay()
            {
                yield return new WaitForSeconds(.5f);
                readerAnimator.SetTrigger("read");
            }
        }
        if (scroll != null)
        {
            scroll.DOScale(.3f, .4f).From().SetEase(Ease.OutBack).SetDelay(.5f);
        }

        if (playerUi != null)
        {
            playerUi.DOScale(0, .4f).From().SetEase(Ease.OutBack).SetDelay(.7f);
        }
    }

    public void GameOver()
    {
        canPlay = false;
        
        musicPlayer.DOPitch(0, 1f).SetUpdate(true).OnComplete(() => CompleteTransition());
        ambiencePlayer.DOFade(0, .5f).SetUpdate(true);
        DOVirtual.Float(1, 0, 1f, (x) => Time.timeScale = x).SetUpdate(true);
        gameoverScreen.DOFade(1, .8f).SetUpdate(true);
    }

    private void CompleteTransition()
    {
        Time.timeScale = 1;
        StaticMemory.Score = scoreHandler.score;
        SceneManager.LoadSceneAsync("GameOver");
    }
}