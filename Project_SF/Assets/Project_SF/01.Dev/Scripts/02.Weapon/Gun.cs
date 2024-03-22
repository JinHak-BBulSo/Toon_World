using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public bool fireAble = true;
    public int power;
    public float fireRate = 1.1f;
    public float bulletSpeed;
    public float range;
    public float neutralize;
    public int mpRecovery;
    public int bulletDestroy;
    public Vector2 bulletSize;
    public Vector2 bulletColliderSize;

    [SerializeField]
    private BulletPool _BulletPool;
    [SerializeField]
    private PlayerController _PlayerController;

    public virtual void Fire()
    {
        if (!fireAble) return;
        Bullet bullet = _BulletPool._BulletPool.Get();
        bullet.gun = this;
        bullet.startPos = this.transform.position;

        int y = 0;
        if (Input.GetKey(KeyCode.DownArrow))
        {
            y = -1;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            y = 1;
        }
        else
        {
            y = 0;
        }

        int x = 0;
        if (y == 0)
        {
            if (_PlayerController.transform.rotation.y == 0)
            {
                x = -1;
            }
            else if (_PlayerController.transform.rotation.y != 0)
            {
                x = 1;
            }
        }
        bullet.transform.position = transform.position;
        bullet.dir = new Vector2(x, y);
        bullet.Firing();
        fireAble = false;
        StartCoroutine(FireDelay());
    }

    IEnumerator FireDelay()
    {
        float fireDelay = 0f;
        fireDelay = (100f / (float)_PlayerController.playerStatus_.attackSpeed) * 1.1f;
        yield return new WaitForSeconds(fireDelay);
        fireAble = true;
    }
}
