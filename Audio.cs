using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip death;

    public void DeathSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = death;
        audio.Play();
    }
}
