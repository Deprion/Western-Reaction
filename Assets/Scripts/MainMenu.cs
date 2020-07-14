using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text Scoretxt;
    public static float Score;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    private void Start()
    {
        try
        {
            Score = PlayerPrefs.GetFloat("Score");
        }
        catch { }
        if (!Score.Equals(0))
        {

            Scoretxt.text = $"Best:{Score}";
        }
    }
}
