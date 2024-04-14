using UnityEngine;

public class StarMover : MonoBehaviour
{
    float minY;
    float speed = 1f;
    void Start()
    {
        Camera mainCamera = Camera.main;
        minY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y <= minY)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.ScoreInstance.UpdateScore(1);
            SoundFXManager.SharedInstance.PlayAudioName(SoundFXManager.AudioName.Coin);
            gameObject.SetActive(false);
        }
    }
}
