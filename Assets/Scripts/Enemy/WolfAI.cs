using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public Move player;
    public float damage = 33.4f;

    private NavMeshAgent _navMeshAgent;
    private Vector3 LastPosition;
    private bool _isPlayerNoticed;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        /*var direction = player.transform.position - transform.position;

        _isPlayerNoticed = false;
        RaycastHit hit;
        if(Physics.Raycast(transform.position + Vector3.up, direction, out hit))
        {
            if(hit.collider.gameObject == player.gameObject)
            {
                _isPlayerNoticed = true;
                Debug.Log("You are noticed!");
            }
        }*/

        PatrolUpdate();
        AttackUpdate();
    }

    void AttackUpdate()
    {
        if (_navMeshAgent.pathPending)
            return;
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            //Debug.Log(_navMeshAgent.stoppingDistance);
            Debug.Log(_navMeshAgent.remainingDistance);
            player.GetComponent<PlayerHealth>().DealDamage(damage * Time.deltaTime, gameObject);
            //GetComponent<Animator>().SetTrigger("Attack");
        }
    }

    private void PatrolUpdate()
    {
        _navMeshAgent.destination = player.transform.position;
        //Debug.Log(_navMeshAgent.destination);
/*        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            PickNewPatrolPoint();
        }*/
    }

    public void AddKill()
    {
        player.GetComponent<KillsCounter>().Kills++;
    }

/*    private void PickNewPatrolPoint()
    {
        LastPosition = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }*/
}
