using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingedDoorControllerSpring : HingedDoorController
{
    [SerializeField] private float _openTargetPosition = 120f;

    public override void SwitchDoorState()
    {
        StopCoroutine("KinematicSwitchRoutine");
        
        JointSpring spring = new JointSpring();
        spring.spring = 5000f;
        spring.damper = 0f;
        
        IsOpen = !IsOpen;
        
        if (!IsOpen)
            spring.targetPosition = 0f;
        else
        {
            spring.targetPosition =  _openTargetPosition;
        }
        

        _hingeJoint.spring = spring;
        
        StartCoroutine("KinematicSwitchRoutine");
    }

}
