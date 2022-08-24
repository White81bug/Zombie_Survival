using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource ShotSound;
    public AudioSource PlayerGetHitSound;
    public AudioSource ReloadSound;
    public AudioSource ZombieDieSound;

    public void PlayShotSound()
    {
        ShotSound.Play();
    }
    public void PlayPlayerHitSound()
    {
        PlayerGetHitSound.Play();
    }
    public void PlayReloadSound()
    {
        ReloadSound.Play();
    }
    public void PlayZombieDieSound()
    {
        ZombieDieSound.Play();
    }
}
