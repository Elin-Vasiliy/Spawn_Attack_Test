using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Wave> Waves;
    public Transform SpawnPoint;
    public Player Player;
    public Action<int, int> ChangeEnemyCount;
    public GameObject NextWaveButton;

    private Wave _currentWave;
    private int _waveCount;
    private float _lastSpawnTime;
    private int _spawned;

    void Start()
    {
        SetWave(_waveCount);
    }

    void Update()
    {
        if (_currentWave == null)
            return;
        _lastSpawnTime += Time.deltaTime;

        if(_lastSpawnTime >= _currentWave.Delay)
        {
            var enemy = Instantiate(_currentWave.Prefab, SpawnPoint.position, SpawnPoint.rotation, SpawnPoint).GetComponent<Enemy>();
            enemy.SetTarget(Player);
            enemy.OnEnemyDie += Player.GetRewardMoney;
            _spawned++;
            _lastSpawnTime = 0;
            ChangeEnemyCount?.Invoke(_currentWave.Count, _spawned);
        }

        if (_currentWave.Count <= _spawned)
        {
            if (Waves.Count > _waveCount + 1)
            {
                NextWaveButton.SetActive(true);
                _currentWave = null;
            }
            else
            {
                _currentWave = null;
            }
        }
    }

    public void NextWave()
    {
        SetWave(++_waveCount);
        _spawned = 0;
        ChangeEnemyCount?.Invoke(1, 0);
        NextWaveButton.SetActive(false);
    }

    private void SetWave(int index)
    {
        _currentWave = Waves[index];
    }
}

[System.Serializable]
public class Wave
{
    public GameObject Prefab;
    public float Delay;
    public int Count;
}
