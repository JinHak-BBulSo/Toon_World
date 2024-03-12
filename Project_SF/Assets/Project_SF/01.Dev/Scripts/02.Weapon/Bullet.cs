using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public int bulletDamage;
    public Vector2 dir;

    public void Firing()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
