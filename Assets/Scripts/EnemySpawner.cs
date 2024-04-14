using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject objectToPool;
    private int amountToPool = 20;
    public static EnemySpawner ShareInstance;

    private List<GameObject> pooledObjects;
    private float emenyTimer = 0f;
    private int enemySpawnRate = 2;
    private float enemySpawnCoolDown = 2f;

    private void Awake()
    {
        ShareInstance = this;
    }
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject item = Instantiate(objectToPool);
            item.SetActive(false);
            pooledObjects.Add(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        emenyTimer += Time.deltaTime;
        if (emenyTimer >= enemySpawnCoolDown)
        {
            float lastCoordX = 0f;
            for (int i = 0; i < enemySpawnRate; i++)
            {
                GameObject enemy = ShareInstance.GetEnemy();
                enemy.SetActive(true);
                CircleCollider2D collider = enemy.GetComponent<CircleCollider2D>();

                // Get a random coordinate within the horizontal boundaries
                Vector2 coord = Utils.Boundaries.RandomCoordInBound("coordHorizontal", collider);

                // Check if the current enemy's X coordinate is too close to the last spawned enemy
                if (Mathf.Abs(coord.x - lastCoordX) < collider.radius * 2)
                {
                    // If too close, adjust the X coordinate to ensure they don't collide
                    float newX = lastCoordX + collider.radius * 2;
                    coord = new Vector2(newX, coord.y);
                }

                // Update lastCoordX for the next iteration
                lastCoordX = coord.x;

                // Set the enemy's position
                enemy.transform.position = coord;
            };
            emenyTimer = 0f;
        }
    }
    public GameObject GetEnemy()
    {
        foreach (GameObject item in pooledObjects)
        {
            if (!item.activeInHierarchy) return item;
        }
        return null;
    }
}
