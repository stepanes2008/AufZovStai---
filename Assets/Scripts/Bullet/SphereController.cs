using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float speed;
    public GameObject Bullet;
    public float damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", 5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveFixedUpdate();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DamageEnemy(collision);
        }
        DestroyBullet();
    }
    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage, gameObject);
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
