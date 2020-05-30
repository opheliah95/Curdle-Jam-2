using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectedBehaviour : MonoBehaviour
{
    Animator anim;

    public GameObject Player;
    public float speed;

    public bool isChasing;
    Vector3 direction;

    public bool isTesting;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
            StartCoroutine("IsHit");
            isTesting = false;
        }
    }

    public IEnumerator IsHit()
    {
        anim.SetBool("isHit", true);
        
        Vector3 knockBack = -(direction.normalized * 5);
        GetComponent<CharacterController>().Move(knockBack);

        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isHit", false);
    }
}
