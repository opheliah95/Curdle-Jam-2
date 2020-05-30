using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public GearState currState;
    // public Transform player;
    public Transform cam;
    // public bool isPoking;
    public bool isGrabbing;
    // public float pushStrength;
    public float range;
    //public LayerMask[] interactableLayers;
    private GameObject TP; // "Inventory"; to drop it.
    public Animator anim;

    public enum GearState
    {
        // StickNeutral,
        ExtenderNeutral,
        ExtenderHold
    }

    // Start is called before the first frame update
    void Start()
    {
        currState = GearState.ExtenderNeutral;
        range = 5.0f;
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // L-click -> If not in cooldown state, try grab.
        // Curr item = extender -> Grab/Poke
        // Curr item = extender+TP -> DropTP

        // Single-frame only, no spam
        if (Input.GetMouseButtonDown(0) && currState == GearState.ExtenderHold)
            DropTP();

        else if (Input.GetMouseButton(0) && currState == GearState.ExtenderNeutral && !isGrabbing)
            StartCoroutine("Grab");
    }
    
    IEnumerator Grab()
    {
        isGrabbing = true;
        anim.SetBool("isGrabbing", true);

        RaycastHit hit;
        //if (Physics.Raycast(transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, range))
        if (Physics.SphereCast(transform.position, 1f, cam.transform.TransformDirection(Vector3.forward), out hit, range))
        {
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("tp_layer"))
                {
                    currState = GearState.ExtenderHold;
                    anim.SetBool("hitTP", true);
                    anim.SetBool("hasTP", true);
                    // I feel this is awkward and not done right...!
                    TP = hit.collider.gameObject;
                    TP.SetActive(false);
                }
                else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("infected_layer"))
                {
                    hit.collider.gameObject.GetComponent<InfectedBehaviour>().StartCoroutine("IsHit");
                }
            }
        }
        else
        {
            // Miss. We'd put the embarassing audio here...if we had any.
        }
        yield return new WaitForSeconds(0.5f);

        anim.SetBool("hitTP", false);
        isGrabbing = false;
        anim.SetBool("isGrabbing", false);
    }

    void DropTP()
    {
        currState = GearState.ExtenderNeutral;
        anim.SetBool("hasTP", false);
        // Random point.
        Vector2 point = Random.insideUnitCircle * range;
        Vector3 newLocation = new Vector3(point.x, -2, point.y);
        newLocation += transform.position - transform.TransformDirection(Vector3.forward) * range;
        TP.transform.position = newLocation;
        TP.SetActive(true);
    }
}
