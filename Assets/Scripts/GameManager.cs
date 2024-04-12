using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager GameInstance { get; private set; }
    public static BulletType bulletType;
    void Awake()
    {
        GameInstance = this;
    }
    private void Start()
    {
        bulletType = BulletType.Triple;
    }
    private void Update()
    {

    }

    public void UpdateBulletType(BulletType type)
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

    public enum BulletType
    {
        Single,
        Triple,
        Fan
    }
}