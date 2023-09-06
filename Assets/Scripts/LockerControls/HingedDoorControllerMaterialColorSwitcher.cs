using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingedDoorControllerMaterialColorSwitcher : HingedDoorController
{
    [SerializeField] private Color _openColor = Color.green;

    public override void SwitchDoorState()
    {
        Renderer thisRenderer = _hingeJoint.gameObject.GetComponent<Renderer>();
        
        IsOpen = !IsOpen;

        if (!IsOpen)
            thisRenderer.material.color = Color.red;
        else
        {
            thisRenderer.material.color = Color.green;
        }
    }

}
