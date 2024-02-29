using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event Channels/Enemies List Event Channel", fileName = "Enemies List Event Channel")]

public class EnemiesListChannel : ScriptableObject
{
    public event Action EnemyDied;


    public void RaiseEnemyDied() => EnemyDied?.Invoke();
}
