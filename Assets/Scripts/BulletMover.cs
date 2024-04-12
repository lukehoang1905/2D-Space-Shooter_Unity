
using UnityEngine;

public class BulletMover : MonoBehaviour
{

    private readonly float _speed = 5f;
    private float maxY;
    Vector2 _destination;
    [SerializeField] float _angle = 1.3f;


    void Start()
    {
        Camera mainCamera = Camera.main;
        maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }
    // Update is called once per frame
    void Update()
    {

        transform.Translate(_speed * Time.deltaTime * _destination);

        //bullet outbound
        if (transform.position.y >= maxY)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetDestination(Vector2 des)
    {
        _destination = des;
    }
}
