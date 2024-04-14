
using UnityEngine;

public class VFXController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
    }
    // Update is called once per frame
    private float timer;
    private float duration = 0.5f;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > duration)
        {
            gameObject.SetActive(false);
            timer = 0;
        }
    }
}
