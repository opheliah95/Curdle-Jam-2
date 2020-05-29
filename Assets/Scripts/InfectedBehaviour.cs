using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectedBehaviour : MonoBehaviour
{
    public GameObject Player;
    public float speed;

    public bool isChasing;
    Vector3 direction;

    public bool isTesting;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform);
        transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));

        direction = Player.transform.position - transform.position;

        if (isChasing)
        {
            //float step = speed * Time.deltaTime;
            //transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, step);

            Vector3 movement = direction.normalized * speed * Time.deltaTime;

            if (movement.magnitude > direction.magnitude)
                movement = direction;

            GetComponent<CharacterController>().Move(movement);
        }

        if(isTesting)
        {
            isHit();
            isTesting = false;
        }
    }

    public void isHit()
    {
        Vector3 knockBack = -(direction.normalized * 5);
        GetComponent<CharacterController>().Move(knockBack);
    }
}
