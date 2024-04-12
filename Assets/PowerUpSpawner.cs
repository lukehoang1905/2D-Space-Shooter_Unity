using System.Collections;
using System.Collections.Generic;
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
    void Update()
    {

    }
    public GameObject GetPooledPower()
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
