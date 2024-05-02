﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public GameObject Bullet;
    public float damage = 25;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", 10);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveFixedUpdate();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            DestroyBullet();
            //DamageEnemy(collision);
        }
    }
    /*private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }
    }*/
    private void DestroyEnemy(Collision enemy)
    {
        Destroy(enemy.gameObject);
    }
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
    private void MoveFixedUpdate()
    {
        transform.position += transform.up * speed * Time.fixedDeltaTime;
    }
}
