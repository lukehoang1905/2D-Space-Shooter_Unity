
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager GameInstance { get; private set; }
    [SerializeField] BulletType bulletType;
    int ammo;
    Vector2 _destination, _origin;
    void Awake()
    {
        GameInstance = this;
    }
    private void Start()
    {
        bulletType = BulletType.Single;
        ammo = 5;
    }

    private void Update()
    {

    }

    public void Shoot(float posX, float posY, float wings)
    {
        if (ammo <= 0) bulletType = BulletType.Single;

        switch (bulletType)
        {
            case BulletType.Triple:
                _destination = Vector2.up;
                for (int i = -1; i < 2; i++)
                {
                    _origin = new Vector2(posX + wings * i, posY);
                    StartFireBullet(_origin, _destination);
                }
                ammo--;
                break;
            case BulletType.Fan:
                float bulletAngle = .5f;
                for (int i = -1; i < 2; i++)
                {
                    _destination = new Vector2(i * bulletAngle, 4);
                    _origin = new Vector2(posX, posY);
                    StartFireBullet(_origin, _destination);
                }
                ammo--;
                break;
            default:
                bulletType = BulletType.Single;
                _destination = Vector2.up;
                _origin = new Vector2(posX, posY);
                StartFireBullet(_origin, _destination);
                break;
        }
    }

    //Todo: Fix casting to Enum
    public void SwitchBulletType(string type)
    {
        switch (type)
        {
            case "Single":
                bulletType = BulletType.Single;
                break;
            case "Triple(Clone)":
                bulletType = BulletType.Triple;
                ammo = 5;
                break;
            case "Fan(Clone)":
                bulletType = BulletType.Fan;
                ammo = 5;
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