using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Town : MonoBehaviour
{
    public GameObject casinoObj, shopObj;
    public Text CurrentMoney;
    private void Start()
    {
        if (MainMenu.s_Casino)
        {
            casinoObj.SetActive(true);
            CurrentMoney.text = $"Balance: {MainMenu.s_Money}";
        }
        else
        {
            shopObj.SetActive(true);
        }
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
