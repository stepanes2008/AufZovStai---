using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public GameObject Bullet;
    public float damage = 10;
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
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.GetComponent<WolfAI>() != null)
        {
            DestroyBullet();
            DamageEnemy(collision);
        }
    }
    private void DamageEnemy(Collision collision)
    {
        Debug.Log(damage);
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }
    }
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
