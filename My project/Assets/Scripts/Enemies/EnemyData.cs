using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy Data",fileName ="Enemy Data")]
public class EnemyData : ScriptableObject
{
    [Header("Defense Options")]
    public int defaultHp;

    [Header("Move Options")]
    public int defaultMoveSpeed;
    public float rotationSpeed;
}
