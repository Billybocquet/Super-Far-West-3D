using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    
    [Header("Keyboard Controls")]
    [SerializeField] private KeyCode forwardKey;
    [SerializeField] private KeyCode backKey;
    [SerializeField] private KeyCode leftKey;
    [SerializeField] private KeyCode rightKey;
    [SerializeField] private KeyCode fastKey;
    [SerializeField] private KeyCode lefRotateKey;
    [SerializeField] private KeyCode rightRotateKey;
    [SerializeField] private KeyCode zoomInKey;
    [SerializeField] private KeyCode zoomOutKey;
    [SerializeField] private KeyCode escapeFollowKey;
    
    [Header("Mouse Controls")]
    [SerializeField] private KeyCode dragMouse;
    [SerializeField] private KeyCode rotateMouse;

    [Header("Camera")]
    [SerializeField] private Transform cameraTransform;

    [Header("Camera Settings")]
    [SerializeField] private float normalSpeed;
    [SerializeField] private float fastSpeed;
    private float movementSpeed;
    [SerializeField] private float movementTime;
    [SerializeField] private float rotationAmount;
    [SerializeField] private Vector3 zoomAmount;

    [Header("Follow")] [SerializeField] private Transform followTransform;

    private Vector3 newPosition;
    private Quaternion newRotation;
    private Vector3 newZoom;

    private Vector3 dragStartPosition;
    private Vector3 dragCurrentPosition;
    private Vector3 rotateStartPosition;
    private Vector3 rotateCurrentPosition;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (followTransform != null)
        {
            transform.position = followTransform.position;
        }
        else
        {
            HandleMovementInput();
            HandleMouseInput();            
        }

        if (Input.GetKey(escapeFollowKey))
        {
            followTransform = null;
        }
    }

    void HandleMouseInput()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            newZoom += Input.mouseScrollDelta.y * zoomAmount;
        }
        
        if (Input.GetKeyDown(dragMouse))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if (plane.Raycast(ray, out entry))
            {
                dragStartPosition = ray.GetPoint(entry);
            }
        }
        if (Input.GetKey(dragMouse))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if (plane.Raycast(ray, out entry))
            {
                dragCurrentPosition = ray.GetPoint(entry);

                newPosition = transform.position + dragStartPosition - dragCurrentPosition;
            }
        }

        if (Input.GetKeyDown(rotateMouse))
        {
            rotateStartPosition = Input.mousePosition;
        }
        if (Input.GetKey(rotateMouse))
        {
            rotateCurrentPosition = Input.mousePosition;

            Vector3 difference = rotateStartPosition - rotateCurrentPosition;

            rotateStartPosition = rotateCurrentPosition;
            
            newRotation *= Quaternion.Euler(Vector3.up * (-difference.x / 5f));
        }
    }

    void HandleMovementInput()
    {
        if (Input.GetKey(fastKey))
        {
            movementSpeed = fastSpeed;            
        }
        else
        {
            movementSpeed = normalSpeed;            
        }

        if (Input.GetKey(forwardKey))
        {
            newPosition += (transform.forward * movementSpeed);            
        }
        if (Input.GetKey(backKey))
        {
            newPosition += (transform.forward * -movementSpeed);                
        }
        if (Input.GetKey(leftKey))
        {
            newPosition += (transform.right * -movementSpeed);            
        }
        if (Input.GetKey(rightKey))
        {
            newPosition += (transform.right * movementSpeed);            
        }

        if (Input.GetKey(lefRotateKey))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }
        if (Input.GetKey(rightRotateKey))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }

        if (Input.GetKey(zoomInKey))
        {
            newZoom += zoomAmount;
        }        
        if (Input.GetKey(zoomOutKey))
        {
            newZoom -= zoomAmount;
        }
        
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementSpeed);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);
    }
}
