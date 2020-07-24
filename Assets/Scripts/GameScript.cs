﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public Text text;
    public GameObject infoPanel, Sun, Cowboy;
    public Button Shoot;
    private bool Win, CanClick = false;
    private bool OnceCalled = true;
    private float Delay, CountPlayerDelay, ReverseDelay = 0.0f;
    private int reward = 0;
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void Start()
    {
        LoadLevel(MainMenu.s_LvlToLoad);
        Sun.GetComponent<RectTransform>().anchoredPosition = RandomPos();
    }
    private void LoadLevel(int value)
    {
        Win = false;
        CanClick = false;
        OnceCalled = true;
        Shoot.GetComponent<Button>().enabled = true;
        text.text = "Prepare";
        Delay = Random.Range(2.0f, 5.0f);
        if (value > 0 && value < 5)
        {
            ReverseDelay = Random.Range(0.7f, 0.9f) + MainMenu.s_AdditionalDelay;
        }
        else if (value > 4 && value < 9)
        {
            ReverseDelay = Random.Range(0.4f, 0.6f) + MainMenu.s_AdditionalDelay;
            if (ChanceForMoney(65 - MainMenu.s_AddtitionalChance))
            {
                reward = 4;
            }
        }
        else if (value > 8 && value < 13)
        {
            ReverseDelay = Random.Range(0.2f, 0.35f) + MainMenu.s_AdditionalDelay;
            if (ChanceForMoney(75 - MainMenu.s_AddtitionalChance))
            {
                reward = 6;
            }
        }
        else if (value > 12)
        {
            ReverseDelay = Random.Range(0.05f, 0.2f) + MainMenu.s_AdditionalDelay;
            if (ChanceForMoney(80 - MainMenu.s_AddtitionalChance))
            {
                reward = 8;
            }
        }
        else if (value == -1)
        {
            ReverseDelay = Random.Range(0.8f, 1.2f) + MainMenu.s_AdditionalDelay;
        }
        else if (value == -2)
        {
            ReverseDelay = Random.Range(0.35f, 0.75f) + MainMenu.s_AdditionalDelay;
            if (ChanceForMoney(65 - MainMenu.s_AddtitionalChance))
            {
                reward = 2;
            }
        }
        else if (value == -3)
        {
            ReverseDelay = Random.Range(0.15f, 0.35f) + MainMenu.s_AdditionalDelay;
            if (ChanceForMoney(75 - MainMenu.s_AddtitionalChance)) 
            {
                reward = Random.Range(3, 6);
            }
        }
        else if (value == -4)
        {
            ReverseDelay = Random.Range(0.03f, 0.125f) + MainMenu.s_AdditionalDelay;
            if (ChanceForMoney(80 - MainMenu.s_AddtitionalChance))
            {
                reward = Random.Range(6, 11);
            }
        }
    }
    private void Update()
    {
        Delay -= Time.deltaTime;
        if (Delay <= 0 && OnceCalled)
        {
            text.text = "Shoot";
            OnceCalled = false;
            CanClick = true;
        }
        if (Delay <= 0)
        {
            Cowboy.GetComponent<Animator>().SetBool("Stand", true);
            CountPlayerDelay += Time.deltaTime;
            ReverseDelay -= Time.deltaTime;
            if (ReverseDelay <= 0 && !Win)
            {
                Shoot.GetComponent<Button>().enabled = false;
                infoPanel.SetActive(true);
                infoPanel.GetComponentInChildren<Text>().text = "You lost";
            }
        }
    }
    public bool ChanceForMoney(int val)
    {
        if (Random.Range(0, 101) > val)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public Vector2 RandomPos()
    {
        int x = Random.Range(0, 3);
        if (x == 0)
        {
            return new Vector2(-240, 800);
        }
        else if (x == 1)
        {
            return new Vector2(0, 790);
        }
        else
        {
            return new Vector2(380, 550);
        }
    }
    public void Click()
    {
        if (CanClick)
        {
            Win = true;
            TheEnd();
        }
        else
        {
            TheEnd();
        }
    }
    private void TheEnd()
    {
        Shoot.GetComponent<Button>().enabled = false;
        if (Win)
        {
            infoPanel.SetActive(true);
            infoPanel.GetComponentInChildren<Text>().text = $"You Won\nYour Delay:{CountPlayerDelay}" +
                $"\nYou Found:{reward}$";
            if (PlayerPrefs.GetFloat(MainMenu.s_LvlToLoad.ToString()) > CountPlayerDelay ||
                PlayerPrefs.GetFloat(MainMenu.s_LvlToLoad.ToString()) == 0)
            {
                PlayerPrefs.SetFloat(MainMenu.s_LvlToLoad.ToString(), CountPlayerDelay);
            }
            if (MainMenu.s_Score > CountPlayerDelay || MainMenu.s_Score == 0)
            {
                MainMenu.s_Score = CountPlayerDelay;
                Save();
            }
            MainMenu.s_Money += reward;
            PlayerPrefs.SetInt("Money", MainMenu.s_Money);
        }
        else
        {
            infoPanel.SetActive(true);
            infoPanel.GetComponentInChildren<Text>().text = "You Lost";
        }
    }
    public void Refresh()
    {
        CountPlayerDelay = 0.0f;
        Cowboy.GetComponent<Animator>().SetBool("Stand", false);
        infoPanel.SetActive(false);
        LoadLevel(MainMenu.s_LvlToLoad);
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("Score", MainMenu.s_Score);
    }
}
