using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UrozhayTimer urozhayTimer;
    public EatingTimer eatingTimer;
    public Image vragTimerImage;
    public Image krestTimerImage;
    public Image warriorTimerImage;

    public GameObject gameOverScreen;

    public Button krestButton;
    public Button warriorButton;

    public Text resourcesText;

    public int krestCount;
    public int warriorCount;
    public int pshenitzaCount;

    public int psenitzaPerKrest;
    public int pshenitzaForWarrior;

    public int krestCost;
    public int warriorCost;

    public float krestCreateTime;
    public float warriorCreateTime;
    public float vragMaxTime;
    public int vragUvelich;
    public int nextVrag;

    private float krestTimer = -2;
    public float warriorTimer = -2;
    private float vragTimer;

    public GameObject pausePanel;

    public GameObject WinPanel;

    public Text loseStat;


    void Start()
    {
        UpdateText();
        vragTimer = vragMaxTime;
    }

    public void Again()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    void Update()
    {
        vragTimer -= Time.deltaTime;
        vragTimerImage.fillAmount = vragTimer / vragMaxTime;
        if (vragTimer <= 0)
        {
            vragMaxTime += (vragMaxTime / nextVrag);
            vragTimer = vragMaxTime;
            warriorCount -= nextVrag;
            nextVrag += vragUvelich;
        }
        if (urozhayTimer.tick)
        {
            pshenitzaCount += krestCount * psenitzaPerKrest * vragUvelich;
        }
        if (eatingTimer.tick)
        {
            pshenitzaCount -= warriorCount * pshenitzaForWarrior * nextVrag;
        }
        UpdateText();

        if (krestTimer > 0)
        {
            krestTimer -= Time.deltaTime;
            krestTimerImage.fillAmount = krestTimer / krestCreateTime;
        }
        else if (krestTimer > -1 && (pshenitzaCount - krestCost) >= 0)
        {
            krestTimerImage.fillAmount = 1;
            krestButton.interactable = true;
            krestCount++;
            krestTimer = -2;
        }

        if (warriorTimer > 0)
        {
            warriorTimer -= Time.deltaTime;
            warriorTimerImage.fillAmount = warriorTimer / warriorCreateTime;
        }
        else if (warriorTimer > -1 && (pshenitzaCount - warriorCost) >= 0)
        {
            warriorTimerImage.fillAmount = 1;
            warriorButton.interactable = true;
            warriorCount++;
            warriorTimer = -2;
        }

        if (warriorCount < 0)
        {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
            loseStat.text = "During the game, you: \n hired " + krestCount + " peasants and gathered " + pshenitzaCount + " kilogram of grain. \n Impressive results, my friend!" +
                "\n Try again Save the village!";
        }

        if(pshenitzaCount >= 500)
        {
            WinPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    
    public void CreateKrest()
    {
        pshenitzaCount -= krestCost;
        krestTimer = krestCreateTime;
        krestButton.interactable = false;
    }

    public void CreateWarior()
    {
        pshenitzaCount -= warriorCost;
        warriorTimer = warriorCreateTime;
        warriorButton.interactable = false;
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ContinueGameButton()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    private void UpdateText()
    {
        resourcesText.text = krestCount + "\n" + warriorCount + "\n\n" + pshenitzaCount + "\n\n" + nextVrag;
    }
}
