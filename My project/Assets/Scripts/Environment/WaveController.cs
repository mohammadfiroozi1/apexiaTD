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
 
    [SerializeField] private int waveIndex = -1;
    [SerializeField] private int intervalCounter;
    [SerializeField] private int waveCounter = 0;
    [SerializeField] private int enemiesCount;


    void OnEnable()
    {
        enemiesListChannel.EnemyDied += EnemyDied;
    }

    IEnumerator Start()
    {
        while (waveCounter < waves.Count)
        {
            intervalCounter = 0; // Reset intervalCounter at the beginning of each wave

            if (enemiesCount == 0 && waveIndex < waves.Count)
            {
                waveIndex++;
                for (int i = 0; i < waves[waveIndex].enemyCount; i++)
                {
                    var enemy = waves[waveIndex].enemies[0].pool.Get();
                    enemy.transform.position = spawnTransform.position;
                    enemiesCount++;
                    intervalCounter++;

                    if (waves[waveIndex].spawnInterval != 0 && (intervalCounter % waves[waveIndex].spawnInterval == 0))
                    {
                        var secondTypeEnemy = waves[waveIndex].enemies[1].pool.Get();
                        secondTypeEnemy.transform.position = spawnTransform.position;
                        enemiesCount++;
                        intervalCounter++;
                    }
                    yield return new WaitForSeconds(spawnCooldown);
                }
                waveCounter++; // Increment waveCounter outside the if block
            }
            yield return null;
        }

    }

    private void EnemyDied() => enemiesCount--;

}
