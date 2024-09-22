using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class GameLoop : MonoBehaviour
{
    public SpawnItems spawnItems;

    public GameObject mailBox;
    public GameObject incinerator;

    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnItems.spawnRandom();
        }
    }

    public void updateScore(int amount)
    {
        score = score + amount;
    }
}
