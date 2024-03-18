using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public int bulletDamage;
    public Vector2 dir;
    private Rigidbody2D rb;

    private IObjectPool<Bullet> _BulletPool;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void SetBulletPool(IObjectPool<Bullet> BulletPool_)
    {
        _BulletPool = BulletPool_;
    }

    public virtual void Firing()
    {
        rb.velocity = dir * bulletSpeed;
        Invoke("ReleasePool", 3f);
    }

    public void ReleasePool()
    {
        _BulletPool.Release(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
