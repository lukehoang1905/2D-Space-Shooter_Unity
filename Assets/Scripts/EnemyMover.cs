
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    // Start is called before the first frame update  
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
        if (other.gameObject.CompareTag("Stars")) return;
        // Sound
        SoundFXManager.SharedInstance.PlayAudioName(SoundFXManager.AudioName.EnemyExplosion);
        // Explosion
        GameObject vfx = VFXSpawner.SharedInstance.GetPooledvfx();
        if (vfx != null)
        {
            vfx.SetActive(true);
            vfx.transform.position = gameObject.transform.position;
            // set a time out for this to be SetActive(false) base on duration
        }
        // Star
        GameObject star = StarSpawner.SharedInstance.GetPooledObject();
        if (star != null)
        {
            star.SetActive(true);
            star.transform.position = other.gameObject.transform.position;
        }
        // Dismount
        gameObject.SetActive(false);
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
