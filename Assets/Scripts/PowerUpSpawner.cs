using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{


    [SerializeField] private List<GameObject> powerToPools;
    public List<GameObject> pooledObjects;
    public static PowerUpSpawner SharedInstance;
    [SerializeField] private int amountToPool = 10;
    // Start is called before the first frame update
    void Start()
    {

        pooledObjects = new List<GameObject>();

        foreach (GameObject power in powerToPools)
        {
            GameObject temp;
            for (int i = 0; i < amountToPool; i++)
            {
                temp = Instantiate(power);
                temp.SetActive(false);
                pooledObjects.Add(temp);
            }
        }

    }
    private void Awake()
    {
        SharedInstance = this;
    }

    // Update is called once per frame
    float timer;
    float interval = 3f;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            SpawPower();
            timer = 0;
        }
    }
    void SpawPower()
    {
        GameObject power = SharedInstance.GetPooledPower();
        CircleCollider2D collider = power.GetComponent<CircleCollider2D>();
        Vector2 spawPosition = Utils.Boundaries.RandomCoordInBound("coordHorizontal", collider);
        power.SetActive(true);
        power.transform.position = spawPosition;
    }

    public GameObject GetPooledPower()
    {
        int selection = Random.Range(0, amountToPool * 2);

        if (!pooledObjects[selection].activeInHierarchy)
        {
            return pooledObjects[selection];
        }
        return GetPooledPower();
    }

}
