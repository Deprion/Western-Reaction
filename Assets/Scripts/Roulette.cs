using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Roulette : MonoBehaviour
{
    public Image CurrentRollObj;
    public Text CurrentRollText, CurrentMoney;
    public InputField CurrentBetText;
    private int[] redNum = new int[] { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
    private int currentBet = 10;
    public void Roll(string Color)
    {
        if (System.Convert.ToInt32(CurrentBetText.text) <= MainMenu.s_Money && currentBet >= 10)
        {
            MainMenu.s_Money -= currentBet;
            int currentNum = Random.Range(0, 37);
            CurrentRollText.text = currentNum.ToString();
            if (redNum.Contains(currentNum))
            {
                CurrentRollObj.color = new Color(200, 0, 0);
                Result(Color, "Red");
            }
            else if (currentNum == 0)
            {
                CurrentRollObj.color = new Color(0, 200, 0);
                Result(Color, "Green");
            }
            else
            {
                CurrentRollObj.color = new Color(0, 0, 0);
                Result(Color, "Black");
            }
        }
    }
    public void Result(string ColorChoosed, string ColorDrop)
    {
        if (ColorChoosed.Equals(ColorDrop))
        {
            switch (ColorChoosed)
            {
                case "Red":
                    MainMenu.s_Money += currentBet * 2;
                    break;
                case "Green":
                    MainMenu.s_Money += currentBet * 13;
                    break;
                case "Black":
                    MainMenu.s_Money += currentBet * 2;
                    break;
            }
        }
        PlayerPrefs.SetInt("Money", MainMenu.s_Money);
        CurrentMoney.text = $"Balance: {MainMenu.s_Money}";
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
