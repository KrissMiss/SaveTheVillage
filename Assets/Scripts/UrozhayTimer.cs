using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UrozhayTimer : MonoBehaviour
{
    public float maxTime;
    public bool tick;

    private Image img;
    private float currentTime;

    public GameObject soundOff;

    private AudioSource getUrozhaySound;
    void Start()
    {
        getUrozhaySound = GetComponent<AudioSource>();
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
            getUrozhaySound.Play();
        }

        img.fillAmount = currentTime / maxTime;
    }

    public void SoundOff()
    {
        getUrozhaySound.mute = true;
    }

    public void SoundOn()
    {
        getUrozhaySound.mute = false;
        soundOff.SetActive(false);
    }
}
