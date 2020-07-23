using UnityEngine;

public class Ranch : MonoBehaviour
{
    public GameObject Fence, Canvas, Tree, Cow;
    public Music MusicScript;
    private void Start()
    {
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
    public void Moo()
    {
        MusicScript.audioSource.PlayOneShot(MusicScript.sounds[0]);
    }
}
