using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureController : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField] private KeyCode northKey;
    [SerializeField] private KeyCode southKey;
    [SerializeField] private KeyCode estKey;
    [SerializeField] private KeyCode westKey;
    [SerializeField] private KeyCode northEstKey;
    [SerializeField] private KeyCode northWestKey;
    [SerializeField] private KeyCode southEstKey;
    [SerializeField] private KeyCode southWestKey;
    [SerializeField] private KeyCode enterKey;

    [Header("Road")] 
    [SerializeField] private GameObject[] RoadList;

    [Header("Avatar")] 
    [SerializeField] private GameObject avatarGameObject;

    [Header("Script Reference")] 
    private AvatarController avatarScript;
    private Road roadScript;

    [Header("GameObject Transform")]
    [SerializeField] private Transform[] cityTransformsList;

    [Header("Distance")]
    [SerializeField] private float distance;

    // Start is called before the first frame update
    void Start()
    {
        avatarScript = avatarGameObject.GetComponent<AvatarController>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToStart = Vector3.Distance(avatarGameObject.transform.position, cityTransformsList[0].position);
        //Debug.Log(distanceToStart);
        
        float distanceToYellowStone = Vector3.Distance(avatarGameObject.transform.position, cityTransformsList[1].position);
        //Debug.Log(distanceToYellowStone);
        
        float distanceToBlueLagoon = Vector3.Distance(avatarGameObject.transform.position, cityTransformsList[2].position);
        //Debug.Log(distanceToBlueLagoon);
        
        float distanceToRedValley = Vector3.Distance(avatarGameObject.transform.position, cityTransformsList[3].position);
        //Debug.Log(distanceToRedValley);
        
        float distanceToCenter = Vector3.Distance(avatarGameObject.transform.position, cityTransformsList[4].position);
        //Debug.Log(distanceToCenter);

        if (distance >= distanceToStart && !avatarScript.isInitialized)
        {
            Debug.Log("Wait At Start");
            
            AvatarAtStart();            
        }
        
        if (distance >= distanceToYellowStone && !avatarScript.isInitialized)
        {
            Debug.Log("Wait At Yellow Stone");
            
            AvatarAtYellowStone();            
        }
        
        if (distance >= distanceToBlueLagoon && !avatarScript.isInitialized)
        {
            Debug.Log("Wait At Blue Lagoon");
            
            AvatarAtBlueLagoon();            
        }
        
        if (distance >= distanceToRedValley && !avatarScript.isInitialized)
        {
            Debug.Log("Wait At Red Valley");
            
            AvatarAtRedValley();            
        }

        if (distance >= distanceToCenter && !avatarScript.isInitialized)
        {
            Debug.Log("Wait At Center");
            
            AvatarAtCenter();
        }
    }

    void AvatarAtStart()
    {
        if (Input.GetKey(southKey))
        {
            roadScript = RoadList[0].GetComponent<Road>();
            
            avatarScript.roadReference = roadScript;

            avatarScript.RoadInitialization();
        }
    }

    void AvatarAtRedValley()
    {
        if (Input.GetKey(estKey))
        {
            roadScript = RoadList[1].GetComponent<Road>();
            
            avatarScript.roadReference = roadScript;

            avatarScript.RoadInitialization();
        }
    }

    void AvatarAtBlueLagoon()
    {
        if (Input.GetKey(westKey))
        {
            roadScript = RoadList[2].GetComponent<Road>();
            
            avatarScript.roadReference = roadScript;

            avatarScript.RoadInitialization();
        }
    }
    
    void AvatarAtYellowStone()
    {
        if (Input.GetKey(northKey))
        {
            roadScript = RoadList[3].GetComponent<Road>();
            
            avatarScript.roadReference = roadScript;

            avatarScript.RoadInitialization();
        }
    }
    
    void AvatarAtNorthWest()
    {
        if (Input.GetKey(northKey) && Input.GetKey(westKey))
        {
            roadScript = RoadList[4].GetComponent<Road>();
            
            avatarScript.roadReference = roadScript;

            avatarScript.RoadInitialization();
        }
    }
    
    void AvatarAtNorthEst()
    {
        if (Input.GetKey(northKey) && Input.GetKey(estKey))
        {
            roadScript = RoadList[5].GetComponent<Road>();
            
            avatarScript.roadReference = roadScript;

            avatarScript.RoadInitialization();
        }
    }
    
    void AvatarAtSouthEst()
    {
        if (Input.GetKey(southKey) && Input.GetKey(estKey))
        {
            roadScript = RoadList[6].GetComponent<Road>();
            
            avatarScript.roadReference = roadScript;

            avatarScript.RoadInitialization();
        }
    }
    
    void AvatarAtSouthWest()
    {
        if (Input.GetKey(southKey) && Input.GetKey(westKey))
        {
            roadScript = RoadList[7].GetComponent<Road>();
            
            avatarScript.roadReference = roadScript;

            avatarScript.RoadInitialization();
        }
    }

    void AvatarAtCenter()
    {
        if (Input.GetKey(northKey))
        {
            roadScript = RoadList[0].GetComponent<Road>();
            
            avatarScript.roadReference = roadScript;

            avatarScript.RoadInitialization();
        }

        if (Input.GetKey(westKey))
        {
            roadScript = RoadList[1].GetComponent<Road>();
            
            avatarScript.roadReference = roadScript;

            avatarScript.RoadInitialization();
        }
        
        if (Input.GetKey(estKey))
        {
            roadScript = RoadList[2].GetComponent<Road>();
            
            avatarScript.roadReference = roadScript;

            avatarScript.RoadInitialization();
        }
        
        if (Input.GetKey(southKey))
        {
            roadScript = RoadList[3].GetComponent<Road>();
            
            avatarScript.roadReference = roadScript;

            avatarScript.RoadInitialization();
        }
        
        if (Input.GetKey(northKey) && Input.GetKey(westKey))
        {
            roadScript = RoadList[4].GetComponent<Road>();
            
            avatarScript.roadReference = roadScript;

            avatarScript.RoadInitialization();
        }
        
        if (Input.GetKey(northKey) && Input.GetKey(estKey))
        {
            roadScript = RoadList[5].GetComponent<Road>();
            
            avatarScript.roadReference = roadScript;

            avatarScript.RoadInitialization();
        }
        
        if (Input.GetKey(southKey) && Input.GetKey(estKey))
        {
            roadScript = RoadList[6].GetComponent<Road>();
            
            avatarScript.roadReference = roadScript;

            avatarScript.RoadInitialization();
        }
        
        if (Input.GetKey(southKey) && Input.GetKey(westKey))
        {
            roadScript = RoadList[7].GetComponent<Road>();
            
            avatarScript.roadReference = roadScript;

            avatarScript.RoadInitialization();
        }
    }
}
