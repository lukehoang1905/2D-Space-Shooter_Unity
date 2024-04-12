using System;
using System.Collections.Generic;

using UnityEngine;



public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private readonly float nozzle = 0.5f;
    float minX, maxX, minY, maxY;
    float wings = 0.5f;
    [SerializeField] private float horizontalModifier = 1.3f;
    // Start is called before the first frame update
    void Start()
    {
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        FindBoundaries(collider);
    }

    // Update is called once per frame

    void Update()
    {
        Movement();
        if (Input.GetButtonDown("Fire1"))
        {
            float posX = gameObject.transform.position.x;
            float posY = gameObject.transform.position.y;
            GameManager.GameInstance.Shoot(posX, posY + nozzle, wings);
        }
    }

    void FindBoundaries(CircleCollider2D collider)
    {
        Camera mainCamera = Camera.main;
        minX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + collider.radius;
        maxX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - collider.radius;
        minY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + collider.radius;
        maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - collider.radius;
    }
    void Movement()
    {
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed * horizontalModifier;

        float destinationX = Math.Clamp(transform.position.x + deltaX, minX, maxX);
        float destinationY = Math.Clamp(transform.position.y + deltaY, minY, maxY);

        transform.position = new Vector2(destinationX, destinationY);
    }


}

