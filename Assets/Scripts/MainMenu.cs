using System.Dynamic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject LvlButtons;
    public Button LvlButton, Audio;
    public Text ScoreTxt;
    public Sprite[] ImageArr;
    public static float s_Score;
    public static int s_Money = 10;
    public static bool s_Casino;
    public static int s_LvlToLoad;
    public void StartGame(int value)
    {
        s_LvlToLoad = value;
        SceneManager.LoadScene(1);
    }
    public void Town(bool casino)
    {
        s_Casino = casino;
        SceneManager.LoadScene(2);
    }
    private void Start()
    {
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            Audio.GetComponent<Image>().sprite = ImageArr[0];
        }
        else
        {
            Audio.GetComponent<Image>().sprite = ImageArr[1];
        }
        int nameLvl = 1;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Button but = Instantiate(LvlButton, new Vector2(-300 + (200 * j), 330 - (200 * i)),
                    Quaternion.identity);
                but.gameObject.transform.SetParent(LvlButtons.transform, false);
                but.name = nameLvl.ToString();
                but.onClick.AddListener(delegate { StartGame(System.Convert.ToInt32(but.name)); });
                Text txt = but.GetComponentInChildren<Text>();
                if (PlayerPrefs.HasKey(nameLvl.ToString()))
                {
                    txt.text = $"{nameLvl}\n\n{PlayerPrefs.GetFloat(nameLvl.ToString()):f3}";
                }
                else
                {
                    if (nameLvl == 1 || PlayerPrefs.HasKey((nameLvl - 1).ToString()))
                    {
                        txt.text = $"{nameLvl}\n\n";
                    }
                    else
                    {
                        txt.text = $"{nameLvl}\n\n";
                        but.interactable = false;
                    }
                }
                nameLvl++;
            }
        }
        try
        {
            s_Score = PlayerPrefs.GetFloat("Score");
            s_Money = PlayerPrefs.GetInt("Money");
        }
        catch { }
        if (!s_Score.Equals(0))
        {
            ScoreTxt.text = $"Best:{s_Score}";
        }
    }
    public void Mute()
    {
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            Audio.GetComponent<Image>().sprite = ImageArr[1];
            PlayerPrefs.SetInt("Music", 1);
        }
        else
        {
            Audio.GetComponent<Image>().sprite = ImageArr[0];
            PlayerPrefs.SetInt("Music", 0);
        }
    }
}
