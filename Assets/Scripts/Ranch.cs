using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ranch : MonoBehaviour
{
    public GameObject Fence, Canvas, Tree, Cow;
    public Sprite TreeSprite;
    private Music MusicScript;
    private void Start()
    {
        MusicScript = GameObject.FindGameObjectWithTag("music").GetComponent<Music>();
        StartCoroutine(Moo());
        Fence.SetActive(true);
        if (MainMenu.s_Ranch[2] == true)
        {
            for (int i = 0; i < 5; i++)
            {
                var obj1 = Instantiate(Fence, new Vector2(490 - 100 * (i + 1), 50), Quaternion.identity);
                obj1.transform.SetParent(Canvas.transform, false);
            }
        }
        if (MainMenu.s_Ranch[1] == true)
        {
            var tree = Instantiate(Tree, new Vector2(251, 39), Quaternion.identity);
            tree.transform.SetParent(Canvas.transform, false);
            tree.GetComponent<RectTransform>().sizeDelta = new Vector2(300,300);
            tree.GetComponent<Image>().sprite = TreeSprite;
            tree.SetActive(true);
            Tree.SetActive(true);
        }
        else
        {
            Fence.SetActive(false);
        }
        if (MainMenu.s_Ranch[3] == true)
        {
            Cow.SetActive(true);
        }
        MusicScript = GameObject.FindGameObjectWithTag("music").GetComponent<Music>();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    IEnumerator Moo()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.5f);
            MusicScript.audioSource.PlayOneShot(MusicScript.sounds[0]);
            yield return new WaitForSeconds(16.0f);
        }
    }
}
