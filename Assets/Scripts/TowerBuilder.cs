using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    public GameObject towerPrefab;
    public Transform cursor;
    
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            cursor.position = hit.point;

            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(towerPrefab, cursor.position, cursor.rotation);
            }
        }
    }
}
