
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager GameInstance { get; private set; }
    [SerializeField] BulletType bulletType;
    Vector2 _destination, _origin;
    void Awake()
    {
        GameInstance = this;
    }
    private void Start()
    {
        bulletType = BulletType.Single;
    }
    private void Update()
    {
        StartCoroutine(StartCountDown());
    }

    public float countdownDuration = 3f;
    IEnumerator StartCountDown()
    {
        float timer = countdownDuration;
        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
    }




    public void Shoot(float posX, float posY, float wings)
    {
        switch (bulletType)
        {
            case BulletType.Single:
                _destination = Vector2.up;
                _origin = new Vector2(posX, posY);
                StartFireBullet(_origin, _destination);
                break;
            case BulletType.Triple:
                _destination = Vector2.up;

                for (int i = -1; i < 2; i++)
                {
                    _origin = new Vector2(posX + wings * i, posY);
                    StartFireBullet(_origin, _destination);
                }
                break;
            case BulletType.Fan:
                float bulletAngle = .5f;
                for (int i = -1; i < 2; i++)
                {
                    _destination = new Vector2(i * bulletAngle, 4);
                    _origin = new Vector2(posX, posY);
                    StartFireBullet(_origin, _destination);
                }
                break;
            default:
                bulletType = BulletType.Single;
                break;
        }
    }
    public void SwitchBulletType(BulletType type)
    {
        switch (type)
        {
            case BulletType.Single:
                bulletType = BulletType.Single;
                break;
            case BulletType.Triple:
                bulletType = BulletType.Triple;
                break;
            case BulletType.Fan:
                bulletType = BulletType.Fan;
                break;
            default:
                bulletType = BulletType.Single;
                break;
        }
    }

    private void StartFireBullet(Vector2 origin, Vector2 destination)
    {
        GameObject bullet = BulletSpawner.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.SetActive(true);
            BulletMover bulletMover = bullet.GetComponent<BulletMover>();
            bullet.transform.position = origin;
            bulletMover.SetDestination(destination);
        }
    }

    public enum BulletType
    {
        Single,
        Triple,
        Fan
    }
}