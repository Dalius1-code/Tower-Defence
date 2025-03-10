using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Vector3 targetPosition = Vector3.zero;
    
    [Header("Rotate Settings")]
    public float rotateSpeed = 100f;
    
    [Header("Zoom settings")]
    public float zoomSpeed = 10;
    public float minZoom = 5;
    public float maxZoom = 50;

    private float currentAngle = 0;
    private Vector3 offset;
    private float currentZoom;
    
    void Start()
    {
        offset = transform.position - targetPosition;
        offset.x = 0;
        offset.z = 0;
        
        currentZoom = Vector3.Distance(transform.position, targetPosition);
    }

   
    void Update()
    {
        //rotate with a d 
        var rotationInput = Input.GetAxis("Horizontal");
        currentAngle += rotationInput * rotateSpeed * Time.deltaTime;
        
        //zoom with wheel
        var zoomInput = Input.GetAxis("Mouse ScrollWheel");
        currentZoom -= zoomInput * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        
        //apply
        var direction = new Vector3(
            Mathf.Sin(currentAngle * Mathf.Deg2Rad),
            0,
            Mathf.Cos(currentAngle * Mathf.Deg2Rad)
        );
        
        transform.position = targetPosition + offset + currentZoom * direction;
        
        transform.LookAt(targetPosition);
    }
}
