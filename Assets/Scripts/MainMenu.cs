using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject LvlButtons, Ranch;
    public Button LvlButton, Audio;
    public Text ScoreTxt, TextInfo;
    public Sprite[] ImageArr;
    public static float s_Score;
    public static int s_Money = 10;
    public static float s_AdditionalDelay;
    public static int s_AddtitionalChance;
    public static bool s_Casino;
    public static int s_LvlToLoad;
    public static bool[] s_Ranch = new bool[4];
    public static bool[] s_Upgrades = new bool[4];
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
    public void RanchScene()
    {
        SceneManager.LoadScene(3);
    }
    private void Start()
    {
        TextInfo.text += "\n" + SystemInfo.graphicsShaderLevel +  "\n" + SystemInfo.graphicsMemorySize;
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            Audio.GetComponent<Image>().sprite = ImageArr[0];
        }
        else
        {
            Audio.GetComponent<Image>().sprite = ImageArr[1];
        }
        if (s_Ranch[0] == true)
        {
            Ranch.SetActive(true);
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
            s_AdditionalDelay = PlayerPrefs.GetFloat("Delay");
            s_AddtitionalChance = PlayerPrefs.GetInt("Chance");
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
