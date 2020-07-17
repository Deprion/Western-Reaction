using UnityEngine;

public class CosmeticAnim : MonoBehaviour
{
    private float Wait;
    void Update()
    {
        Wait -= Time.deltaTime;
        if (Wait <= 0)
        {
            gameObject.transform.position += new Vector3(2 * Time.deltaTime, 0, 0);
            gameObject.transform.Rotate(0, 0, -2);
            if (gameObject.transform.localPosition.x > 1000.0f)
            {
                gameObject.transform.localPosition = new Vector3(-1000, Random.Range(-50, 50), 0);
                Wait = Random.Range(20.0f, 40.0f);
            }
        }
    }
}
