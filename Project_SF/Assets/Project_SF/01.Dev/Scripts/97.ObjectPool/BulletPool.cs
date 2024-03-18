using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    public IObjectPool<Bullet> _BulletPool;

    private void Awake()
    {
        _BulletPool = new ObjectPool<Bullet>(CreateBullet, GetBullet, ReleaseBullet, DestroyBullet, maxSize: 30);
    }

    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab, transform).GetComponent<Bullet>();
        bullet.SetBulletPool(_BulletPool);
        return bullet;
    }

    private void GetBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    private void ReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }
    private void DestroyBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }
}
