using System.Collections;
using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class HingedDoorController : MonoBehaviour
{
    public bool IsOpen = false;
    
    [SerializeField] private float _hingeMotorVelocity = 100f;
    [SerializeField] private float _hingeMotorForce = 50f;
    [SerializeField] private float _kinematicReturnDuration = 4f;

    protected HingeJoint _hingeJoint;
    private Rigidbody _rigidbody;
    
    protected void OnEnable()
    {
        _hingeJoint = GetComponent<HingeJoint>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void SwitchDoorState()
    {
        StopCoroutine("KinematicSwitchRoutine");
        
        // Positive velocity opens the door
        _hingeMotorVelocity = Mathf.Abs(_hingeMotorVelocity);
        
        IsOpen = !IsOpen;
        
        if (!IsOpen)
            _hingeMotorVelocity *= -1f;

        JointMotor motor = new JointMotor();
        motor.force = _hingeMotorForce;
        motor.targetVelocity = _hingeMotorVelocity;

        _hingeJoint.motor = motor;
        StartCoroutine("KinematicSwitchRoutine");
    }

    private IEnumerator KinematicSwitchRoutine()
    {
        _rigidbody.isKinematic = false;
        yield return new WaitForSeconds(_kinematicReturnDuration);
        _rigidbody.isKinematic = true;
        
        StopCoroutine("KinematicSwitchRoutine");
    }
    
}
