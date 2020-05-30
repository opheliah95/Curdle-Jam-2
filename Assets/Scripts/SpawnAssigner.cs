using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAssigner : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        FindObjectOfType<InfectedSpawner>().spawnPoints.Add(gameObject.transform);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
