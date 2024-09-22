using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SpawnItems : MonoBehaviour
{
    public List<GameObject> items;

    public List<GameObject> spawns;

    public void spawnRandom()
    {
        int newSpawn = Random.Range(0, spawns.Count);
        int newItem = Random.Range(0, items.Count);

        if (items[newItem].tag == "trash")
        {
            Instantiate(items[newItem], spawns[newSpawn].transform.position, Quaternion.Euler(0, 90, 0));
        }
        else
        {
            Instantiate(items[newItem], spawns[newSpawn].transform.position, Quaternion.Euler(0, Random.Range(0, 359), 0));
        }
        
    }
}
