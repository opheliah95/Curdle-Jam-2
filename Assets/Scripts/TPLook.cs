using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPLook : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        transform.Rotate(new Vector3(transform.position.x + 180, transform.position.y, transform.position.z));
    }
}
