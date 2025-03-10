using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public Transform target;
    
    void Update()
    {
        if(target == null) return;
        
        transform.LookAt(target);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
