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

        // Draw gear in and animate such. Audio ga-ga.
    }
    
    IEnumerator Grab()
    {
        isGrabbing = true;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, range))
        {
            print("You touched...");
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("tp_layer"))
                {
                    print("TP!");
                    currState = GearState.ExtenderHold;
                    // Disable the TP on-map, or move it, idk. 

                }
                else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("infected_layer"))
                {
                    print("Infected!");
                    hit.transform.Translate(transform.TransformDirection(Vector3.forward));
                }
            }
        }
        else
        {
            // Miss. We'd put the embarassing audio here...if we had any.
        }
        yield return new WaitForSeconds(0.5f);
        isGrabbing = false;
    }

    void DropTP()
    {
        print("Dropping TP?");
        currState = GearState.ExtenderNeutral;
        // TODO: Also drop the TP in a radius around you
    }
}
