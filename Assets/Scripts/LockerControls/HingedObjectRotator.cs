using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class HingedObjectRotator : MonoBehaviour
{
    private HingeJoint hinge;

    private void Awake()
    {
        hinge = GetComponent<HingeJoint>();

        JointSpring spring = new JointSpring();
        spring.spring = 10000f; 
        spring.damper = 500f;    // Moderate damping to reduce oscillation and have almost constant motion
        hinge.spring = spring;
        spring.targetPosition = 180f;
        hinge.useSpring = true;
    }

    public void RotateObject(float targetAngle)
    {
        JointSpring spring = hinge.spring;
        spring.targetPosition = targetAngle;
        hinge.spring = spring;
    }
}