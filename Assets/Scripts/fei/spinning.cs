using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinning : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, -30 *Time.deltaTime, 0 ); 
    }
}
