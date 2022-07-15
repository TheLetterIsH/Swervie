using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector2 spawnRange;
    [SerializeField] private GameObject enemy;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1);
        Vector2 spawnPos = transform.position + new Vector3(Random.Range(-spawnRange.x, +spawnRange.x), 0);
        Instantiate(enemy, spawnPos, Quaternion.identity);
        StartCoroutine(SpawnEnemy());
    }
}
