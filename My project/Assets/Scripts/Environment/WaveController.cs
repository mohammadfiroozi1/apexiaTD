using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    // Start is called before the first frame update


    [Header("Waves")]
    [SerializeField] List<Wave> waves;

    [Header("Refrences")]
    [SerializeField] EnemiesListChannel enemiesListChannel;
    [SerializeField] EnemiesPoolObject enemyPool;

    [Header("Spawn Options")]
    [SerializeField] float spawnCooldown;

    private int waveIndex = -1;
    private int intervalCounter;
    private int waveCounter;
    private int enemiesCount;


    void OnEnable()
    {
        enemiesListChannel.EnemyDied += EnemyDied;
    }

    IEnumerator Start()
    {
        if(enemiesCount == 0)
        {
            waveIndex++;
            for (int i = 0; i < waves[waveIndex].enemyCount; i++)
            {

            }
        }
        yield break;
    }

    private void EnemyDied() => enemiesCount--;

}
