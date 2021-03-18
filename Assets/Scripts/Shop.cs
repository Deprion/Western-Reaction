using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Button[] ButtonShop;
    public Button[] ButtonUpgrade;
    public Text CurrentMoney;
    void Start()
    {
        for (int i = 0; i < MainMenu.s_Ranch.Length; i++)
        {
            if (MainMenu.s_Ranch[i] == true)
            {
                ButtonShop[i].interactable = false;
            }
            if (MainMenu.s_Upgrades[i] == true)
            {
                ButtonUpgrade[i].interactable = false;
            }
        }
        if (!MainMenu.s_Ranch[0])
        {
            ButtonShop[1].interactable = false;
            ButtonShop[2].interactable = false;
        }
        if (!MainMenu.s_Ranch[2])
        {
            ButtonShop[3].interactable = false;
        }
        if (!MainMenu.s_Upgrades[2])
        {
            ButtonUpgrade[3].interactable = false;
        }
    }
    public void BuyStuffFromRanch(int num)
    {
        if (num == 0 && MainMenu.s_Money >= 150)
        {
            MainMenu.s_Ranch[0] = true;
            MainMenu.s_Money -= 150;
            ButtonShop[0].interactable = false;
        }
        else if (num == 1 && MainMenu.s_Money >= 40)
        {
            MainMenu.s_Ranch[1] = true;
            MainMenu.s_Money -= 40;
            ButtonShop[1].interactable = false;
        }
        else if (num == 2 && MainMenu.s_Money >= 90)
        {
            MainMenu.s_Ranch[2] = true;
            MainMenu.s_Money -= 90;
            ButtonShop[2].interactable = false;
            ButtonShop[3].interactable = true;
        }
        else if (num == 3 && MainMenu.s_Money >= 125)
        {
            MainMenu.s_Ranch[3] = true;
            MainMenu.s_Money -= 125;
            ButtonShop[3].interactable = false;
        }
        CurrentMoney.text = $"Balance: {MainMenu.s_Money}";
        PlayerPrefs.SetInt("Money", MainMenu.s_Money);
        DataScript.SaveData();
        Start();
    }
    public void BuyUpgrade(int num)
    {
        if (num == 0 && MainMenu.s_Money >= 175)
        {
            MainMenu.s_Upgrades[0] = true;
            MainMenu.s_Money -= 175;
            ButtonUpgrade[0].interactable = false;
            MainMenu.s_AdditionalDelay += 0.05f;
            PlayerPrefs.SetFloat("Delay", MainMenu.s_AdditionalDelay);
        }
        else if (num == 1 && MainMenu.s_Money >= 175)
        {
            MainMenu.s_Upgrades[1] = true;
            MainMenu.s_Money -= 175;
            ButtonUpgrade[1].interactable = false;
            MainMenu.s_AdditionalDelay += 0.05f;
            PlayerPrefs.SetFloat("Delay", MainMenu.s_AdditionalDelay);
        }
        else if (num == 2 && MainMenu.s_Money >= 75)
        {
            MainMenu.s_Upgrades[2] = true;
            MainMenu.s_Money -= 75;
            ButtonUpgrade[2].interactable = false;
            MainMenu.s_AddtitionalChance += 5;
            PlayerPrefs.SetInt("Chance", MainMenu.s_AddtitionalChance);
            ButtonUpgrade[3].interactable = true;
        }
        else if (num == 3 && MainMenu.s_Money >= 150)
        {
            MainMenu.s_Upgrades[3] = true;
            MainMenu.s_Money -= 150;
            ButtonUpgrade[3].interactable = false;
            MainMenu.s_AddtitionalChance += 10;
            PlayerPrefs.SetInt("Chance", MainMenu.s_AddtitionalChance);
        }
        CurrentMoney.text = $"Balance: {MainMenu.s_Money}";
        PlayerPrefs.SetInt("Money", MainMenu.s_Money);
        DataScript.SaveData();
        Start();
    }
}
