using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HingedDoorController))]
public abstract class LockerControllerBase: MonoBehaviour
{
    public HingedDoorController DoorController;

    private void OnEnable()
    {
        DoorController = GetComponent<HingedDoorController>();
    }

    public void SwitchDoorState()
    {
        DoorController.SwitchDoorState();
    }

    public void CloseDoor()
    {
        if (DoorController.IsOpen)
        {
            DoorController.SwitchDoorState();
        }
    }
}
