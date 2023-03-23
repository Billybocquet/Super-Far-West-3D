using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [Header("Road")]
    public Transform[] waypointList;
    
    [Header("Events")]
    public string[] eventRoad;
    public float[] eventProbabilities;

    [Header("Gizmos")]
    [SerializeField] private Color gizmosColor;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmosColor;
        
        if (waypointList != null)
        {
            for (int i = 0; i < waypointList.Length -1 ; i++)
            {
                Gizmos.DrawLine(waypointList[i].position, waypointList[i +1].position);
                
                /*for (int j = (i + 1); j < wayPointList.Length; j++)
                {
                    Gizmos.DrawLine(wayPointList[i].position, wayPointList[j].position);
                }*/
            }
        }
    }
}
