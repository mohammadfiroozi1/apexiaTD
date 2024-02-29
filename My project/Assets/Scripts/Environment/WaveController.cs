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

    [Header("Spawn Options")]
    [SerializeField] float spawnCooldown;
    [SerializeField] Transform spawnTransform;
 
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
                var enemy = waves[waveIndex].enemies[0].pool.Get();
                enemy.transform.position = spawnTransform.position;
                enemiesCount++;
                intervalCounter++;
                if (waves[waveIndex].spawnInterval != 0 && intervalCounter % waves[waveIndex].spawnInterval == 0)
                {
                    var secondTypeEnemy = waves[waveIndex].enemies[1].pool.Get();
                    secondTypeEnemy.transform.position = spawnTransform.position;
                    enemiesCount++;
                    intervalCounter++;
                }
                yield return new WaitForSeconds(spawnCooldown);
            }
        }
    }

    private void EnemyDied() => enemiesCount--;

}
