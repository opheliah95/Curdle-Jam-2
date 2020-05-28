using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public GearState currState;
    public Transform player;

    public enum GearState
    {
        StickNeutral,
        StickPoke,
        ExtenderNeutral,
        ExtenderGrab,
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
                    break;
                case (GearState.ExtenderNeutral):
                    break;
                case (GearState.ExtenderHold):
                    break;
            }
        }
    }

    void SwitchGear()
    {
        if (currState == GearState.ExtenderHold)
            DropTP();

        if (currState == GearState.ExtenderNeutral)
            currState = GearState.StickNeutral;

        if (currState == GearState.StickNeutral)
            currState = GearState.ExtenderNeutral;
    }

    void Poke()
    {
        if (currState == GearState.StickNeutral)
        {
            currState = GearState.StickPoke;
            // Use coroutines to do the stabby stab
        }
    }

    void Grab()
    {

    }

    void DropTP()
    {
        if (currState == GearState.ExtenderHold)
        {
            currState = GearState.ExtenderNeutral;
            // TODO: Also drop the TP in a radius around you
        }
    }
}
