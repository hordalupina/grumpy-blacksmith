using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NoteHandler : MonoBehaviour
{
    NoteObject noteObject;
    public Transform visualObject;
    SpriteRenderer sprite;

    [Header("Effects")]
    public ParticleSystem hitParticle;

    void Awake()
    {
        noteObject = GetComponent<NoteObject>();

        noteObject.Hit.AddListener((x) => Hit(x));

        sprite = GetComponentInChildren<SpriteRenderer>();

    }

    void OnDestroy()
    {
        noteObject.Hit.RemoveListener(Hit);
    }

    void Hit(KeyCode key)
    {

        if (key == KeyCode.UpArrow)
        {
            GameManager.instance.sfxPlayer.PlayOneShot(GameManager.instance.sounds.forgeUp);
        }

        if (key == KeyCode.DownArrow)
        {
            GameManager.instance.sfxPlayer.PlayOneShot(GameManager.instance.sounds.forgeDown);
        }


        if (key == KeyCode.RightArrow)
        {
            GameManager.instance.sfxPlayer.PlayOneShot(GameManager.instance.sounds.forgeRight);
        }


        if (key == KeyCode.LeftArrow)
        {
            GameManager.instance.sfxPlayer.PlayOneShot(GameManager.instance.sounds.forgeLeft);
        }

        StartCoroutine(DelayEffects(.1f));
        hitParticle.Play();
        visualObject.DOPunchScale(Vector3.one / 2, .2f, 10, 1);
        FindObjectOfType<CharacterAnimation>().CharacterHit();
        sprite.DOFade(0, .6f);

        IEnumerator DelayEffects(float delay)
        {
            yield return new WaitForSeconds(delay);
            GameManager.instance.forgePlayer.Play();
            //camerashake
            Camera.main.transform.DOComplete();
            Camera.main.transform.DOShakePosition(.2f, .05f, 10, 90, false, true);
        }

    }
}
