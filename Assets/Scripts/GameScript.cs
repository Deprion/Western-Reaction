using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public Text text;
    public GameObject infoPanel, Image;
    public Button Shoot;
    private bool Win, CanClick = false;
    private bool OnceCalled = true;
    private float Delay, CountPlayerDelay, ReverseDelay = 0.0f;
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
        Win = false;
        CanClick = false;
        OnceCalled = true;
        Shoot.GetComponent<Button>().enabled = true;
        text.text = "Prepare";
        Delay = Random.Range(2.0f, 5.0f);
        if (value > 0 && value < 5)
        {
            ReverseDelay = Random.Range(0.7f, 0.9f);
        }
        else if (value > 4 && value < 9)
        {
            ReverseDelay = Random.Range(0.4f, 0.6f);
        }
        else if (value > 8 && value < 13)
        {
            ReverseDelay = Random.Range(0.2f, 0.35f);
        }
        else if (value > 12)
        {
            ReverseDelay = Random.Range(0.05f, 0.2f);
        }
        else if (value == -1)
        {
            ReverseDelay = Random.Range(0.8f, 1.2f);
        }
        else if (value == -2)
        {
            ReverseDelay = Random.Range(0.35f, 0.75f);
        }
        else if (value == -3)
        {
            ReverseDelay = Random.Range(0.15f, 0.35f);
        }
        else if (value == -4)
        {
            ReverseDelay = Random.Range(0.03f, 0.125f);
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
            infoPanel.GetComponentInChildren<Text>().text = $"You Won\n Your Delay:{CountPlayerDelay}";
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
        infoPanel.SetActive(false);
        LoadLevel(MainMenu.s_LvlToLoad);
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("Score", MainMenu.s_Score);
    }
}
