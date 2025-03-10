using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    public GameObject towerPrefab;
    public Transform cursor;
    public Color okColor = Color.green;
    public Color failColor = Color.red;
    public bool canBuild = true;
    
    
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            cursor.position = hit.point;

            if (hit.transform.CompareTag("Ground"))
            {
                canBuild = true;
                cursor.GetComponent<Renderer>().material.color = okColor;
            }
            else
            {
                canBuild = false;
                cursor.GetComponent<Renderer>().material.color = failColor;
            }

            if (Input.GetMouseButtonDown(0) && canBuild)
            {
                Instantiate(towerPrefab, cursor.position, cursor.rotation);
            }
        }
    }
}
