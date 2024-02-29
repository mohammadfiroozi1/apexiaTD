using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave/ Enemy Wave",fileName ="Wave")]
public class Wave : ScriptableObject
{
    [Header("Enemies")]
    public List<EnemiesPoolObject> enemies;

    [Header("Spawn Options")]
    public int spawnInterval;
    public int enemyCount;
}
