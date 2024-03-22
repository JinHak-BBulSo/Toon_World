using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public int bulletDamage;
    public Vector3 startPos;
    public Vector2 dir;
    public Gun gun;
    private Rigidbody2D rb;

    private IObjectPool<Bullet> _BulletPool;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Vector2.Distance(startPos, transform.position) > gun.range)
        {
            ReleasePool();
        }
    }

    public void SetBulletPool(IObjectPool<Bullet> BulletPool_)
    {
        _BulletPool = BulletPool_;
    }

    public virtual void Firing()
    {
        rb.velocity = dir * bulletSpeed;
    }

    public void ReleasePool()
    {
        _BulletPool.Release(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
