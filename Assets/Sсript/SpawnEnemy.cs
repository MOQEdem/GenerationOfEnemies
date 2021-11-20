using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _bushes;

    private float _spawnTime;
    private Transform[] _spawnPoints;
    private Transform _currentSpawnPoint;

    private void Start()
    {
        _spawnTime = 2f;
        _spawnPoints = new Transform[_bushes.childCount];

        for (int i = 0; i < _bushes.childCount; i++)
        {
            _spawnPoints[i] = _bushes.GetChild(i);
        }
    }

    private void Update()
    {
        _spawnTime -= Time.deltaTime;

        if (_spawnTime <= 0)
        {
            _currentSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            Instantiate(_enemy, _currentSpawnPoint.position, Quaternion.identity);
            _spawnTime = 2f;
        }
    }
}