using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource buttonSource;
    public AudioSource blowupSource;
    public AudioSource cashSource;
    public AudioSource completeSource;
    public AudioSource objecthitSource;

    public AudioClip buttonclip;
    public AudioClip blowupclip;
    public AudioClip cashclip;
    public AudioClip completeclip;
    public AudioClip objecthitclip;

    public void ButtonSound()
    {
        buttonSource.PlayOneShot(buttonclip);
    }

    public void BlowUpSound()
    {
        blowupSource.PlayOneShot(blowupclip,0.3f);
    }

    public void CashSound()
    {
        cashSource.PlayOneShot(cashclip);
    }

    public void CompleteSound()
    {
        completeSource.PlayOneShot(completeclip);
    }

    public void ObjectHitSound()
    {
        objecthitSource.PlayOneShot(objecthitclip);
    }
}
