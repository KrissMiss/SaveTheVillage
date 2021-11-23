using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSound : MonoBehaviour
{
    private AudioSource backgroundSound;
    public GameObject soundOff;
    public GameObject soundOn;
    void Start()
    {
        backgroundSound = GetComponent<AudioSource>();
        backgroundSound.Play();
    }


    private void Update()
    {
        if (Time.timeScale == 0)
        {
            backgroundSound.volume = 0;
        }
        else if (Time.timeScale != 0)
        {
            backgroundSound.volume = 0.1f;
        }
    }
    public void SoundOff()
    {
        backgroundSound.mute = true;
        soundOff.SetActive(true);
        soundOn.SetActive(false);
    }

    public void SoundOn()
    {
        backgroundSound.mute = false;
        soundOff.SetActive(false);
        soundOn.SetActive(true);
    }

}
