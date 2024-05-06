using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public Move player;
    public float viewAngle;

    private NavMeshAgent _navMeshAgent;
    private Vector3 LastPosition;
    private bool _isPlayerNoticed;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        PickNewPatrolPoint();
    }

    // Update is called once per frame
    private void Update()
    {
        NoticePlayerUpdate();
        PatrolUpdate();
        //ChaseUpdate();
    }

    private void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && _isPlayerNoticed == false)
        {
            PickNewPatrolPoint();
        }
    }

    private void PickNewPatrolPoint()
    {
        LastPosition = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }

    private void NoticePlayerUpdate()
    {
        // !стандартная конструкция для Raycast!
        var direction = player.transform.position - transform.position;

        //_isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                Debug.Log(hit.collider.gameObject);
                if (hit.collider.gameObject == player.gameObject)
                {
                    Debug.Log("hi");
                    _isPlayerNoticed = true;
                }
                else
                {
                    //Debug.Log("hi");
                    _isPlayerNoticed = false;
                }
            }
            else
            {
                _isPlayerNoticed = false;
            }
        }
        // !стандартная конструкция для Raycast!
    }

/*    void FaceTarget()
    {
        var turnTowardNavSteeringTarget = _navMeshAgent.steeringTarget;
        Vector3 direction = (turnTowardNavSteeringTarget - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            //_navMeshAgent.preventRotation = true;
            FaceTarget();
            //transform.LookAt(player.transform.position);
            _navMeshAgent.destination = player.transform.position;

            *//*            if (_navMeshAgent.remainingDistance <= 10f && RoarEnabled)
                        {
                            GetComponent<Animator>().SetTrigger("Roar");
                            RoarEnabled = false;
                        }*//*
            Debug.Log("Поко!");
        }
        else
        {
            //RoarEnabled = true;
            _navMeshAgent.destination = LastPosition;
        }
    }*/
}
