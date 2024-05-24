using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpawner : MonoBehaviour
{
    public GameObject fireball;
    public GameObject fireballSpawner;
    private int fireballsCreated;

    void Start()
    {
        StartCoroutine(CreateFireball());
    }
    IEnumerator CreateFireball()
    {
        while (fireballsCreated < 100)
        {
            Instantiate(fireball, fireballSpawner.transform);
            float delay = Random.Range(0f, 2f);
            fireballsCreated++;
            yield return new WaitForSeconds(delay);
        }
        //yield return new WaitForSeconds(10);
    }
}
