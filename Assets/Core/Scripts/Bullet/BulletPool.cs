using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform bulletShootStartPoint;
    private const float bulletInBetweenDelay=0.1f;
    private float bulletTime;

    private IObjectPool<Bullet> bulletPool;
    private int defaultCapacity=10;
    private int maxSize=20;

    private void Start()
    {
        bulletPool=new ObjectPool<Bullet>(createFunc,actionOnGet,actionOnRelease,actionOnDestroy,true,defaultCapacity,maxSize);
    }

    private void actionOnDestroy(Bullet obj)
    {
       Destroy(obj.gameObject);
    }

    private void actionOnRelease(Bullet obj)
    {
        obj.gameObject.SetActive(false);
        obj.gameObject.transform.position=bulletShootStartPoint.position;
    }

    private void actionOnGet(Bullet obj)
    {
        obj.gameObject.transform.position=bulletShootStartPoint.position;
        obj.gameObject.SetActive(true);
    }

    private Bullet createFunc()
    {
        var bullet = Instantiate(bulletPrefab,transform.position,Quaternion.identity);  
        bullet.objectPool=bulletPool;
        bullet.transform.position=bulletShootStartPoint.position;
        return bullet;
    }
    
    private void Update()
    {
        if (Input.GetMouseButton(0)&&PlayerController.IsGround)
        {
            if (bulletTime>=bulletInBetweenDelay)
            {
                bulletTime=0;
                Shoot();    
            }
            else
            {
                bulletTime+=Time.deltaTime;
            }
        }
    }

    private void Shoot()
    {
        bulletPool.Get(out Bullet bullet);
        bullet.Shoot();
    }
}
