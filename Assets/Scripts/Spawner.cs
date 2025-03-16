using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    
    [Header("Wave settings")]
    public int count = 10;
    public float cooldown = 0.5f;
    
    [Header("Spawn settings")]
    public int waveCount = 10;
    public float waveCooldown = 2;
    
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        //all waves
        for (int i = 0; i < waveCount; i++)
        {
            //one waves
            for (int j = 0; j < count; j++)
            {
                Instantiate(prefab, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(cooldown);
            }
            
            yield return new WaitForSeconds(waveCooldown);
        }
        
    }
    
}
