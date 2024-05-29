using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemyCreator : MonoBehaviour
{
    public GameObject[] SpawnPoints;
    public bool IsWorking = true;
    public WolfAI wolf;
    public int Enemies = 10;
    public int _maxEnemiesCreated = 50;
    public float minSpawnDelay = 0f;

    void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    IEnumerator CreateEnemy()
    {
        while (Enemies < _maxEnemiesCreated)
        {
            for (int point = 0; point < SpawnPoints.Length; point++)
            {
                Instantiate(wolf, SpawnPoints[point].transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0));
            }
            float delay = Random.Range(minSpawnDelay, 7f);
            Enemies+=4;
            yield return new WaitForSeconds(delay);
        }
    }
}
