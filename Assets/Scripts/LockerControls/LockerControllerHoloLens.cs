using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

public class LockerControllerHololens : LockerControllerBase, IMixedRealityPointerHandler
{
    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        // Do nothing
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        // Do nothing
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        // Do nothing
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        SwitchDoorState();
        eventData.Use(); // Mark the event as used so it doesn't propagate to other handlers.
    }
}
