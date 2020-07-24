using UnityEngine;

public class CosmeticAnim : MonoBehaviour
{
    private float wait;
    private Vector2 objPos;
    private void Start()
    {
        objPos = gameObject.GetComponent<RectTransform>().anchoredPosition;
    }
    private void Update()
    {
        wait -= Time.deltaTime;
        if (wait <= 0)
        {
            objPos += new Vector2(2 * Time.deltaTime, 0);
            gameObject.transform.Rotate(0, 0, -2);
            if (objPos.x > 1000.0f)
            {
                objPos = new Vector3(-1000, Random.Range(-50, 50), 0);
                wait = Random.Range(20.0f, 40.0f);
            }
        }
    }
}
