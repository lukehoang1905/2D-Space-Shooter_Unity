using System.Collections;
using System.Collections.Generic;
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
