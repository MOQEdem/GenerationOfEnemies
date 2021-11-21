using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _bushes;
    [SerializeField] private float _spawnTime;

    private Transform[] _spawnPoints;
    private Transform _currentSpawnPoint;

    private void Start()
    {
        _spawnPoints = new Transform[_bushes.childCount];

        for (int i = 0; i < _bushes.childCount; i++)
        {
            _spawnPoints[i] = _bushes.GetChild(i);
        }

        StartCoroutine(SpawnEnemy(_spawnTime));
    }

    private IEnumerator SpawnEnemy(float spawnTime)
    {
        while (true)
        {
            _currentSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            Instantiate(_enemy, _currentSpawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}