using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircusHealth : MonoBehaviour
{
    private bool Death = false;
    public GameObject Player;
    public float value = 100;
    public float _time = 0f;

    void Update()
    {
        if (value <= 0)
        {
            DestroyEnemy();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BulletController>() != null)
        {
            DealDamage(1f);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
/*        if (other.gameObject.tag == "Special")
        {
            Instantiate(HexEffectPrefab, transform.position, Quaternion.identity);
            DealDamage(100f);
        }*/
    }
    public void DealDamage(float damage)
    {
        /*        if (!Death)
                {
                    GetComponent<WolfAI>().ChangeExperienceBar();
                }*/
        //GetComponent<Animator>().SetTrigger("GetHit");
        value -= damage;
        Debug.Log(value);
        if (value <= 0)
        {
            Death = true;
            Invoke("DestroyEnemy", 5);
        }
    }
    private void DestroyEnemy()
    {
        _time += 1;
        //GetComponent<Animator>().SetTrigger("Death");
        if (Death && _time == 1)
        {
            GetComponent<WolfAI>().AddKill();
        }
        Destroy(gameObject);
    }
}
