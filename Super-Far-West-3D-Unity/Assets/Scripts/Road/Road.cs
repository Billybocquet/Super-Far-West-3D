using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [Header("Road")]
    public Transform[] wayPointList;
    public string[] roadEvent;

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
        
        if (wayPointList != null)
        {
            for (int i = 0; i < wayPointList.Length -1 ; i++)
            {
                Gizmos.DrawLine(wayPointList[i].position, wayPointList[i +1].position);
                
                /*for (int j = (i + 1); j < wayPointList.Length; j++)
                {
                    Gizmos.DrawLine(wayPointList[i].position, wayPointList[j].position);
                }*/
            }
        }
    }
}
