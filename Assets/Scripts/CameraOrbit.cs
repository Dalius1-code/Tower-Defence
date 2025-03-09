using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Vector3 targetPosition;
    public float rotationSpeed = 100f;
    public float zoomSpeed = 10f;
    public float minZoom = 5;
    public float maxZoom = 50;
    
    private float currentAngle = 0f;
    private float currentZoom = 10;
    private Vector3 offset;
    
    void Start()
    {
        offset = transform.position - targetPosition;
        offset.x = 0;
        offset.z = 0;
        
        currentZoom = Vector3.Distance(transform.position, targetPosition);
    }

    
    void Update()
    {
        //rotate with a and d 
        var rotationInput = Input.GetAxis("Horizontal");
        currentAngle += rotationInput * rotationSpeed * Time.deltaTime;
        
        //zoom with mouse wheel
        var zoomInput = Input.GetAxis("Mouse ScrollWheel");
        currentZoom -= zoomInput * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        
        //apply rotation & zoom
        var direction = new Vector3(
            Mathf.Sin(currentAngle * Mathf.Deg2Rad), 
            0, 
            Mathf.Cos(currentAngle * Mathf.Deg2Rad));
        
        transform.position = targetPosition + direction * currentZoom + offset;
        
        transform.LookAt(targetPosition);
    }
}
