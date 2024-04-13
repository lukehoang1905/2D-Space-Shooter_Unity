
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour

{

    // Start is called before the first frame update
    public static StarSpawner SharedInstance;
    private List<GameObject> pooledObjects;
    [SerializeField] private GameObject objectToPool;
    private int amountToPool = 50;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject bullet;
        for (int i = 0; i < amountToPool; i++)
        {
            bullet = Instantiate(objectToPool);
            bullet.SetActive(false);
            pooledObjects.Add(bullet);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
