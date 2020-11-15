using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class retry : MonoBehaviour
{

    public CanvasGroup text;
    public Transform gameOverSprite;
    public Image fadeImage;


    private void Awake()
    {
        Time.timeScale = 1;
    }
    private void Start()
    {
        text.alpha = 0;
        text.DOFade(1, .5f);
        gameOverSprite.DOScale(0, .3f).From().SetEase(Ease.OutBounce);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            fadeImage.DOFade(1, .3f).OnComplete(() => SceneManager.LoadSceneAsync("Main Game"));
        }
    }
}
