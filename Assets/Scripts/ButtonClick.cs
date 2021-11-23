using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonClick : MonoBehaviour
{
    private AudioSource buttonClick;
    public GameObject soundOff;
    private void Start()
    {
        buttonClick = GetComponent<AudioSource>();
    }


    public void ClickToSound()
    {
        buttonClick.Play();
    }

    public void SoundOff()
    {
        buttonClick.mute = true;
    }

    public void SoundOn()
    {
        buttonClick.mute = false;
        soundOff.SetActive(false);
    }
}
