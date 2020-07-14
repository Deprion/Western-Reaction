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
    private float Delay, CountPlayerDelay, ReverseDelay = 1;
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void Start()
    {
        Shoot.interactable = true;
        Image.SetActive(true);
        infoPanel.SetActive(false);
        Win = false;
        CanClick = false;
        OnceCalled = true;
        CountPlayerDelay = 0.0f;
        text.text = "Prepare";
        Delay = Random.Range(2.0f, 5.0f);
        ReverseDelay = Random.Range(0.5f, 1.0f);
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
                Shoot.interactable = false;
                Image.SetActive(false);
                infoPanel.SetActive(true);
                infoPanel.GetComponentInChildren<Text>().text = "U lose";
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
        Image.SetActive(false);
        Shoot.interactable = false;
        if (Win)
        {
            infoPanel.SetActive(true);
            infoPanel.GetComponentInChildren<Text>().text = $"U Win + Delay:{CountPlayerDelay}";
            if (MainMenu.Score > CountPlayerDelay || MainMenu.Score == 0)
            {
                MainMenu.Score = CountPlayerDelay;
                Save();
            }
        }
        else
        {
            infoPanel.SetActive(true);
            infoPanel.GetComponentInChildren<Text>().text = "U Lose";
        }
    }
    public void Refresh()
    {
        Shoot.interactable = true;
        Image.SetActive(true);
        infoPanel.SetActive(false);
        Win = false;
        CanClick = false;
        OnceCalled = true;
        CountPlayerDelay = 0.0f;
        text.text = "Prepare";
        Delay = Random.Range(2.0f, 5.0f);
        ReverseDelay = Random.Range(1.0f, 2.0f);
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("Score", MainMenu.Score);
    }
}
