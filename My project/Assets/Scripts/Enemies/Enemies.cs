using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{

    [Header("Refrences")]
    [SerializeField] EnemyData data;
    [SerializeField] WayPointEventChannel wayPointEventChannel;

    [Header("Componnents")]
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator anim;

    public List<Transform> wayPoints;

    private int currentWayPointIndex = 0;
    Quaternion targetPos;

    private void Start()
    {
        InitializeEnemy();
    }

    private void InitializeEnemy()
    {
        wayPoints = wayPointEventChannel.GetWayPoints();
        
    }

    private void Update()
    {
        Patrol(wayPoints);

    }
    private void Patrol(List<Transform> wayPoints)
    {
        anim.SetBool("Walk", true);

        Transform wp = wayPoints[currentWayPointIndex];
        if (Vector3.Distance(transform.position, wp.position) < 1f)
        {
            //make the enemy position as equal as waypoint pos
            //transform.position = wp.position;

            currentWayPointIndex = (currentWayPointIndex + 1) % wayPoints.Count;
        }
        else
        {

            Vector3 targetDirection = wp.position - transform.position;
            targetDirection.y = 0f;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            transform.position = Vector3.MoveTowards(transform.position, wp.position, data.defaultMoveSpeed * Time.deltaTime);
            //smooth look 
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.1f);
             
        }

    }
}
