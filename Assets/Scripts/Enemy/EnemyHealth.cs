using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private bool Death = false;
    public GameObject Player;
    public GameObject HexEffectPrefab;
    public GameObject Raptor;
    public float value = 100;
    public float _time = 0f;
    public

    void Update()
    {
        if (value <= 0)
        {
            DestroyEnemy();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Special")
        {
            Instantiate(HexEffectPrefab, transform.position, Quaternion.identity);
            DealDamage(100f);
        }
    }
    public void DealDamage(float damage)
    {
/*        if (!Death)
        {
            GetComponent<WolfAI>().ChangeExperienceBar();
        }*/
        //GetComponent<Animator>().SetTrigger("GetHit");
        value -= damage;
        //Debug.Log(value);
        if (value <= 0)
        {
            Death = true;
            DestroyEnemy();
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
