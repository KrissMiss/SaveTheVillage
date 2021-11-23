using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatingTimer : MonoBehaviour
{
    public float maxTime;
    public bool tick;

    public GameObject soundOff;
    private Image img;
    private float currentTime;

    private AudioSource eatingSound;
    void Start()
    {
        eatingSound = GetComponent<AudioSource>();
        img = GetComponent<Image>();
        currentTime = maxTime;
    }

    void Update()
    {
        tick = false;
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            tick = true;
            currentTime = maxTime;
            eatingSound.Play();
        }

        img.fillAmount = currentTime / maxTime;
    }

    public void SoundOff()
    {
        eatingSound.mute = true;
    }

    public void SoundOn()
    {
        eatingSound.mute = false;
        soundOff.SetActive(false);
    }
}
