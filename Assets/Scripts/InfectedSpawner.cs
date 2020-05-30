using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectedSpawner : MonoBehaviour
{
    public GameObject player;

    public List<GameObject> prefabList;
    public List<Transform> spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        int index = 0;

        for(int i = 0; i < spawnPoints.Count; i++)
        {
            index = Random.Range(0, 4);

            GameObject infected = GameObject.Instantiate(prefabList[index], spawnPoints[i].position, Quaternion.identity);
            infected.GetComponent<InfectedBehaviour>().player = player;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
