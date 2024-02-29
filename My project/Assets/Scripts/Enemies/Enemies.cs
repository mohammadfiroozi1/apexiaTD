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
    [SerializeField] EnemiesListChannel enemiesListChannel;
    [SerializeField] EnemiesPoolObject enemiesPoolObj;

    [Header("Componnents")]
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator anim;

    private List<Transform> wayPoints;

    private int currentWayPointIndex = 0;
    private float hp;

    private void Start()
    {
        InitializeEnemy();
    }

    private void InitializeEnemy()
    {
        wayPoints = wayPointEventChannel.GetWayPoints();
        hp = data.defaultHp;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeDmg(50);
        }
        Patrol(wayPoints);

        
    }
    private void Patrol(List<Transform> wayPoints)
    {
        anim.SetBool("Walk", true);

        Transform wp = wayPoints[currentWayPointIndex];
        if (Vector3.Distance(transform.position, wp.position) < 1f)
        {
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            var projectile = other.GetComponent<Projectile>();
            takeDmg(projectile.GetDamage());
        }
    }

    private void takeDmg(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        enemiesListChannel.RaiseEnemyDied();
        enemiesPoolObj.OnReleaseObject(this);
    }
}
