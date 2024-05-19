using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public GameObject[] SpawnPoints;
    public bool IsWorking = true;
    public WolfAI wolf;
    private int Enemies = 10;
    public int _maxEnemiesCreated = 50;

    void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    IEnumerator CreateEnemy()
    {
        while (Enemies < _maxEnemiesCreated)
        {
            int spawnPointIndex = Random.Range(0, SpawnPoints.Length - 1);
            Instantiate(wolf, SpawnPoints[spawnPointIndex].transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0));
            float delay = Random.Range(0f, 3f);
            Enemies++;
            yield return new WaitForSeconds(delay);
        }
    }
}
