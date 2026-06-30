using System;
using UnityEngine;
using static Weapon;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }

    public AudioSource ShottingChannel;
    

    public AudioClip P1911Shot;
    public AudioClip M16Shot;

    
    public AudioSource reloadingSoundM16;
    public AudioSource reloadingSound1911;

    public AudioSource emptymagazineSound1911;

    public AudioSource thrwoablesChannel;
    public AudioClip grenadeSound;

    public AudioClip zombieWalking;
    public AudioClip zombieChase;
    public AudioClip zombieAttack;
    public AudioClip zombieHurt;
    public AudioClip zombieDeath;

    public AudioSource zombieChannel;

    public AudioSource playerChannel;
    public AudioClip  playerHurt;
    public AudioClip  playerDie;

    public AudioClip gameOverMusic;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlayShootingSound(WeaponModel weapon)
    {
        switch(weapon)
        {
            case WeaponModel.Pistol1911:
                ShottingChannel.PlayOneShot(P1911Shot);
                break;
            case WeaponModel.M16:
                ShottingChannel.PlayOneShot(M16Shot);
                break;
        }
    }

    public void PlayReloadSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.Pistol1911:
                reloadingSound1911.Play();
                break;
            case WeaponModel.M16:
                reloadingSoundM16.Play();
                break;
        }
    }

    internal void PlayEmptyMagazineSound()
    {
        throw new NotImplementedException();
    }
}
