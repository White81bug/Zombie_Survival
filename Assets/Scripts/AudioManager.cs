using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource ShotSound;
    [SerializeField] private AudioSource PlayerGetHitSound;
    [SerializeField] private AudioSource ReloadSound;
    [SerializeField] private AudioSource ZombieDieSound;

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
