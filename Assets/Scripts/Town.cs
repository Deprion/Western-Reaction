using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Town : MonoBehaviour
{
    public GameObject casinoObj, shopObj;
    public Text CurrentMoney;
    private void Start()
    {
        CurrentMoney.text = $"Balance: {MainMenu.s_Money}";
        if (MainMenu.s_Casino)
        {
            casinoObj.SetActive(true);
            shopObj.SetActive(false);
        }
        else
        {
            shopObj.SetActive(true);
            casinoObj.SetActive(false);
        }
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
