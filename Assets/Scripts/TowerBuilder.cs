using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    public LayerMask groundLayer;
    public Transform cursor;
    public GameObject towerPrefab;

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, groundLayer))
        {
            cursor.position = hit.point;
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(towerPrefab, cursor.position, cursor.rotation);
            }
        }
    }
}

