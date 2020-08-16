using System.Linq;
using System.Collections;
using UnityEngine;

public class RouletteHolder : MonoBehaviour
{
    public GameObject GameManager;
    private Roulette roulette;
    private int[] redNum = new int[] { 1, 3, 5, 7, 9, 11, 13, 15, 17 };
    private int currentNum;
    private void Start()
    {
        roulette = GameManager.GetComponent<Roulette>();
    }
    public IEnumerator roll(string Color)
    {
        roulette.isStoped = false;
        float timeInterval = 0.015f;
        for (int i = 0; i < Random.Range(250, 751); i++)
        {
            if (transform.localPosition.x <= -2059f)
                transform.localPosition = new Vector2(-237f, transform.localPosition.y);
            transform.localPosition = new Vector2(transform.localPosition.x - 5f, transform.localPosition.y);
            yield return new WaitForSeconds(timeInterval);
        }
        int randomValue = Random.Range(60, 100);
        for (int i = 0; i < randomValue; i++)
        {
            if (transform.localPosition.x <= -2059f)
                transform.localPosition = new Vector2(-237f, transform.localPosition.y);
            transform.localPosition = new Vector2(transform.localPosition.x - 5f, transform.localPosition.y);
            if (i > Mathf.RoundToInt(randomValue * 0.25f))
                timeInterval = 0.05f;
            if (i > Mathf.RoundToInt(randomValue * 0.5f))
                timeInterval = 0.1f;
            if (i > Mathf.RoundToInt(randomValue * 0.75f))
                timeInterval = 0.15f;
            if (i > Mathf.RoundToInt(randomValue * 0.95f))
                timeInterval = 0.2f;
            yield return new WaitForSeconds(timeInterval);
        }
        if (transform.localPosition.x <= -237 && transform.localPosition.x >= -286)
            currentNum = 17;
        else if (transform.localPosition.x <= -287 && transform.localPosition.x >= -382)
            currentNum = 18;
        else if (transform.localPosition.x <= -383 && transform.localPosition.x >= -478)
            currentNum = 0;
        else if (transform.localPosition.x <= -479 && transform.localPosition.x >= -574)
            currentNum = 1;
        else if (transform.localPosition.x <= -575 && transform.localPosition.x >= -670)
            currentNum = 2;
        else if (transform.localPosition.x <= -671 && transform.localPosition.x >= -766)
            currentNum = 3;
        else if (transform.localPosition.x <= -767 && transform.localPosition.x >= -862)
            currentNum = 4;
        else if (transform.localPosition.x <= -863 && transform.localPosition.x >= -958)
            currentNum = 5;
        else if (transform.localPosition.x <= -959 && transform.localPosition.x >= -1054)
            currentNum = 6;
        else if (transform.localPosition.x <= -1055 && transform.localPosition.x >= -1150)
            currentNum = 7;
        else if (transform.localPosition.x <= -1151 && transform.localPosition.x >= -1246)
            currentNum = 8;
        else if (transform.localPosition.x <= -1247 && transform.localPosition.x >= -1342)
            currentNum = 9;
        else if (transform.localPosition.x <= -1343 && transform.localPosition.x >= -1438)
            currentNum = 10;
        else if (transform.localPosition.x <= -1439 && transform.localPosition.x >= -1534)
            currentNum = 11;
        else if (transform.localPosition.x <= -1535 && transform.localPosition.x >= -1630)
            currentNum = 12;
        else if (transform.localPosition.x <= -1631 && transform.localPosition.x >= -1726)
            currentNum = 13;
        else if (transform.localPosition.x <= -1727 && transform.localPosition.x >= -1822)
            currentNum = 14;
        else if (transform.localPosition.x <= -1823 && transform.localPosition.x >= -1918)
            currentNum = 15;
        else if (transform.localPosition.x <= -1919 && transform.localPosition.x >= -2012)
            currentNum = 16;
        else if (transform.localPosition.x <= -2013 && transform.localPosition.x >= -2059)
            currentNum = 17;
        if (redNum.Contains(currentNum))
        {
            Result(Color, "Red");
        }
        else if (currentNum == 0)
        {
            Result(Color, "Green");
        }
        else
        {
            Result(Color, "Black");
        }
        roulette.isStoped = true;
    }
    private void Result(string ColorChoosed, string ColorDrop)
    {
        if (ColorChoosed.Equals(ColorDrop))
        {
            switch (ColorChoosed)
            {
                case "Red":
                    MainMenu.s_Money += roulette.currentBet * 2;
                    break;
                case "Green":
                    MainMenu.s_Money += roulette.currentBet * 13;
                    break;
                case "Black":
                    MainMenu.s_Money += roulette.currentBet * 2;
                    break;
            }
        }
        PlayerPrefs.SetInt("Money", MainMenu.s_Money);
        roulette.CurrentMoney.text = $"Balance: {MainMenu.s_Money}";
    }
}
