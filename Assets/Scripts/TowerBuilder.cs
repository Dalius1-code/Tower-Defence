using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    public Player player;
    public Transform cursor;
    public GameObject towerPrefab;
    public int baseCost = 10;
    

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            cursor.position = hit.point;

            if(Input.GetMouseButtonDown(0) && player.money >= baseCost)
            {
                player.money -= baseCost;
                Instantiate(towerPrefab, cursor.position, cursor.rotation);
            }
        }
    }
}
