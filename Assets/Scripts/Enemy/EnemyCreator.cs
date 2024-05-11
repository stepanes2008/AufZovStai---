using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public GameObject[] SpawnPoints;
    public bool IsWorking = true;
    public WolfAI wolf;

    void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    IEnumerator CreateEnemy()
    {
        while (IsWorking)
        {
            int spawnPointIndex = Random.Range(0, SpawnPoints.Length - 1);
            Instantiate(wolf, SpawnPoints[spawnPointIndex].transform);
            float delay = Random.Range(0f, 10f);
            yield return new WaitForSeconds(delay);
        }
    }
}
