using UnityEngine;
using UnityEngine.SceneManagement;

public class Town : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
