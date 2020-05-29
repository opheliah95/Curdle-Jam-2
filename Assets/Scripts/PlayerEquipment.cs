using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public GearState currState;
    public Transform player;
    public Transform cam;
    public bool isPoking;
    public bool isGrabbing;
    public float pushStrength;
    public float range;

    public enum GearState
    {
        StickNeutral,
        ExtenderNeutral,
        ExtenderHold
    }

    // Start is called before the first frame update
    void Start()
    {
        currState = GearState.StickNeutral;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * range, Color.blue);
        Debug.DrawRay(transform.position, cam.transform.TransformDirection(Vector3.forward) * range, Color.yellow);

        // Get input.
        if (Input.GetMouseButtonDown(1))
        {
            SwitchGear();
        }

        // L-click -> If not in cooldown state/non-neutral, use current item
        // Curr item = stick -> Poke
        // Curr item = extender -> Grab
        // Curr item = extender+TP -> DropTP
        if (Input.GetMouseButton(0))
        {
            switch (currState)
            {
                case (GearState.StickNeutral):
                    if (!isPoking)
                        StartCoroutine("Poke");
                    break;
                case (GearState.ExtenderNeutral):
                    if (!isGrabbing)
                        StartCoroutine("Grab");
                    break;
                case (GearState.ExtenderHold):
                    DropTP();
                    break;
            }
        }

        // Draw gear in and animate such.
    }

    void SwitchGear()
    {
        if (currState == GearState.ExtenderHold)
            DropTP();

        if (currState == GearState.ExtenderNeutral)
            currState = GearState.StickNeutral;
        else if (currState == GearState.StickNeutral)
            currState = GearState.ExtenderNeutral;
    }

    IEnumerator Poke()
    {
        isPoking = true;
        // Animate stick
        // Raycast the push
        RaycastHit hit;
        // Doesn't take vert axis into account
        // if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range))
        if (Physics.Raycast(transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, range))
        {
            print("You hit a thing!");
            // TODO: Move object backwards using the object's method
            hit.transform.Translate(transform.TransformDirection(Vector3.forward) * pushStrength);
        }
        print("Poking poking poking");
        yield return new WaitForSeconds(0.5f);
        isPoking = false;
    }

    IEnumerator Grab()
    {
        isGrabbing = true;
        // Do the grabby wabby
        print("Grabbing shit.");
        yield return new WaitForSeconds(0.5f);
        isGrabbing = false;
    }

    void DropTP()
    {
        currState = GearState.ExtenderNeutral;
        // TODO: Also drop the TP in a radius around you
    }
}
