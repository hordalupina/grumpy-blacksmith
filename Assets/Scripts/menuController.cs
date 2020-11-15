using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class menuController : MonoBehaviour
{
    public Image fadeImage;
    public AudioSource musicSource;
    public AudioSource forgeSource;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            forgeSource.Play();
            musicSource.DOFade(0, .3f);
            fadeImage.DOFade(1, .3f).OnComplete(()=>LoadGame());
        }
    }

    void LoadGame()
    {
        SceneManager.LoadSceneAsync("Main Game");
    }
}
