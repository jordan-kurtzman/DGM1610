using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Enemy : MonoBehaviour
{
    // enemy stats
    public int curHp, maxHp, scoreToGive;
    // movement
    public float moveSpeed, attackRange, yPathOffset;
    // coords for path
    private List<Vector3> path;
    // enemy weapon
    private Weapon weapon;
    // target to follow
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        // get components
        weapon = GetComponent<Weapon>();
        target = FindObjectOfType<PlayerController>().gameObject;
        InvokeRepeating("UpdatePath", 0.0f, 0.5f);

        curHp = maxHp;
    }


    void UpdatePath()
    {
        // calculate path to target
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);
        
        path = navMeshPath.corners.ToList();
    }

    void ChaseTarget()
    { 
        if(path.Count == 0)
            return;
        // move towards closest path
        transform.position = Vector3.MoveTowards(transform.position, path [0] + new Vector3(0,yPathOffset,0), moveSpeed * Time.deltaTime);

        if(transform.position == path[0] + new Vector3(0, yPathOffset,0))
            path.RemoveAt(0);
    }

    void Update()
    {
        // look at target
        Vector3 dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.x,dir.z) * Mathf.Rad2Deg;
        transform.eulerAngles = Vector3.up * angle;
        // calc distance btw enemy and player
        float dist = Vector3.Distance(transform.position, target.transform.position);
        // if within attackrange shoot at player
        if(dist <= attackRange)
        {
            if(weapon.CanShoot())
                weapon.Shoot();
        }
        // if enemy too far away chase after player
        else
        {
            ChaseTarget();
        }

    }
}
