
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    // Start is called before the first frame update
    private readonly float speed = 7.5f;

    private float maxY;
    void Start()
    {
        Camera mainCamera = Camera.main;
        maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.up);
        //bullet outbound
        if (transform.position.y >= maxY)
        {
            gameObject.SetActive(false);
        }
    }
}
