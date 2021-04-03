using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public GameScript gs;
    public void OnMouseDown()
    {
        gs.Shoot();
    }
}
