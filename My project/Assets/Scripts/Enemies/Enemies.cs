using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] EnemyData data;
    [SerializeField] WayPointEventChannel wayPointEventChannel;

    [Header("Componnents")]
    [SerializeField] NavMeshAgent agent;


    private void InitializeEnemy()
    {

    }
}
