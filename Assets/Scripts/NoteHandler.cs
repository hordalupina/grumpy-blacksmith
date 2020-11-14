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

    void OnDestroy() {
        noteObject.Hit.RemoveListener(Hit);
    }

    void Hit(int dir)
    {
        GameManager.instance.sfxPlayer.pitch = Random.Range(1f, 1.15f);
        StartCoroutine(DelayEffects(.1f));
        hitParticle.Play();
        visualObject.DOPunchScale(Vector3.one/2, .2f, 10, 1);
        FindObjectOfType<CharacterAnimation>().CharacterHit();

        IEnumerator DelayEffects(float delay)
        {
            yield return new WaitForSeconds(delay);
            GameManager.instance.sfxPlayer.PlayOneShot(GameManager.instance.sounds.forge);
        }
    }
}
