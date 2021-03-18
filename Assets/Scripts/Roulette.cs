using UnityEngine;
using UnityEngine.UI;
using System;

public class Roulette : MonoBehaviour
{
    public Text CurrentMoney;
    public InputField CurrentBetText;
    public GameObject RouletteHolderObj;
    public bool isStoped = true;
    public int currentBet = 10;
    private RouletteHolder rouletteHolder;
    private void Start()
    {
        rouletteHolder = RouletteHolderObj.GetComponent<RouletteHolder>();
    }
    public void Roll(string Color)
    {
        if (currentBet <= MainMenu.s_Money && currentBet >= 10 && isStoped)
        {
            MainMenu.s_Money -= currentBet;
            PlayerPrefs.SetInt("Money", MainMenu.s_Money);
            CurrentMoney.text = $"Balance: {MainMenu.s_Money}";
            StartCoroutine(rouletteHolder.roll(Color));
        }
    }
    public void ChangeBet(InputField field)
    {
        int temp = Convert.ToInt32(field.text);
        if (temp > 10)
        {
            currentBet = temp;
            CurrentBetText.text = currentBet.ToString();
        }
        else
        {
            currentBet = 10;
            CurrentBetText.text = currentBet.ToString();
        }
    }
    public void ChangeBet(int amount)
    {
        int temp = currentBet + amount;
        if (temp > 10)
        {
            currentBet += amount;
            CurrentBetText.text = currentBet.ToString();
        }
        else
        {
            currentBet = 10;
            CurrentBetText.text = currentBet.ToString();
        }
    }
    public void ChangeBetMinMax(bool Max)
    {
        if (Max == true)
        {
            if (MainMenu.s_Money >= 10)
            {
                currentBet = MainMenu.s_Money;
                CurrentBetText.text = currentBet.ToString();
            }
            else
            {
                currentBet = 10;
                CurrentBetText.text = currentBet.ToString();
            }
        }
        else
        {
            currentBet = 10;
            CurrentBetText.text = currentBet.ToString();
        }
    }
}
