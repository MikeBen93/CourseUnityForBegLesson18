using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatfrom : MonoBehaviour
{
    [SerializeField] private Collider2D upperCollider;
    [SerializeField] private Collider2D lowerCollider;
    [SerializeField] private float _initialMotorSpeed = -2;

    private SliderJoint2D _sliderJoint;
    private JointMotor2D _sliderJointMotor;

    private void Start()
    {
        _sliderJoint = GetComponent<SliderJoint2D>();
        _sliderJointMotor = _sliderJoint.motor;
        _sliderJointMotor.motorSpeed = _initialMotorSpeed;
        _sliderJoint.motor = _sliderJointMotor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == upperCollider || collision == lowerCollider)
        {
            _sliderJointMotor.motorSpeed *= -1;
            _sliderJoint.motor = _sliderJointMotor;
        }
    }
}
