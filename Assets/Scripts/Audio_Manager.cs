using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    [SerializeField] AudioSource SFXSource;

    public AudioClip explosion;

    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }
}

