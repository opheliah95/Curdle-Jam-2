using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectedBehaviour : MonoBehaviour
{
    public GameObject Player;
    public float speed;

    public bool isChasing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform);
        transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));

        if(isChasing)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, step);
        }
    }
}
