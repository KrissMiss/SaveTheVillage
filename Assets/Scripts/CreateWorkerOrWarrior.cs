using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateWorkerOrWarrior : MonoBehaviour
{
    public GameObject soundOff;
    public Image image;
    private AudioSource buttonClick;
    private void Start()
    {
        buttonClick = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (image.fillAmount == 0)
        {
            buttonClick.Play();
        }
    }

    public void SoundOn()
    {
        buttonClick.mute = false;
        soundOff.SetActive(false);
    }

    public void SoundOff()
    {
        buttonClick.mute = true;
        soundOff.SetActive(true);
    }
}
