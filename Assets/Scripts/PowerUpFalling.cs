
using UnityEngine;

public class PowerUpFalling : MonoBehaviour
{
    [SerializeField] private float speed = 4f;

    float minY;
    // Start is called before the first frame update
    void Start()
    {
        Camera mainCamera = Camera.main;
        minY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y <= minY)
        {
            gameObject.SetActive(false);
        }
    }
}
