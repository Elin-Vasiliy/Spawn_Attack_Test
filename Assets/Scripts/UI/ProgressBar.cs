using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Spawner Spawner;

    private Slider _slider;

    void Start()
    {
        _slider = GetComponentInChildren<Slider>();
        _slider.value = 0;
        Spawner.ChangeEnemyCount += ChangeEnemyCount;
    }

    private void ChangeEnemyCount(int maxEnemy, int enemy)
    {
        _slider.value = (float)enemy / maxEnemy;
    }

    private void OnDestroy()
    {
        Spawner.ChangeEnemyCount -= ChangeEnemyCount;
    }
}
