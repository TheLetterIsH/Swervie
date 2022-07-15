using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector2 spawnRangeEnemy;
    [SerializeField] private Vector2 spawnRangePoint;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject point;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnPoint());
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1);
        Vector2 spawnPos = transform.position + new Vector3(Random.Range(-spawnRangeEnemy.x, +spawnRangeEnemy.x), 0);
        Instantiate(enemy, spawnPos, Quaternion.identity);
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnPoint()
    {
        yield return new WaitForSeconds(1.5f);
        Vector2 spawnPos = transform.position + new Vector3(Random.Range(-spawnRangePoint.x, +spawnRangePoint.x), 0);
        Instantiate(point, spawnPos, Quaternion.identity);
        StartCoroutine(SpawnPoint());
    }
}
