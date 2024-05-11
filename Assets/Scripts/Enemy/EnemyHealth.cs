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
    public void DestroyEnemy()
    {
        _time += Time.deltaTime;
        //GetComponent<Animator>().SetTrigger("Death");
        Player.GetComponent<KillsCounter>().Kills += 1;
        Destroy(gameObject);
    }
}
