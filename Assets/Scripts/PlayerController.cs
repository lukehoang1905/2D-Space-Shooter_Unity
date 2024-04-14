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
        // Set up boundaries
        Dictionary<string, float> boundaries = Utils.Boundaries.FindBoundaries(collider);
        minX = boundaries["minX"];
        maxX = boundaries["maxX"];
        minY = boundaries["minY"];
        maxY = boundaries["maxY"];
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            GameManager.GameInstance.SwitchBulletType(other.gameObject.name);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            HealthBarScript.HealthInstance.UpdateHealth(-1);
        }
    }

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

    void Movement()
    {
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed * horizontalModifier;

        float destinationX = Math.Clamp(transform.position.x + deltaX, minX, maxX);
        float destinationY = Math.Clamp(transform.position.y + deltaY, minY, maxY);

        transform.position = new Vector2(destinationX, destinationY);
    }


}

