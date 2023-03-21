using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AvatarController : MonoBehaviour
{
    [Header("Initialization Control")]
    [SerializeField] private KeyCode roadInitialization;
    
    [Header("Script")]
    [SerializeField] private Road roadReference;

    [Header("Road")]
    [SerializeField] private Transform[] waypointPosition;
    [SerializeField] private int waypointIndex;
    [SerializeField] private float distance;

    private NavMeshAgent agent;

    private bool isReverse;
    private bool isInitialized;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void RoadInitialization()
    {
        if (roadReference != null)
        {
            waypointPosition = roadReference.waypointList;
            waypointIndex = GetClosestWayPointID(transform.position);
            Debug.Log("Initialisation waypoint : " + waypointIndex);
            
            if (waypointIndex >= waypointPosition.Length - 1)
            {
                isReverse = true;
            }
            else
            {
                isReverse = false;
            }

            Debug.Log("Route initialisé");
            isInitialized = true;

            agent.SetDestination((waypointPosition[waypointIndex].position));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(roadInitialization))
        {
            RoadInitialization();
        }
        
        if (isInitialized)
        {
             Travel();           
        }
    }

    void Travel()
    {
        if (agent.remainingDistance < distance && !isReverse)
        {
            if (waypointIndex < waypointPosition.Length - 1)
            {
                waypointIndex++;
                agent.SetDestination((waypointPosition[waypointIndex].position));
                Debug.Log("Road waypoint : " + waypointIndex);
            }
            else
            {
                Debug.Log("Arrivé waypoint : " + waypointIndex);
                roadReference = null;

                isInitialized = false;
            }

        }        
        if (agent.remainingDistance < distance && isReverse)
        {
            if (waypointIndex >= 1)
            {
                waypointIndex--;
                agent.SetDestination((waypointPosition[waypointIndex].position));
                Debug.Log("Road waypoint : " + waypointIndex);
            }
            else
            {
                Debug.Log("Arrivé waypoint : " + waypointIndex);
                roadReference = null;

                isInitialized = false;
            }
        }
    }
    
    private int GetClosestWayPointID(Vector3 position)
    {
        float closestDistance = Mathf.Infinity;
        int closestWaypointId = 0;

        for (var i = 0; i < waypointPosition.Length; i++)
        {
            float dist = Vector3.Distance(position, waypointPosition[i].position);

            if (dist < closestDistance)
            {
                closestDistance = dist;
                closestWaypointId = i;
            }
        }

        return closestWaypointId;
    }

    public void OnMouseDown()
    {
        CameraController.instance.followTransform = transform;
    }
}