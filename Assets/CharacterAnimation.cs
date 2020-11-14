using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{

    private Animator anim;
    public ParticleSystem hitParticle;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //CharacterHit();
        }
    }

    public void CharacterHit()
    {
        SetAnimatorTrigger("hit");
    }

    public void SetAnimatorTrigger(string trigger)
    {
        anim.SetTrigger(trigger);
    }

    public void PlayParticle()
    {
        hitParticle.Play();
    }
}
