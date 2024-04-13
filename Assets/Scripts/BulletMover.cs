
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{

    private readonly float _speed = 5f;
    Vector2 _destination;
    float minX, maxX, minY, maxY;


    void Start()
    {
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        Dictionary<string, float> boundaries = Utils.Boundaries.FindBoundaries(collider);
        minX = boundaries["minX"];
        maxX = boundaries["maxX"];
        minY = boundaries["minY"];
        maxY = boundaries["maxY"];

    }
    // Update is called once per frame
    void Update()
    {

        transform.Translate(_speed * Time.deltaTime * _destination);

        //bullet outbound
        if (transform.position.y >= maxY ||
            transform.position.y < minY ||
            transform.position.x <= minX ||
            transform.position.x > maxX)
        {
            gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameObject star = StarSpawner.SharedInstance.GetPooledObject();
            star.SetActive(true);
            star.transform.position = other.gameObject.transform.position;
            other.gameObject.SetActive(false);
        }
    }
    public void SetDestination(Vector2 des)
    {
        _destination = des;
    }
}
