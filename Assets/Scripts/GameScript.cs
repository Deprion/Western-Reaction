using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public Text text;
    public GameObject infoPanel, Sun, Cowboy, Next, Again;
    public Button ShootBtn;
    private bool win, canClick = false;
    private bool onceCalled = true;
    private float delay, countPlayerDelay, reverseDelay = 0.0f;
    private int reward = 0;
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void Start()
    {
        LoadLevel(MainMenu.s_LvlToLoad);
    }
    private void LoadLevel(int value)
    {
        Sun.GetComponent<RectTransform>().anchoredPosition = RandomPos();
        win = false;
        canClick = false;
        onceCalled = true;
        ShootBtn.GetComponent<BoxCollider2D>().enabled = true;
        text.text = "Prepare";
        delay = Random.Range(2.0f, 5.0f);
        if (value > 0 && value < 5)
        {
            reverseDelay = Random.Range(0.7f, 0.9f) + MainMenu.s_AdditionalDelay;
        }
        else if (value > 4 && value < 9)
        {
            reverseDelay = Random.Range(0.4f, 0.6f) + MainMenu.s_AdditionalDelay;
            if (ChanceForMoney(65 - MainMenu.s_AddtitionalChance))
            {
                reward = 4;
            }
        }
        else if (value > 8 && value < 13)
        {
            reverseDelay = Random.Range(0.2f, 0.35f) + MainMenu.s_AdditionalDelay;
            if (ChanceForMoney(60 - MainMenu.s_AddtitionalChance))
            {
                reward = 6;
            }
        }
        else if (value > 12)
        {
            reverseDelay = Random.Range(0.05f, 0.2f) + MainMenu.s_AdditionalDelay;
            if (ChanceForMoney(50 - MainMenu.s_AddtitionalChance))
            {
                reward = 8;
            }
        }
        else if (value == -1)
        {
            reverseDelay = Random.Range(0.8f, 1.2f) + MainMenu.s_AdditionalDelay;
        }
        else if (value == -2)
        {
            reverseDelay = Random.Range(0.35f, 0.75f) + MainMenu.s_AdditionalDelay;
            if (ChanceForMoney(65 - MainMenu.s_AddtitionalChance))
            {
                reward = 2;
            }
        }
        else if (value == -3)
        {
            reverseDelay = Random.Range(0.15f, 0.35f) + MainMenu.s_AdditionalDelay;
            if (ChanceForMoney(60 - MainMenu.s_AddtitionalChance)) 
            {
                reward = Random.Range(3, 6);
            }
        }
        else if (value == -4)
        {
            reverseDelay = Random.Range(0.03f, 0.125f) + MainMenu.s_AdditionalDelay;
            if (ChanceForMoney(40 - MainMenu.s_AddtitionalChance))
            {
                reward = Random.Range(6, 11);
            }
        }
    }
    private void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0 && onceCalled)
        {
            text.text = "Shoot";
            onceCalled = false;
            canClick = true;
        }
        if (delay <= 0)
        {
            Cowboy.GetComponent<Animator>().SetBool("Stand", true);
            countPlayerDelay += Time.deltaTime;
            reverseDelay -= Time.deltaTime;
            if (reverseDelay <= 0 && !win)
            {
                ShootBtn.GetComponent<BoxCollider2D>().enabled = false;
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
    public void Shoot()
    {
        if (canClick)
        {
            win = true;
            TheEnd();
        }
        else
        {
            TheEnd();
        }
    }
    private void TheEnd()
    {
        ShootBtn.GetComponent<BoxCollider2D>().enabled = false;
        if (win)
        {
            infoPanel.SetActive(true);
            if (MainMenu.s_LvlToLoad > 0 && MainMenu.s_LvlToLoad < 16)
            {
                Next.SetActive(true);
                Again.SetActive(false);
            }
            if (PlayerPrefs.HasKey(MainMenu.s_LvlToLoad.ToString()) || MainMenu.s_LvlToLoad < 0)
            {
                infoPanel.GetComponentInChildren<Text>().text = $"You Won\nYour Delay:{countPlayerDelay}" +
                    $"\nYou Found:{reward}$";
                MainMenu.s_Money += reward;
            }
            else
            {
                infoPanel.GetComponentInChildren<Text>().text = $"You Won\nYour Delay:{countPlayerDelay}" +
                    $"\nYou Found:{reward}$\nYour Reward:8$";
                MainMenu.s_Money += reward + 8;
            }
            if (PlayerPrefs.GetFloat(MainMenu.s_LvlToLoad.ToString()) > countPlayerDelay ||
                PlayerPrefs.GetFloat(MainMenu.s_LvlToLoad.ToString()) == 0)
            {
                PlayerPrefs.SetFloat(MainMenu.s_LvlToLoad.ToString(), countPlayerDelay);
            }
            if (MainMenu.s_Score > countPlayerDelay || MainMenu.s_Score == 0)
            {
                MainMenu.s_Score = countPlayerDelay;
                Save();
            }
            PlayerPrefs.SetInt("Money", MainMenu.s_Money);
        }
        else
        {
            infoPanel.SetActive(true);
            infoPanel.GetComponentInChildren<Text>().text = "You lost";
        }
    }
    public void Refresh(bool NextLvl)
    {
        Next.SetActive(false);
        Again.SetActive(true);
        countPlayerDelay = 0.0f;
        Cowboy.GetComponent<Animator>().SetBool("Stand", false);
        infoPanel.SetActive(false);
        if (NextLvl)
        {
            LoadLevel(MainMenu.s_LvlToLoad += 1);
        }
        else
        {
            LoadLevel(MainMenu.s_LvlToLoad);
        }
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("Score", MainMenu.s_Score);
    }
}
