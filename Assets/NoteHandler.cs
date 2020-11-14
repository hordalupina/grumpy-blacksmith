using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NoteHandler : MonoBehaviour
{
    NoteObject noteObject;
    public Transform visualObject;

    [Header("Effects")]
    public ParticleSystem hitParticle;

    void Awake()
    {
        noteObject = GetComponent<NoteObject>();

        noteObject.Hit.AddListener((x) => Hit(x));

    }

    void Hit(int dir)
    {
        GameManager.instance.sfxPlayer.PlayOneShot(GameManager.instance.sounds.forge);
        hitParticle.Play();
        visualObject.DOPunchScale(Vector3.one * 5, .2f, 10, 1);
    }

}
