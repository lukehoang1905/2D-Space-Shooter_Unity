
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class VFXSpawner : MonoBehaviour
{
    [SerializeField] private GameObject VFXToPool;
    public List<GameObject> pooledObjects;
    public static VFXSpawner SharedInstance;
    [SerializeField] private int amountToPool = 100;
    // Start is called before the first frame update
    void Start()
    {

        pooledObjects = new List<GameObject>();

        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj;
            obj = Instantiate(VFXToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
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


    public GameObject GetPooledvfx()
    {
        int selection = Random.Range(0, amountToPool);

        if (!pooledObjects[selection].activeInHierarchy)
        {
            return pooledObjects[selection];
        }
        return GetPooledvfx();
    }

}


