using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [Space]

    [Header("Audio Settings")]
    public AudioSource musicPlayer; //public reference
    public AudioSource sfxPlayer; //public reference
    public SoundLibrary sounds;
    public ScoreHandler scoreHandler;

    [Header("Characters")]
    public Animator readerAnimator;

    [Header("Scroll")]
    public Transform scroll;
    public Transform playerUi;

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

        if(readerAnimator != null)
        {
            StartCoroutine(Delay());
            IEnumerator Delay()
            {
                yield return new WaitForSeconds(.5f);
                readerAnimator.SetTrigger("read");
            }
        }
        if(scroll != null)
        {
            scroll.DOScale(.3f, .4f).From().SetEase(Ease.OutBack).SetDelay(.5f);
        }

        if(playerUi != null)
        {
            playerUi.DOScale(0, .4f).From().SetEase(Ease.OutBack).SetDelay(.7f);
        }
    }
    
}